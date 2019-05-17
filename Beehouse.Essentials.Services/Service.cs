using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beehouse.Essentials.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Beehouse.Essentials.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity:Entity
    {
        protected readonly DbContext Context;
        public HttpContext HttpContext { get; }

        public Service(DbContext context, IHttpContextAccessor httpContextAccessor)
        {
            Context = context;
            HttpContext = httpContextAccessor.HttpContext;

            Debug.WriteLine($">>>> Instance of Service");
        }

        private DbSet<TEntity> _entities;

        protected DbSet<TEntity> Entities => _entities ?? (_entities = Context.Set<TEntity>());

        public virtual IQueryable<TEntity> GetEntities(bool tracking = false)
        {
            var query = tracking ? Entities.AsTracking() : Entities.AsNoTracking();
            return query;
        }

        public virtual async Task<TEntity> GetByIdAsync(string id, bool tracking = false, IQueryable<TEntity> query = null)
        {
            if (query is null) query = tracking ? Entities.AsTracking() : Entities.AsNoTracking();
            return await query.FirstOrDefaultAsync(p => p.Id == id);
        }

        public virtual async Task<ICollection<TEntity>> GetAsync(bool tracking = false, IQueryable<TEntity> query = null)
        {
            if (query is null) query = tracking ? Entities.AsTracking() : Entities.AsNoTracking();
            return await query.ToListAsync();
        }

        public virtual async Task<SearchResult<TEntity>> GetAsync(int? page_nullable, int? limit_nullable, bool tracking = false, IQueryable<TEntity> query = null)
        {
            // Check arguments
            page_nullable = page_nullable ?? 1;
            limit_nullable = limit_nullable ?? 10;
            int page = (int)(page_nullable <= 0 ? 1 : page_nullable);
            int limit = (int)(limit_nullable<= 0 ? 10 : limit_nullable);

            // Check query
            if (query == null) query = tracking ? Entities.AsTracking() : Entities.AsNoTracking();

            // Query and count
            var count = await query.CountAsync();

            // Page and limit
            query = query.Skip((page - 1) * limit).Take(limit);

            // Result
            var result = new SearchResult<TEntity>
            {
                Page = page,
                Limit = limit,
                Count = count,
                HttpContext = HttpContext,
                Result = await query.ToListAsync().ConfigureAwait(false)
            };

            return result;
        }

        public virtual async Task<TEntity> InsertAsync(TEntity e)
        {
            Debug.WriteLine($">>>> Saving on {this.GetType().FullName}.InsertAsync");
            e.CreatedAt = DateTime.Now;
            e.UpdatedAt = DateTime.Now;
            e.Deleted = false;

            await Entities.AddAsync(e);
            await Context.SaveChangesAsync();

            return e;
        }

        public virtual async Task<TEntity> InsertOrUpdateAsync(TEntity m)
        {
            if (!string.IsNullOrWhiteSpace(m.Id))
            {
                m.UpdatedAt = DateTime.Now;
                Entities.Attach(m);
                Context.Entry(m).State = EntityState.Modified;
            }
            else
            {
                m.CreatedAt = DateTime.Now;
                m.UpdatedAt = DateTime.Now;
                m.Deleted = false;

                await Entities.AddAsync(m);
            }

            await Context.SaveChangesAsync();

            return m;
        }
        

        public virtual async Task<TEntity> UpdateAsync(TEntity entity, TEntity old = null)
        {
            // Get old entity
            old = await GetOldEntity(entity);
                          
            // Default values
            entity.UpdatedAt = DateTime.Now;

            // Attach
            EntityEntry<TEntity> entry = Entities.Attach(entity);
            ChangeEntityState(entry);

            // Do update
            await Context.SaveChangesAsync();

            // Return result
            return entity;
        }

        public virtual async Task<bool> DeleteAsync(string id, bool logic = false)
        {
            // Try get entity
            var entity = await GetByIdAsync(id);
            if (entity == null) throw new Exception(">>>> Beehouse.Service => Entity doesn't exists in database to delete.");

            if (logic)
            {
                entity.Deleted = true;
                return await UpdateAsync(entity) != null;
            }

            Entities.Remove(entity);
            var result = await Context.SaveChangesAsync();

            return result > 0;
        }

        /// <summary>
        /// Check if entity exists in database.
        /// </summary>
        /// <param name="id">ID of the entity.</param>
        /// <returns>Return true if entity exists in database.</returns>
        public virtual async Task Exists(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                ThrowException(this, $"ID is required.");

            TEntity entity = await GetByIdAsync(id);

            if (entity == null)
                ThrowException(entity, $"This entity of ID \"{id}\" doesn't exists in database.");
        }

        protected virtual void ChangeEntityState(EntityEntry<TEntity> entry)
        {
            if(entry.State != EntityState.Modified)
                entry.State = EntityState.Modified;

            entry.Property(p => p.CreatedAt).IsModified = false;
        }

        protected bool IsAttached(TEntity entity)
        {

            return Entities.Local.Any(e => e.Id == entity.Id);
        }

        protected virtual async Task<TEntity> GetOldEntity(TEntity entity)
        {
            // Verify if entity is attached
            if (IsAttached(entity))
            {
                TEntity attached = Entities.Local.FirstOrDefault(p => p.Id == entity.Id);
                return attached;
            }

            // Verify if entity are in the context
            TEntity old = await GetByIdAsync(entity.Id);
            if(old == null)
                ThrowException(this, "Try to get an old entity, but that doesn't exists in the context.");

            return old;
        }

        /// <summary>
        /// Throw a new exception that describes type
        /// </summary>
        /// <param name="member">Member that throwed the exception</param>
        /// <param name="message">Message</param>
        protected void ThrowException(object member, string message)
        {
            var m = new StringBuilder();
            m.Append(member.GetType().Name);
            m.Append(" >>>> ");
            m.Append(message);

            message = m.ToString();

            Debug.WriteLine(message);
            throw new Exception(message);
        }
    }
}