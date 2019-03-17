using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beehouse.Essentials.Entities;
using Microsoft.AspNetCore.Http;

namespace Beehouse.Essentials.Services
{
    public interface IService<TEntity> where TEntity : Entity
    {
        // Properties
        HttpContext HttpContext { get; }

        // Methods
        IQueryable<TEntity> GetEntities(bool tracking = false);
        Task<TEntity> GetByIdAsync(string id, bool tracking = false, IQueryable<TEntity> query = null);
        Task<ICollection<TEntity>> GetAsync(bool tracking = false, IQueryable<TEntity> query = null);
        Task<SearchResult<TEntity>> GetAsync(int? page_nullable, int? limit_nullable, bool tracking = false, IQueryable<TEntity> query = null);
        Task<TEntity> InsertAsync(TEntity e);
        Task<TEntity> InsertOrUpdateAsync(TEntity m);
        Task<TEntity> UpdateAsync(TEntity entity, TEntity old = null);
        Task<bool> DeleteAsync(string id, bool logic = false);
        Task Exists(string id);
    }
}