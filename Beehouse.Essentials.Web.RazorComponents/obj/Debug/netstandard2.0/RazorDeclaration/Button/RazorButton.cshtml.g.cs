#pragma checksum "D:\Source\AuxiliarC_V3_Alpha\Beehouse.Essentials.Web.RazorComponents\Button\RazorButton.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c5529e60446b84411029f0f633bdd17c9beb140a"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Beehouse.Essentials.Web.RazorComponents.Button
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Beehouse.Essentials.Web.Components.Common;
    using Beehouse.Essentials.Web.RazorComponents.Icon;
    public class RazorButton : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
        }
        #pragma warning restore 1998
#line 13 "D:\Source\AuxiliarC_V3_Alpha\Beehouse.Essentials.Web.RazorComponents\Button\RazorButton.cshtml"
           
    [Parameter] RenderFragment ChildContent { get; set; }
    [Parameter] ElementStyle Style { get; set; }
    [Parameter] string Icon { get; set; }
    [Parameter] Action OnClick { get; set; }

    private string _iconSpan;

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
