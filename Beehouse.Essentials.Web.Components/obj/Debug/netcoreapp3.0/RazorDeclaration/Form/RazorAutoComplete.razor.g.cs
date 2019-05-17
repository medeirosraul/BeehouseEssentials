#pragma checksum "D:\Source\AuxiliarC_V3_Alpha\Beehouse.Essentials.Web.Components\Form\RazorAutoComplete.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "049e20d9206dab1e2dd7cf16d252c8efb313a2d4"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Beehouse.Essentials.Web.Components.Form
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using System.Linq.Expressions;
    public class RazorAutoComplete : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
        }
        #pragma warning restore 1998
#line 51 "D:\Source\AuxiliarC_V3_Alpha\Beehouse.Essentials.Web.Components\Form\RazorAutoComplete.razor"
           
        // Value parameters
    [Parameter] string Value { get; set; }
    [Parameter] EventCallback<string> ValueChanged { get; set; }
    [Parameter] Expression<Func<string>> ValueExpression { get; set; }

    // Argument parameters
    [Parameter] string Argument { get; set; }
    [Parameter] EventCallback<string> ArgumentChanged { get; set; }

    // Other parameters
    [Parameter] string Label { get; set; }
    [Parameter] string SearchUrl { get; set; }
    [Parameter] ICollection<KeyValuePair<string, string>> ListData { get; set; }

    // Events
    [Parameter] Func<Task> OnSearchClick { get; set; }
    [Parameter] Func<Task> OnSelectItem { get; set; }

    // State properties
    protected bool IsLoading { get; set; } = false;
    protected bool IsSelected { get; set; } = false;
    protected bool ListVisible { get; set; } = false;

    protected override async Task OnInitAsync()
    {
        if (!string.IsNullOrWhiteSpace(SearchUrl))
        {
            OnSearchClick += async () => await Search();
        }

        if (!string.IsNullOrWhiteSpace(Value))
        {
            await GetItem(Value);
        }
    }

    private async Task Search()
    {
        ListVisible = true;
        IsLoading = true;

        _apiClient.AddParameter("argument", Argument);
        var resultList = await _apiClient.GetAsync<ICollection<KeyValuePair<string, string>>>(SearchUrl);

        IsLoading = false;
        if (resultList == null || resultList.Content == null)
        {
            return;
        }
        ListData = resultList.Content;
    }

    private async Task GetItem(string value)
    {
        _apiClient.AddParameter("value", value);
        var resultList = await _apiClient.GetAsync<ICollection<KeyValuePair<string, string>>>(SearchUrl);
        var list = resultList?.Content;

        if (list == null || list.Count == 0)
        {
            await OnClearClick();
        }
        

        var item = list.First();

        await ItemSelected(item.Key, item.Value);
    }

    private async Task ItemSelected(string key, string value)
    {
        // Apply selected values
        Value = key;
        Argument = value;
        await ValueChanged.InvokeAsync(key);
        await ArgumentChanged.InvokeAsync(value);

        // Is selected
        IsSelected = true;

        // Close list div
        CloseList();
    }

    private async Task OnClearClick()
    {
        Value = "";
        Argument = "";
        await ValueChanged.InvokeAsync("");
        await ArgumentChanged.InvokeAsync("");

        IsSelected = false;
    }

    private void CloseList()
    {
        ListVisible = false;
        ListData = null;
    }

#line default
#line hidden
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Beehouse.Essentials.Web.Api.IApiClient _apiClient { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Microsoft.AspNetCore.Components.IUriHelper uriHelper { get; set; }
    }
}
#pragma warning restore 1591
