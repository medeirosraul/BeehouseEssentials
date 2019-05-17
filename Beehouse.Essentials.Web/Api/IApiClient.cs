using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beehouse.Essentials.Web.Api
{
    public interface IApiClient
    {
        Task<ApiResult<TResult>> GetAsync<TResult>(string resource);
        Task<ApiResult<TResult>> PostAsync<TResult>(string resource, TResult entity) where TResult : class;
        Task<ApiResult<TResult>> PutAsync<TResult>(string resource, TResult entity) where TResult : class;
        void AddParameter(string parameter, string argument);
    }
}
