using Microsoft.AspNetCore.Components.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Beehouse.Essentials.Web.Views
{
    public class RazorListPagination
    {
        public string GetHtml(int page, int limit, int count, HttpContext httpContext)
        {
            // Get some data
            string baseUrl = httpContext.Request.Path.Value;
            string filters = GetQueryStringFilters(httpContext.Request.Query);

            return GetHtml(page, limit, count, baseUrl, filters);
        }

        public string GetHtml(int page, int limit, int count, IUriHelper uriHelper)
        {
            var uri = new Uri(uriHelper.GetAbsoluteUri());
            string baseUrl = uriHelper.GetAbsoluteUri().Split('?')[0];
            string filters = GetQueryStringFilters(uri);

            return GetHtml(page, limit, count, baseUrl, filters);
        }

        public string GetHtml(int page, int limit, int count, string baseUrl, string filters)
        {
            // Init some variables
            int maxItems = 6;
            int initItemPage = page - maxItems / 2 <= 1 ? 1 : page - maxItems / 2;

            // Calc page quantity
            var pageCountFactor = (decimal)count / (decimal)limit;
            int pageQuantity = pageCountFactor % 1 != 0 || pageCountFactor < 1
                ? (int)(pageCountFactor - (pageCountFactor % 1) + 1)
                : (int)pageCountFactor;

            // Builder instance
            var builder = new StringBuilder();

            // Open tags
            builder.AppendLine("<nav aria-label=\"...\">");
            builder.AppendLine("    <ul class=\"pagination\">");

            // Add first item
            builder.AppendLine($"       {GetFirstItem(page, limit, baseUrl, filters)}");

            // Add items
            for (int i = 0; i <= maxItems; i++)
            {
                int current = initItemPage + i;

                if (current == page)
                    builder.AppendLine($"           {GetCurrentItem(current)}");
                else
                    if(current <= pageQuantity)
                        builder.AppendLine($"           {GetItem(current, limit, baseUrl, filters)}");
            }

            // Add last item
            builder.AppendLine($"           {GetLastItem(pageQuantity, limit, baseUrl, filters)}");

            // Close tags
            builder.AppendLine("    </ul>");
            builder.AppendLine("</nav>");

            return builder.ToString();
        }

        public string GetFirstItem(int page, int limit, string baseUrl, string filters)
        {
            var builder = new StringBuilder();

            bool current = page == 1;
            string disabled = current ? "disabled" : "";
            string uri = $"{baseUrl}?page=1&limit={limit}{filters}";
            string buttonTag = current ? $"<span class=\"page-link\">Primeira</span>" : $"<a class=\"page-link\" href=\"{uri}\">Primeira</a>";

            builder.AppendLine($"<li class='page-item {disabled}'>{buttonTag}</li>");
            return builder.ToString();
        }

        public string GetLastItem(int pageQuantity, int limit, string baseUrl, string filters)
        {
            var builder = new StringBuilder();

            bool current = pageQuantity == 1;
            string disabled = current ? "disabled" : "";
            string uri = $"{baseUrl}?page={pageQuantity}&limit={limit}{filters}";
            string buttonTag = current ? $"<span class=\"page-link\">Última</span>" : $"<a class=\"page-link\" href=\"{uri}\">Última</a>";

            builder.AppendLine($"<li class=\"page-item {disabled}\">{buttonTag}</li>");
            return builder.ToString();
        }

        public string GetCurrentItem(int page)
        {
            var builder = new StringBuilder();

            string buttonTag = $"<span class=\"page-link\">{page}<span class=\"sr-only\">(current)</span></span>";

            builder.AppendLine($"<li class=\"page-item active\" aria-current=\"page\">{buttonTag}</li>");
            return builder.ToString();
        }

        public string GetItem(int page, int limit, string baseUrl, string filters)
        {
            string uri = $"{baseUrl}?page={page}&limit={limit}{filters}";
            string buttonTag = $"<a class=\"page-link\" href=\"{uri}\">{page}</a>";
            string listItemTag = $"<li class='page-item'>{buttonTag}</li>";
            return listItemTag;
        }

        public string GetQueryStringFilters(IQueryCollection queryCollection)
        {
            var builder = new StringBuilder();

            // Check all query items
            foreach (var item in queryCollection)
            {
                // Check if is pagination value (page, limit, etc) and not a filter
                if (IsPaginationValue(item.Key)) continue;

                // Append &
                builder.Append("&");

                // Append filter to querystring
                builder.Append(item.Key.ToLower() + "=" + item.Value);
            }

            // Returns querystring
            return builder.ToString();
        }

        public string GetQueryStringFilters(Uri uri)
        {
            Dictionary<string, StringValues> query = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(uri.Query);

            var builder = new StringBuilder();

            // Check all query items
            foreach (var item in query)
            {
                // Check if is pagination value (page, limit, etc) and not a filter
                if (IsPaginationValue(item.Key)) continue;

                // Append &
                builder.Append("&");

                // Append filter to querystring
                builder.Append(item.Key.ToLower() + "=" + item.Value);
            }

            // Returns querystring
            return builder.ToString();
        }

        private bool IsPaginationValue(string s)
        {
            switch (s)
            {
                case "page":
                case "limit":
                    return true;
                default:
                    return false;
            }
        }
    }
}
