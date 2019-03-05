using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Beehouse.Essentials.Blazor.ApiClient
{
    public class ApiClientService:IApiClientService
    {
        const string BaseUri = "http://localhost/5000";

        private readonly BeehouseBlazorOptions _options;
        private readonly HttpClient _httpClient;

        private Dictionary<string, string> _parameters = new Dictionary<string, string>();

        public ApiClientService(IOptionsMonitor<BeehouseBlazorOptions> optionsAccessor, HttpClient httpClient)
        {
            _options = optionsAccessor.CurrentValue;
            _httpClient = httpClient;
            
        }

        public async Task<ApiResult<TResult>> GetAsync<TResult>(string resource) where TResult : class
        {
            // Api result object
            var apiResult = new ApiResult<TResult>();

            // Get full url
            string url = MountUrl(resource);
            Debug.WriteLine("ApiClientService >>>> Url: " + url);

            // Getting
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            //apiResult.StatusCode = response.;
            apiResult.Error = !response.IsSuccessStatusCode;
            apiResult.StatusMessage = response.StatusCode.ToString();

            string responseString = await response.Content.ReadAsStringAsync();
            Debug.WriteLine("ApiClientService >>>> Response: ");
            Debug.WriteLine(responseString);

            // Return result
            TResult result = JsonConvert.DeserializeObject<TResult>(responseString);

            apiResult.Result = result;

            return apiResult;
        }
        
        public async Task<string> GetAsync(string resource)
        {
            // Get full url
            string url = MountUrl(resource);
            Debug.WriteLine("ApiClientService >>>> Url: " + url);

            // Getting
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            string responseString = await response.Content.ReadAsStringAsync();
            Debug.WriteLine("ApiClientService >>>> Response: ");
            Debug.WriteLine(responseString);

            return responseString;
        }

        public async Task<ApiResult<TResult>> PostAsync<TResult>(string resource, TResult entity) where TResult : class
        {
            // Api result object
            var apiResult = new ApiResult<TResult>();

            // Get full url
            string url = MountUrl(resource);
            Debug.WriteLine("ApiClientService >>>> Url: " + url);

            // Getting content
            string jsonContent = JsonConvert.SerializeObject(entity);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            // Posting
            Debug.WriteLine("ApiClientService >>>> Posting content: " + jsonContent);
            HttpResponseMessage response = await _httpClient.PostAsync(url, content);

            //apiResult.StatusCode = response.;
            apiResult.Error = !response.IsSuccessStatusCode;
            apiResult.StatusMessage = response.StatusCode.ToString();

            string responseString = await response.Content.ReadAsStringAsync();
            Debug.WriteLine("ApiClientService >>>> Response: ");
            Debug.WriteLine(responseString);

            // Return result
            TResult result = JsonConvert.DeserializeObject<TResult>(responseString);

            apiResult.Result = result;

            return apiResult;
        }


        public async Task<ApiResult<TResult>> PutAsync<TResult>(string resource, TResult entity) where TResult : class
        {
            // Api result object
            var apiResult = new ApiResult<TResult>();

            // Get full url
            string url = MountUrl(resource);
            Debug.WriteLine("ApiClientService >>>> Url: " + url);

            // Getting content
            string jsonContent = JsonConvert.SerializeObject(entity);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            // Posting
            Debug.WriteLine("ApiClientService >>>> Updating content: " + jsonContent);
            HttpResponseMessage response = await _httpClient.PutAsync(url, content);

            //apiResult.StatusCode = response.;
            apiResult.Error = !response.IsSuccessStatusCode;
            apiResult.StatusMessage = response.StatusCode.ToString();

            string responseString = await response.Content.ReadAsStringAsync();
            Debug.WriteLine("ApiClientService >>>> Response: ");
            Debug.WriteLine(responseString);

            // Return result
            TResult result = JsonConvert.DeserializeObject<TResult>(responseString);

            apiResult.Result = result;

            return apiResult;
        }

        public async Task<ApiResult<bool>> DeleteAsync(string resource, string id)
        {
            var apiResult = new ApiResult<bool>();
            resource = string.IsNullOrWhiteSpace(id) ? resource : resource + "/" + id;

            // Get full url
            string url = MountUrl(resource);
            Debug.WriteLine("ApiClientService >>>> Url: " + url);

            // Getting
            HttpResponseMessage response = await _httpClient.DeleteAsync(url);

            //apiResult.StatusCode = response.;
            apiResult.Error = !response.IsSuccessStatusCode;
            apiResult.Result = response.IsSuccessStatusCode;
            apiResult.StatusMessage = response.StatusCode.ToString();
            
            return apiResult;
        }

        public void AddParameter(string parameter, string argument)
        {
            // Check values
            if (string.IsNullOrWhiteSpace(parameter) || string.IsNullOrWhiteSpace(argument))
                return;

            // Add
            if (_parameters.ContainsKey(parameter)) _parameters.Remove(parameter);
            _parameters.Add(parameter, argument);
        }

        private string MountUrl(string resource)
        {
            char[] trimChars = { '/'};
            var url = new StringBuilder();
            resource = resource.TrimEnd(trimChars).TrimStart(trimChars);

            url.Append(_options.ApiConnection.BaseUrl);
            url.Append("/");
            url.Append(resource);
            url.Append(GetQueryString());
            

            return url.ToString();

        }

        private string GetQueryString()
        {
            if (_parameters.Count == 0) return null;

            var query = new StringBuilder();
            query.Append("?");

            int counter = 0;
            foreach(KeyValuePair<string, string> p in _parameters)
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
    }
}
