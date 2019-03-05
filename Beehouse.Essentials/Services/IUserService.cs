using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beehouse.Essentials.Entities;
using Microsoft.AspNetCore.Http;

namespace Beehouse.Essentials.Services
{
    public interface IUserService<TEntity>:IService<TEntity> where TEntity : Entity
    {
        
    }
}