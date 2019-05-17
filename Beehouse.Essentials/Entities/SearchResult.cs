    using System.Collections.Generic;
    using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Beehouse.Essentials.Entities
{
    public class SearchResult<T>
    {
        [JsonIgnore]
        public HttpContext HttpContext { get; set; }
        public ICollection<T> Result { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }
        public int Count { get; set; }
        public string Query { get
            {
                return _pagination.MountQueryString(HttpContext);
            }
        }

        private Pagination _pagination;

        public SearchResult()
        {
            _pagination = new Pagination();
        }

        public string PaginationHtml()
        {
            return PaginationHtml(HttpContext);
        }

        public string PaginationHtml(HttpContext httpContext)
        {
            _pagination.Mount(Page, Limit, Count, httpContext);
            return _pagination.PaginationHtml;
        }

    }
}