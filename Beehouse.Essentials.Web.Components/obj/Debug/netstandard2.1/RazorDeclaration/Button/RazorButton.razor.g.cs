#pragma checksum "D:\Source\AuxiliarC_V3_Alpha\Beehouse.Essentials.Web.Components\Button\RazorButton.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "74bffb64b8ed46e902372c93bb4061b11f6fd9de"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Beehouse.Essentials.Web.Components.Button
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Forms;
    using Beehouse.Essentials.Web.Components.Common;
    using Beehouse.Essentials.Web.Components.Icon;
    public class RazorButton : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
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
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Microsoft.AspNetCore.Components.IUriHelper uriHelper { get; set; }
    }
}
#pragma warning restore 1591
