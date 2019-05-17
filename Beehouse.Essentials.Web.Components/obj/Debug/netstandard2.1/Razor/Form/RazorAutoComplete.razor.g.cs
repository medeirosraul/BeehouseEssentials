#pragma checksum "D:\Source\AuxiliarC_V3_Alpha\Beehouse.Essentials.Web.Components\Form\RazorAutoComplete.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0411ae3de4c72fe0d35a9c4cc43747ca3fe05c26"
// <auto-generated/>
#pragma warning disable 1591
namespace Beehouse.Essentials.Web.Components.Form
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Forms;
    using System.Linq.Expressions;
    public class RazorAutoComplete : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "div");
            builder.AddAttribute(1, "class", "form-group");
            builder.AddMarkupContent(2, "\r\n    ");
            builder.OpenElement(3, "label");
            builder.AddAttribute(4, "class", "form-label");
            builder.AddContent(5, Label);
            builder.CloseElement();
            builder.AddMarkupContent(6, "\r\n    ");
            builder.OpenElement(7, "div");
            builder.AddAttribute(8, "class", "input-group");
            builder.AddMarkupContent(9, "\r\n");
#line 7 "D:\Source\AuxiliarC_V3_Alpha\Beehouse.Essentials.Web.Components\Form\RazorAutoComplete.razor"
         if (IsSelected)
        {

#line default
#line hidden
            builder.AddContent(10, "            ");
            builder.OpenElement(11, "Input");
            builder.AddAttribute(12, "class", "form-control");
            builder.AddAttribute(13, "disabled", true);
            builder.AddAttribute(14, "value", Microsoft.AspNetCore.Components.BindMethods.GetValue(Argument));
            builder.AddAttribute(15, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => Argument = __value, Argument));
            builder.CloseElement();
            builder.AddMarkupContent(16, "\r\n");
#line 10 "D:\Source\AuxiliarC_V3_Alpha\Beehouse.Essentials.Web.Components\Form\RazorAutoComplete.razor"
        }
        else
        {

#line default
#line hidden
            builder.AddContent(17, "            ");
            builder.OpenElement(18, "Input");
            builder.AddAttribute(19, "class", "form-control");
            builder.AddAttribute(20, "value", Microsoft.AspNetCore.Components.BindMethods.GetValue(Argument));
            builder.AddAttribute(21, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => Argument = __value, Argument));
            builder.CloseElement();
            builder.AddMarkupContent(22, "\r\n");
#line 14 "D:\Source\AuxiliarC_V3_Alpha\Beehouse.Essentials.Web.Components\Form\RazorAutoComplete.razor"
        }

#line default
#line hidden
            builder.AddContent(23, "        ");
            builder.OpenElement(24, "div");
            builder.AddAttribute(25, "class", "input-group-append");
            builder.AddMarkupContent(26, "\r\n");
#line 16 "D:\Source\AuxiliarC_V3_Alpha\Beehouse.Essentials.Web.Components\Form\RazorAutoComplete.razor"
             if (IsSelected)
            {

#line default
#line hidden
            builder.AddContent(27, "                ");
            builder.OpenElement(28, "button");
            builder.AddAttribute(29, "class", "btn btn-danger");
            builder.AddAttribute(30, "type", "button");
            builder.AddAttribute(31, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.UIMouseEventArgs>(this, async () => await OnClearClick()));
            builder.AddContent(32, "Limpar");
            builder.CloseElement();
            builder.AddMarkupContent(33, "\r\n");
#line 19 "D:\Source\AuxiliarC_V3_Alpha\Beehouse.Essentials.Web.Components\Form\RazorAutoComplete.razor"
            }
            else
            {

#line default
#line hidden
            builder.AddContent(34, "                ");
            builder.OpenElement(35, "button");
            builder.AddAttribute(36, "class", "btn btn-primary");
            builder.AddAttribute(37, "type", "button");
            builder.AddAttribute(38, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.UIMouseEventArgs>(this, OnSearchClick));
            builder.AddContent(39, "Buscar");
            builder.CloseElement();
            builder.AddMarkupContent(40, "\r\n");
#line 23 "D:\Source\AuxiliarC_V3_Alpha\Beehouse.Essentials.Web.Components\Form\RazorAutoComplete.razor"
            }

#line default
#line hidden
            builder.AddMarkupContent(41, "\r\n        ");
            builder.CloseElement();
            builder.AddMarkupContent(42, "\r\n    ");
            builder.CloseElement();
            builder.AddMarkupContent(43, "\r\n    ");
            builder.AddMarkupContent(44, "<small class=\"form-text text-muted\">Digite o termo da busca e clique em \"Buscar\" para mostrar os resultados</small>\r\n    ");
            builder.OpenElement(45, "div");
            builder.AddAttribute(46, "class", "overflow-visible" + " " + (ListVisible ? "visible" : "invisible"));
            builder.AddAttribute(47, "style", "height:5px;");
            builder.AddMarkupContent(48, "\r\n        ");
            builder.OpenElement(49, "div");
            builder.AddAttribute(50, "class", "list-group");
            builder.AddMarkupContent(51, "\r\n");
#line 30 "D:\Source\AuxiliarC_V3_Alpha\Beehouse.Essentials.Web.Components\Form\RazorAutoComplete.razor"
             if (IsLoading)
            {


#line default
#line hidden
            builder.AddContent(52, "                ");
            builder.AddMarkupContent(53, "<button class=\"list-group-item list-group-item-action\" type=\"button\" style=\"z-index:2000\" disabled><RazorLoading></RazorLoading></button>\r\n");
#line 34 "D:\Source\AuxiliarC_V3_Alpha\Beehouse.Essentials.Web.Components\Form\RazorAutoComplete.razor"

            }
            else if (ListData == null)
            {

#line default
#line hidden
            builder.AddContent(54, "                ");
            builder.AddMarkupContent(55, "<button class=\"list-group-item list-group-item-action\" type=\"button\" style=\"z-index:2000\" disabled><span class=\"text-muted\">nenhum resultado</span></button>\r\n");
#line 39 "D:\Source\AuxiliarC_V3_Alpha\Beehouse.Essentials.Web.Components\Form\RazorAutoComplete.razor"
            }
            else
            {
                

#line default
#line hidden
#line 42 "D:\Source\AuxiliarC_V3_Alpha\Beehouse.Essentials.Web.Components\Form\RazorAutoComplete.razor"
                 foreach (var item in ListData)
                {

#line default
#line hidden
            builder.AddContent(56, "                    ");
            builder.OpenElement(57, "button");
            builder.AddAttribute(58, "class", "list-group-item list-group-item-action");
            builder.AddAttribute(59, "type", "button");
            builder.AddAttribute(60, "style", "z-index:2000");
            builder.AddAttribute(61, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.UIMouseEventArgs>(this, async () => await ItemSelected(item.Key, item.Value)));
            builder.AddContent(62, item.Value);
            builder.CloseElement();
            builder.AddMarkupContent(63, "\r\n");
#line 45 "D:\Source\AuxiliarC_V3_Alpha\Beehouse.Essentials.Web.Components\Form\RazorAutoComplete.razor"
                }

#line default
#line hidden
#line 45 "D:\Source\AuxiliarC_V3_Alpha\Beehouse.Essentials.Web.Components\Form\RazorAutoComplete.razor"
                 
            }

#line default
#line hidden
            builder.AddContent(64, "            ");
            builder.OpenElement(65, "button");
            builder.AddAttribute(66, "class", "list-group-item list-group-item-action text-muted text-center");
            builder.AddAttribute(67, "type", "button");
            builder.AddAttribute(68, "style", "z-index:2000");
            builder.AddAttribute(69, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.UIMouseEventArgs>(this, CloseList));
            builder.AddContent(70, "Fechar");
            builder.CloseElement();
            builder.AddMarkupContent(71, "\r\n        ");
            builder.CloseElement();
            builder.AddMarkupContent(72, "\r\n    ");
            builder.CloseElement();
            builder.AddMarkupContent(73, "\r\n");
            builder.CloseElement();
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
    [Parameter] EventCallback<string> OnItemSelected { get; set; }
    [Parameter] Func<Task> OnSearchClick { get; set; }

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
        await OnItemSelected.InvokeAsync(key);

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
        await OnItemSelected.InvokeAsync("");

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
