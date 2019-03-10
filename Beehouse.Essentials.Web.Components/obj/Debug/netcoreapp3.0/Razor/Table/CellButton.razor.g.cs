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
            base.BuildRenderTree(builder);
            builder.OpenComponent<Beehouse.Essentials.Web.Components.Button.RazorAnchor>(0);
            builder.AddAttribute(1, "Style", Microsoft.AspNetCore.Components.RuntimeHelpers.TypeCheck<Beehouse.Essentials.Web.Components.Common.ElementStyle>(Action.ToElementStyle()));
            builder.AddAttribute(2, "Icon", Microsoft.AspNetCore.Components.RuntimeHelpers.TypeCheck<System.String>(Action.ToIconClass()));
            builder.AddAttribute(3, "Size", Microsoft.AspNetCore.Components.RuntimeHelpers.TypeCheck<Beehouse.Essentials.Web.Components.Common.ElementSize>(ElementSize.Small));
            builder.AddAttribute(4, "Url", Microsoft.AspNetCore.Components.RuntimeHelpers.TypeCheck<System.String>(Url));
            builder.CloseComponent();
        }
        #pragma warning restore 1998
#line 5 "D:\Source\AuxiliarC_V3_Alpha\Beehouse.Essentials.Web.Components\Table\CellButton.razor"
           
    [Parameter] ButtonActionType Action { get; set; }
    [Parameter] string Url { get; set; }

#line default
#line hidden
    }
}
#pragma warning restore 1591