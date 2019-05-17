using Beehouse.Essentials.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beehouse.Essentials.Web.Views
{
    public static class RazorListExtensions
    {
        public static RazorList<TViewModel> ToListResult<TModel, TViewModel>(this SearchResult<TModel> searchResult)
            where TModel : class
            where TViewModel : ViewModelBase<TModel>, new()
        {
            var list = new RazorList<TViewModel>
            {
                Page = searchResult.Page,
                Limit = searchResult.Limit,
                Count = searchResult.Count,
                Items = searchResult.Result.Select(model => (TViewModel)(new TViewModel().SetModel(model))).ToList()
            };

            return list;
        }
    }
}
