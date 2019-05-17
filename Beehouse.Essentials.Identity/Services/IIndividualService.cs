using Beehouse.Essentials.Entities;

namespace Beehouse.Essentials.Services
{
    public interface IIndividualService<TEntity>:IService<TEntity> where TEntity : Entity
    {
        
    }
}