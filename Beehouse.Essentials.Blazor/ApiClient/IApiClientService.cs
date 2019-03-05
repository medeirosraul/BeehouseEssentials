using System.Threading.Tasks;

namespace Beehouse.Essentials.Blazor.ApiClient
{
    public interface IApiClientService
    {
        Task<ApiResult<TResult>> GetAsync<TResult>(string resource) where TResult : class;
        Task<string> GetAsync(string resource);
        Task<ApiResult<TResult>> PostAsync<TResult>(string resource, TResult entity) where TResult : class;
        Task<ApiResult<TResult>> PutAsync<TResult>(string resource, TResult entity) where TResult : class;
        Task<ApiResult<bool>> DeleteAsync(string resource, string id);
        void AddParameter(string parameter, string argument);
    }
}
