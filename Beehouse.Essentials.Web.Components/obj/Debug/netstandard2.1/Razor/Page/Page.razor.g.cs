#pragma checksum "D:\Source\AuxiliarC_V3_Alpha\Beehouse.Essentials.Web.Components\Page\Page.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8ce86632acf5eeee74a3adaa9294de68e0f86b5f"
// <auto-generated/>
#pragma warning disable 1591
namespace Beehouse.Essentials.Web.Components.Page
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Forms;
    using Beehouse.Essentials.Web.Views;
    public class Page : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "div");
            builder.AddAttribute(1, "class", "container container-fluid");
            builder.AddMarkupContent(2, "\r\n    ");
            builder.OpenElement(3, "div");
            builder.AddAttribute(4, "class", "row");
            builder.AddMarkupContent(5, "\r\n        ");
            builder.OpenElement(6, "div");
            builder.AddAttribute(7, "class", "col-12");
            builder.AddMarkupContent(8, "\r\n            ");
            builder.OpenElement(9, "h2");
            builder.AddContent(10, Title);
            builder.CloseElement();
            builder.AddMarkupContent(11, "\r\n        ");
            builder.CloseElement();
            builder.AddMarkupContent(12, "\r\n    ");
            builder.CloseElement();
            builder.AddMarkupContent(13, "\r\n\r\n    ");
            builder.AddContent(14, ChildContent);
            builder.AddMarkupContent(15, "\r\n");
            builder.CloseElement();
        }
        #pragma warning restore 1998
#line 14 "D:\Source\AuxiliarC_V3_Alpha\Beehouse.Essentials.Web.Components\Page\Page.razor"
 
    [Parameter]
    private string Title { get; set; }

    [Parameter]
    private RenderFragment ChildContent { get; set; }

#line default
#line hidden
    }
}
#pragma warning restore 1591