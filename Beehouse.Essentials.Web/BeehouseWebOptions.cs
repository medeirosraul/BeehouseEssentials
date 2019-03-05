using System;
using System.Collections.Generic;
using System.Text;

namespace Beehouse.Essentials.Web
{
    public class BeehouseWebOptions
    {
        Dictionary<string, string> ApiLocations = new Dictionary<string, string>();
        Dictionary<string, string> ApiResources = new Dictionary<string, string>();
        private string _defaultUrl = "localhost";

        public void AddApiLocation(string key, string url, bool isDefault = false)
        {
            ApiLocations.Add(key, url);
            if (isDefault)
                _defaultUrl = key;
        }

        public void AddApiResource(string key, string uri)
        {
            ApiResources.Add(key, uri);
        }

        public string GetBaseUrl(string key)
        {
            return ApiLocations[key];
        }

        public string GetBaseUrl()
        {
            return ApiLocations[_defaultUrl];
        }
    }
}
