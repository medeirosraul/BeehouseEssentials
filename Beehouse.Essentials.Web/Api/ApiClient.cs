using Beehouse.Essentials.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Beehouse.Essentials.Web.Api
{
    public class ApiClient:IApiClient
    {
        private readonly BeehouseWebOptions _options;
        private readonly Dictionary<string, string> _parameters = new Dictionary<string, string>();

        public HttpClient Client { get; }

        public ApiClient(IOptionsMonitor<BeehouseWebOptions> options, HttpClient client)
        {
            _options = options.CurrentValue;
            Client = client;
        }

        #region Get
        public async Task<ApiResult<TResult>> GetAsync<TResult>(string resource) where TResult : class
        {
            // Result object
            var result = new ApiResult<TResult>();

            // Mount full uri
            var uri = MountUrl(resource);

            // Log state
            this.Log($"[ApiClient] GetAsync -> {uri}");

            // Get response
            HttpResponseMessage response = await Client.GetAsync(uri).ConfigureAwait(false);
            result.Status = response.IsSuccessStatusCode ? ApiResultStatus.Success : ApiResultStatus.Error;
            result.StatusMessage = response.StatusCode.ToString();
            string content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            // Return result
            if (!string.IsNullOrWhiteSpace(content))
                result.Content = result.Content is string ? content as TResult : JsonConvert.DeserializeObject<TResult>(content);

            return result;
        }
        #endregion

        #region Post

        public async Task<ApiResult<TResult>> PostAsync<TResult>(string resource, TResult entity) where TResult : class
        {
            // Result object
            var result = new ApiResult<TResult>();

            // Mount full uri
            var uri = MountUrl(resource);

            // Get string content
            var jsonContent = JsonConvert.SerializeObject(entity);
            var stringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // Log state
            this.Log($"[ApiClient] PostAsync -> {uri} \n    {jsonContent}");

            // Get response
            HttpResponseMessage response = await Client.PostAsync(uri, stringContent).ConfigureAwait(false);
            result.Status = response.IsSuccessStatusCode ? ApiResultStatus.Success : ApiResultStatus.Error;
            result.StatusMessage = response.StatusCode.ToString();
            string content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            // Return result
            if (!string.IsNullOrWhiteSpace(content))
                result.Content = result.Content is string ? content as TResult : JsonConvert.DeserializeObject<TResult>(content);

            return result;
        }

        #endregion

        #region Put

        public async Task<ApiResult<TResult>> PutAsync<TResult>(string resource, TResult entity) where TResult : class
        {
            // Result object
            var result = new ApiResult<TResult>();

            // Mount full uri
            var uri = MountUrl(resource);

            // Get string content
            var jsonContent = JsonConvert.SerializeObject(entity);
            var stringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // Log state
            this.Log($"[ApiClient] PutAsync -> {uri} \n    {jsonContent}");

            // Get response
            HttpResponseMessage response = await Client.PutAsync(uri, stringContent).ConfigureAwait(false);
            result.Status = response.IsSuccessStatusCode ? ApiResultStatus.Success : ApiResultStatus.Error;
            result.StatusMessage = response.StatusCode.ToString();
            string content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            // Return result
            if (!string.IsNullOrWhiteSpace(content))
                result.Content = result.Content is string ? content as TResult : JsonConvert.DeserializeObject<TResult>(content);

            return result;
        }

        #endregion

        #region Parameters
        public void AddParameter(string parameter, string argument)
        {
            // Check values
            if (string.IsNullOrWhiteSpace(parameter))
                return;

            // Remove parameter if it exists
            if (_parameters.ContainsKey(parameter)) _parameters.Remove(parameter);

            // Add parameter
            _parameters.Add(parameter, argument);
        }

        private string GetQueryString()
        {
            if (_parameters.Count == 0) return null;

            var query = new StringBuilder();
            query.Append("?");

            int counter = 0;
            foreach (KeyValuePair<string, string> p in _parameters)
            {
                if (counter > 0)
                    query.Append("&");
                query.Append(p.Key);
                query.Append("=");
                query.Append(p.Value);

                counter++;
            }

            return query.ToString();
        }
        #endregion

        private string MountUrl(string resource)
        {
            char[] trimChars = { '/' };
            var url = new StringBuilder();
            resource = resource.TrimEnd(trimChars).TrimStart(trimChars);

            url.Append(_options.GetBaseUrl());
            url.Append("/");
            url.Append(resource);
            url.Append(GetQueryString());

            return url.ToString();
        }
    }
}
