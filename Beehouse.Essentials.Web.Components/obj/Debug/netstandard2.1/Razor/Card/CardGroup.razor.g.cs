#pragma checksum "D:\Source\AuxiliarC_V3_Alpha\Beehouse.Essentials.Web.Components\Card\CardGroup.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "99f9c462473091d2357842a01963b7f8b500b524"
// <auto-generated/>
#pragma warning disable 1591
namespace Beehouse.Essentials.Web.Components.Card
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Forms;
    public class CardGroup : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "div");
            builder.AddAttribute(1, "class", "card-group row");
            builder.AddMarkupContent(2, "\r\n        ");
            builder.AddContent(3, ChildContent);
            builder.AddMarkupContent(4, "\r\n");
            builder.CloseElement();
        }
        #pragma warning restore 1998
#line 5 "D:\Source\AuxiliarC_V3_Alpha\Beehouse.Essentials.Web.Components\Card\CardGroup.razor"
           
    [Parameter] RenderFragment ChildContent { get; set; }

#line default
#line hidden
    }
}
#pragma warning restore 1591