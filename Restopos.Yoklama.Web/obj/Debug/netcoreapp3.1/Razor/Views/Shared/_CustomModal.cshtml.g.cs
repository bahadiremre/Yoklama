#pragma checksum "C:\Users\bahad\source\repos\Yoklama\Restopos.Yoklama.Web\Views\Shared\_CustomModal.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "32a001ef53e1d1c5ba1fd5080d016b968bbdb8dc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__CustomModal), @"mvc.1.0.view", @"/Views/Shared/_CustomModal.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\bahad\source\repos\Yoklama\Restopos.Yoklama.Web\Views\_ViewImports.cshtml"
using Restopos.Yoklama.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\bahad\source\repos\Yoklama\Restopos.Yoklama.Web\Views\_ViewImports.cshtml"
using Restopos.Yoklama.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"32a001ef53e1d1c5ba1fd5080d016b968bbdb8dc", @"/Views/Shared/_CustomModal.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"06efa2e3a3566d2f9e0ebd2d16229e364d634ffb", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__CustomModal : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<(string Header, string Body)>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""modal fade"" id=""customModal"" tabindex=""-1"" aria-labelledby=""customModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""customModalLabel"">");
#nullable restore
#line 7 "C:\Users\bahad\source\repos\Yoklama\Restopos.Yoklama.Web\Views\Shared\_CustomModal.cshtml"
                                                         Write(Model.Header);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                ");
#nullable restore
#line 13 "C:\Users\bahad\source\repos\Yoklama\Restopos.Yoklama.Web\Views\Shared\_CustomModal.cshtml"
           Write(Model.Body);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Hayır </button>
                <button type=""button"" class=""btn btn-primary"" id=""btnYes"">Evet </button>
            </div>
        </div>
    </div>
</div>




");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<(string Header, string Body)> Html { get; private set; }
    }
}
#pragma warning restore 1591
