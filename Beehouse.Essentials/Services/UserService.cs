using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beehouse.Essentials.DeveloperTools.Identity;
using Beehouse.Essentials.Entities;
using Beehouse.Essentials.Identity.Claims;
using Beehouse.Essentials.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Beehouse.Essentials.Services
{
    /// <summary>
    /// Service with user control.
    /// </summary>
    /// <typeparam name="TUserEntity">Entity type.</typeparam>
    public class UserService<TUserEntity>: Service<TUserEntity>, IUserService<TUserEntity> where TUserEntity : UserEntity
    {
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected bool IsOwner;
        protected string OwnedBy;
        protected string CreatedBy;
        protected string CreatorName;

        /// <summary>
        /// Create new service with user control.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="httpContextAccessor"></param>
        public UserService(DbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
            // Context accessor
            _httpContextAccessor = httpContextAccessor;

            // Identify user
            Identify();
        }

        /// <summary>
        /// Get an Entity by his Id
        /// </summary>
        /// <param name="id">Identification</param>
        /// <param name="tracking">Track entity?</param>
        /// <param name="query">Additional conditions</param>
        /// <returns>An Entity of the specified Id, type and additional conditions</returns>
        public override async Task<TUserEntity> GetByIdAsync(string id, bool tracking = false, IQueryable<TUserEntity> query = null)
        {
            // Check if have additional conditions. If not, create a new condition.
            if (query is null) query = tracking ? Entities.AsTracking() : Entities.AsNoTracking();

            // Add condition: If current user is not owner of the account, get only entities that current user have created.
            if (!IsOwner) query = query.Where(p => p.CreatedBy == OwnedBy || p.CreatedBy == CreatedBy);

            // And get entities that user are owner.
            query = query.Where(p => p.OwnedBy == OwnedBy);

            // Return base operations.
            return await base.GetByIdAsync(id, tracking, query);
        }

        /// <summary>
        /// Get a collection of entities
        /// </summary>
        /// <param name="tracking">Track entities?</param>
        /// <param name="query">Additional conditions</param>
        /// <returns></returns>
        public override async Task<ICollection<TUserEntity>> GetAsync(bool tracking = false, IQueryable<TUserEntity> query = null)
        {
            // Check if have additional conditions. If not, create a new condition.
            if (query is null) query = tracking ? Entities.AsTracking() : Entities.AsNoTracking();

            // Return base operations.
            return await base.GetAsync(tracking, query.Where(p => p.OwnedBy == OwnedBy));
        }

        /// <summary>
        /// Get a collection of entities paged and limited number
        /// </summary>
        /// <param name="page">Current page</param>
        /// <param name="limit">Limit of entities per page</param>
        /// <param name="tracking">Track entities?</param>
        /// <param name="query">Additional conditions</param>
        /// <returns></returns>
        public override async Task<SearchResult<TUserEntity>> GetAsync(int page, int limit, bool tracking = false, IQueryable<TUserEntity> query = null)
        {
            // Check if have additional conditions. If not, create a new condition.
            if (query == null) query = tracking ? Entities.AsTracking() : Entities.AsNoTracking();

            // Set owner identification
            query = query.Where(p => p.OwnedBy == OwnedBy);

            // Return base operations.
            return await base.GetAsync(page, limit, tracking, query);
        }

        /// <summary>
        /// Include a new entity in context
        /// </summary>
        /// <param name="e">Entity to be included</param>
        /// <returns>Returns included entity</returns>
        public override async Task<TUserEntity> InsertAsync(TUserEntity e)
        {
            // Set identifications to entity.
            e.OwnedBy = OwnedBy;
            e.CreatedBy = CreatedBy;
            e.CreatorName = CreatorName;

            // Return base operations.
            return await base.InsertAsync(e);
        }

        /// <summary>
        /// Update a existing entity in context
        /// </summary>
        /// <param name="entity">Entity to be updated</param>
        /// <param name="old">Old entity</param>
        /// <returns>Updated entity</returns>
        public override async Task<TUserEntity> UpdateAsync(TUserEntity entity, TUserEntity old = null)
        {
            // Get old entity
            if(old == null)
                old = await GetOldEntity(entity);

            // Verify if the current user is owner or creator
            if (old.CreatedBy != CreatedBy && OwnedBy != CreatedBy)
                ThrowException(this, "Invalid access to entity.");

            // Return base operations.
            return await base.UpdateAsync(entity, old);
        }

        /// <summary>
        /// Change the entity and columns state
        /// </summary>
        /// <param name="entry"></param>
        protected override void ChangeEntityState(EntityEntry<TUserEntity> entry)
        {
            if (entry.State != EntityState.Modified)
                entry.State = EntityState.Modified;

            entry.Property(p => p.OwnedBy).IsModified = false;
            entry.Property(p => p.CreatedBy).IsModified = false;
            entry.Property(p => p.CreatorName).IsModified = false;

            base.ChangeEntityState(entry);
        }

        /// <summary>
        /// Deprecated
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public override async Task<TUserEntity> InsertOrUpdateAsync(TUserEntity m)
        {
            if (string.IsNullOrWhiteSpace(m.Id))
            {
                m.CreatedBy = CreatedBy;
                m.CreatorName = CreatorName;
            }
            m.OwnedBy = OwnedBy;

            return await base.InsertOrUpdateAsync(m);
        }

        private void Identify()
        {
            if (BeehouseSettings.UseDevelopmentMode)
            {
                IsOwner = Valentina.IsOwner;
                OwnedBy = Valentina.OwnedBy;
                CreatedBy = Valentina.CreatedBy;
                CreatorName = Valentina.CreatorName;
                return;
            }

            // Getting user informations
            CreatedBy = _httpContextAccessor.HttpContext.User.FindFirst(BeehouseClaimTypes.Identification)?.Value;
            if (CreatedBy == null) throw new UnauthorizedAccessException("Creator ID not founded.");

            CreatorName = _httpContextAccessor.HttpContext.User.FindFirst(BeehouseClaimTypes.Name)?.Value;
            if (CreatorName == null) throw new UnauthorizedAccessException("Creator Name not defined.");

            OwnedBy = _httpContextAccessor.HttpContext.User.FindFirst(BeehouseClaimTypes.SubscriptionOwner)?.Value;
            if (OwnedBy == null) throw new UnauthorizedAccessException("Subscription for this identity does not owned.");

            // Set true if creator is subscription owner.
            IsOwner = CreatedBy == OwnedBy;
        }
    }
}