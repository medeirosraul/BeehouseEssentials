#pragma checksum "D:\Source\AuxiliarC_V3_Alpha\Beehouse.Essentials.Web.Components\Table\RazorTable - Cópia.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7de6c5a21d23f6f84cc67e6cc55c1fbe5a0f80b9"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Beehouse.Essentials.Web.Components.Table
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Beehouse.Essentials.Web.Views;
    public class RazorTable___Cópia<TViewModel> : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
        }
        #pragma warning restore 1998
#line 68 "D:\Source\AuxiliarC_V3_Alpha\Beehouse.Essentials.Web.Components\Table\RazorTable - Cópia.razor"
 
    [Parameter] string Title { get; set; }

    [Parameter] RenderFragment Menu { get; set; }

    [Parameter] RenderFragment Header { get; set; }

    [Parameter] RazorList<TViewModel> ListResult { get; set; }
    [Parameter] Action<RazorList<TViewModel>> ListResultChanged { get; set; }

    [Parameter] RenderFragment<TViewModel> RowTemplate { get; set; }

    [Parameter] RenderFragment<TViewModel> ActionsTemplate { get; set; }




#line default
#line hidden
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Microsoft.AspNetCore.Components.Services.IUriHelper uriHelper { get; set; }
    }
}
#pragma warning restore 1591
