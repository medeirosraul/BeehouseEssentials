using Beehouse.Essentials.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beehouse.Essentials.Entities
{
    public class ListResult<TEntity>:List<TEntity> where TEntity : Entity
    {
        public HttpContext HttpContext { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }

        private Pagination _pagination;

        public ListResult()
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
