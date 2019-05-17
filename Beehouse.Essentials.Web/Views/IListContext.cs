using Beehouse.Essentials.Web.Api;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beehouse.Essentials.Web.Views
{
    public interface IListContext<TContext>
    {
        string Uri { get; set; }
        int Page { get; set; }
        int Limit { get; set; }
        int Count { get; set; }
        ICollection<KeyValuePair<string,string>> Filters { get; set; }
        ICollection<TContext> Items {get;set;}
        IApiClient ApiClient { get; set; }
        Task Fill();
    }
}
