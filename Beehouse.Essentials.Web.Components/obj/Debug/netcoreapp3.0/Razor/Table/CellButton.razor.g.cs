#pragma checksum "D:\Source\AuxiliarC_V3_Alpha\Beehouse.Essentials.Web.Components\Table\CellButton.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6f8d96985a5d02b329b9b64924d7077c2f3874cc"
// <auto-generated/>
#pragma warning disable 1591
namespace Beehouse.Essentials.Web.Components.Table
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Beehouse.Essentials.Web.Components.Common;
    public class CellButton : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "RazorAnchor");
            builder.AddAttribute(1, "Style", Action.ToElementStyle());
            builder.AddAttribute(2, "Icon", Action.ToIconClass());
            builder.AddAttribute(3, "Size", "ElementSize.Small");
            builder.AddAttribute(4, "Url", Url);
            builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 5 "D:\Source\AuxiliarC_V3_Alpha\Beehouse.Essentials.Web.Components\Table\CellButton.razor"
           
    [Parameter] ButtonActionType Action { get; set; }
    [Parameter] string Url { get; set; }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
