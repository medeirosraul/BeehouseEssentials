#pragma checksum "D:\Source\AuxiliarC_V3_Alpha\Beehouse.Essentials.Web.Components\Page\Column.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f68f19358ed984f3a2e2c370f425c41616798004"
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
    using System.Text;
    public class Column : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "div");
            builder.AddAttribute(1, "class", "col" + " " + (Cols()));
            builder.AddMarkupContent(2, "\r\n    ");
            builder.AddContent(3, ChildContent);
            builder.AddMarkupContent(4, "\r\n");
            builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 6 "D:\Source\AuxiliarC_V3_Alpha\Beehouse.Essentials.Web.Components\Page\Column.razor"
 
    [Parameter] RenderFragment ChildContent { get; set; }
    [Parameter] string Xs { get; set; }
    [Parameter] string Sm { get; set; }
    [Parameter] string Md { get; set; }
    [Parameter] string Lg { get; set; }
    [Parameter] string Xl { get; set; }

    private string Cols()
    {
        var cols = new StringBuilder();

        if (string.IsNullOrWhiteSpace(Xs))
        {
            cols.Append($"col-{Xs} ");
        }


        if (string.IsNullOrWhiteSpace(Sm)) { cols.Append($"col-sm-{Sm} "); }
        if (string.IsNullOrWhiteSpace(Md)) { cols.Append($"col-md-{Md} "); }
        if (string.IsNullOrWhiteSpace(Lg)) { cols.Append($"col-lg-{Lg} "); }
        if (string.IsNullOrWhiteSpace(Xl)) { cols.Append($"col-xl-{Xl} "); }

        return cols.ToString();
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
