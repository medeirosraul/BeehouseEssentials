using Microsoft.AspNetCore.Components.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beehouse.Essentials.Web.Views
{
    public class RazorList<TModel>:IBlazorListResult
    {
        public int Page { get; set; } = 1;
        public int Limit { get; set; } = 10;
        public int Count { get; set; } = 0;
        public HttpContext HttpContext { get; set; }
        public RazorListPagination Pagination { get; set; } = new RazorListPagination();
        public ICollection<TModel> Items { get; set; }

        public string GetPaginationHtml()
        {
            return Pagination.GetHtml(Page, Limit, Count, HttpContext);
        }

        public string GetPaginationHtml(IUriHelper uriHelper)
        {
            return Pagination.GetHtml(Page, Limit, Count, uriHelper);
        }
    }
}
