using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;

namespace Beehouse.Essentials.Web.Extensions
{
    public static class UriHelperExtensions
    {
        public static string GetQueryParameterValue(this IUriHelper uriHelper, string key)
        {
            var uri = new Uri(uriHelper.GetAbsoluteUri());
            Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(uri.Query).TryGetValue(key, out var value);
            return value;
        }

        public static Dictionary<string, StringValues> GetQueryParameters(this IUriHelper uriHelper)
        {
            var uri = new Uri(uriHelper.GetAbsoluteUri());
            return Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(uri.Query);
        }
    }
}
