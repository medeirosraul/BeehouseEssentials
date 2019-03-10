#pragma checksum "D:\Source\AuxiliarC_V3_Alpha\Beehouse.Essentials.Web.Components\Button\RazorButton.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6af1b23aad8a88e1d7e7c2d8b1198717cc41ab29"
// <auto-generated/>
#pragma warning disable 1591
namespace Beehouse.Essentials.Web.Components.Button
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Beehouse.Essentials.Web.Components.Common;
    using Beehouse.Essentials.Web.Components.Icon;
    public class RazorButton : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            builder.OpenElement(0, "button");
            builder.AddAttribute(1, "class", "btn" + " btn-" + (Style.ToClassString()) + " mr-2");
            builder.AddAttribute(2, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.UIMouseEventArgs>(this, OnClick));
            builder.AddContent(3, "\r\n");
#line 6 "D:\Source\AuxiliarC_V3_Alpha\Beehouse.Essentials.Web.Components\Button\RazorButton.razor"
     if (!string.IsNullOrWhiteSpace(Icon))
    {

#line default
#line hidden
            builder.AddContent(4, "        ");
            builder.OpenComponent<Beehouse.Essentials.Web.Components.Icon.Icon>(5);
            builder.AddAttribute(6, "Name", Microsoft.AspNetCore.Components.RuntimeHelpers.TypeCheck<System.String>(Icon));
            builder.CloseComponent();
            builder.AddContent(7, "\r\n");
#line 9 "D:\Source\AuxiliarC_V3_Alpha\Beehouse.Essentials.Web.Components\Button\RazorButton.razor"
    }

#line default
#line hidden
            builder.AddContent(8, "    ");
            builder.AddContent(9, ChildContent);
            builder.AddContent(10, "\r\n");
            builder.CloseElement();
        }
        #pragma warning restore 1998
#line 13 "D:\Source\AuxiliarC_V3_Alpha\Beehouse.Essentials.Web.Components\Button\RazorButton.razor"
           
    [Parameter] RenderFragment ChildContent { get; set; }
    [Parameter] ElementStyle Style { get; set; }
    [Parameter] string Icon { get; set; }
    [Parameter] Action OnClick { get; set; }
    protected override Task OnInitAsync()
    {
        //if (OnClick == null)
        //    OnClick = async () => await OnClickAsync();

        return base.OnInitAsync();
    }

#line default
#line hidden
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Microsoft.AspNetCore.Components.Services.IUriHelper uriHelper { get; set; }
    }
}
#pragma warning restore 1591