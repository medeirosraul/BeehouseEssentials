using Beehouse.Essentials.Entities;
using Beehouse.Essentials.Web.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beehouse.Essentials.Web.Views
{
    public class ListContext<TViewModel, TModel> : IListContext<TViewModel> where TViewModel: ViewModelBase<TModel>, new()
    {
        public string Uri { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }
        public int Count { get; set; }

        /// <summary>
        /// Filters
        /// </summary>
        public ICollection<KeyValuePair<string, string>> Filters { get; set; }

        /// <summary>
        /// Items
        /// </summary>
        public ICollection<TViewModel> Items { get; set; }

        /// <summary>
        /// API used in get operations
        /// </summary>
        public IApiClient ApiClient { get; set; }

        /// <summary>
        /// Fill items list with api result
        /// </summary>
        public async Task Fill()
        {
            if (ApiClient == null)
                throw new Exception("ApiClient não pode ser nulo.");
            ApiClient.AddParameter("page", Page.ToString());
            ApiClient.AddParameter("limit", Limit.ToString());

            if (Filters != null)
                foreach (var filter in Filters)
                    ApiClient.AddParameter(filter.Key, filter.Value);

            var result = await ApiClient.GetAsync<SearchResult<TModel>>(Uri).ConfigureAwait(false);

            if (result.Status == ApiResultStatus.Error)
                throw new Exception("Não foi possível preencher os items desta lista: " + result.StatusMessage);

            if (result.Content == null)
                throw new Exception("Nenhum conteúdo retornado.");

            Count = result.Content.Count;
            var models = result.Content.Result;

            // Convert to ViewModel;
            Items = typeof(TModel) == typeof(TViewModel)
                ? (ICollection<TViewModel>)models
                : models.Select(model => (TViewModel)(new TViewModel().SetModel(model))).ToList();
        }
    }
}
