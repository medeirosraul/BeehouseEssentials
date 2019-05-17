using Beehouse.Essentials.Entities;
using Beehouse.Essentials.Web.Api;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using __Blazor.Beehouse.Essentials.Web.Views;
using Beehouse.Essentials.Web.Extensions;

namespace Beehouse.Essentials.Web.Views
{
    /// <summary>
    /// Object used to mount list of models/viewmodels
    /// </summary>
    /// <typeparam name="TModel">Model type</typeparam>
    /// <typeparam name="TViewModel">ViewModel type</typeparam>
    public class ModelList<TModel, TViewModel>
        where TViewModel : ViewModelBase<TModel>, new()
    {
        private int _page = 1;

        /// <summary>
        /// Uri where get list
        /// </summary>
        public string Uri { get; set; }

        public int Page {
            get
            {
                return _page;
            }
            set
            {
                _page = value;
            }
        }

        public int Limit { get; set; } = 10;

        public int Count { get; set; }

        /// <summary>
        /// Filters applyed on get list
        /// </summary>
        public ICollection<KeyValuePair<string, string>> Filters { get; set; }

        /// <summary>
        /// Items of the list
        /// </summary>
        public ICollection<TModel> Models { get; set; }

        /// <summary>
        /// Items of the ViewModel type list
        /// </summary>
        public ICollection<TViewModel> ViewModels { get; set; }

        /// <summary>
        /// API used in get operations
        /// </summary>
        public IApiClient ApiClient { get; set; }

        /// <summary>
        /// Init Model List
        /// </summary>
        public ModelList()
        {
            // -- not implemented
        }

        /// <summary>
        /// Init Model List
        /// </summary>
        /// <param name="apiClient">Client used in get operations</param>
        public ModelList(IApiClient apiClient)
        {
            ApiClient = apiClient;
        }

        /// <summary>
        /// Fill items list with api result
        /// </summary>
        /// <returns></returns>
        public async Task FillItemsList()
        {
            ApiClient.AddParameter("page", Page.ToString());
            ApiClient.AddParameter("limit", Limit.ToString());
            if(Filters != null)
                foreach (var filter in Filters)
                    ApiClient.AddParameter(filter.Key, filter.Value);

            var result = await ApiClient.GetAsync<SearchResult<TModel>>(Uri);

            if (result.Status == ApiResultStatus.Error)
                throw new Exception("Não foi possível preencher os items desta lista: " + result.StatusMessage);

            Count = result.Content.Count;
            Models = result.Content.Result;

            // Convert to ViewModel;
            ViewModels = typeof(TModel) == typeof(TViewModel)
                ? (ICollection<TViewModel>)Models
                : Models.Select(model => (TViewModel)(new TViewModel().SetModel(model))).ToList();
        }
    }
}
