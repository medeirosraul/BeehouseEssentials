using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Beehouse.Essentials.Entities
{
    public class Pagination
    {
        public int PageQuantity { get; set; }
        public string PaginationHtml { get; set; }

        public Pagination()
        {
            
        }

        public void Mount(int page, int limit, int count, HttpContext httpContext)
        {
            // Calc page quantity
            var pageCountFactor = (decimal)count / (decimal)limit;
            PageQuantity = pageCountFactor % 1 != 0 || pageCountFactor < 1
                ? (int)(pageCountFactor - (pageCountFactor % 1) + 1)
                : (int)pageCountFactor;

            // Mount strings
            var uri = "";
            var query = "";

            if (httpContext != null)
            {
                uri = MountUri(httpContext);
                query = MountQueryString(httpContext);
            }

            PaginationHtml = MountHtml(page, limit, uri, query);

        }

        public string MountUri(HttpContext httpContext)
        {
            return httpContext.Request.Path.Value;
        }

        public string MountQueryString(HttpContext httpContext)
        {
            var builder = new StringBuilder();
            foreach (var item in httpContext.Request.Query)
            {
                var isPaginationValue = false;
                switch (item.Key.ToLower())
                {
                    case "page":
                    case "limit":
                        isPaginationValue = true;
                        break;
                    default:
                        isPaginationValue = false;
                        break;
                }

                if (isPaginationValue) continue;

                if (builder.Length > 0)
                    builder.Append("&");

                builder.Append(item.Key.ToLower() + "=" + item.Value);
            }
            var q = builder.ToString();
            return q;
        }

        public string MountHtml(int page, int limit, string uri, string query)
        {
            var html = new StringBuilder();
            var queryAnd = string.IsNullOrWhiteSpace(query) ? "" : "&";

            if (page > 1)
            {
                html.AppendLine($"<li class='page-item'><a class='page-link' href='{uri}{query}{queryAnd}limit={limit}'>Primeira </a></li>");
            }
            var paginationItems = 6;

            var itemInit = page - paginationItems / 2 <= 1 ? 1 : page - paginationItems / 2;

            for (var i = 0; i <= paginationItems; i++)
            {
                var isActive = "";
                var item = itemInit + i;

                if (item == page)
                    isActive = " active";

                if(item <= PageQuantity)
                    html.AppendLine($"<li class='page-item{isActive}'><a class='page-link' href='{uri}?{query}{queryAnd}page={item}&limit={limit}'>" + item + "</a></li>");
            }

            if (page < PageQuantity)
            {
                html.AppendLine($"<li class='page-item'><a class='page-link' href='{uri}{query}{queryAnd}page={PageQuantity}&limit={limit}'>Última</a></li>");
            }

            return html.ToString();
        }
    }
}