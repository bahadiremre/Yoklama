#pragma checksum "C:\Users\bahad\source\repos\Yoklama\Restopos.Yoklama.Web\Views\Panel\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bea9804c3a7ecf49698a34bebf856e7328258e71"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Panel_Index), @"mvc.1.0.view", @"/Views/Panel/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bea9804c3a7ecf49698a34bebf856e7328258e71", @"/Views/Panel/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"06efa2e3a3566d2f9e0ebd2d16229e364d634ffb", @"/Views/_ViewImports.cshtml")]
    public class Views_Panel_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UserDetailViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\bahad\source\repos\Yoklama\Restopos.Yoklama.Web\Views\Panel\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_PanelLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Hoş geldiniz</h1>\r\n\r\n\r\n<table class=\"table table-hover table-sm\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 15 "C:\Users\bahad\source\repos\Yoklama\Restopos.Yoklama.Web\Views\Panel\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 18 "C:\Users\bahad\source\repos\Yoklama\Restopos.Yoklama.Web\Views\Panel\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Surname));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 21 "C:\Users\bahad\source\repos\Yoklama\Restopos.Yoklama.Web\Views\Panel\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Username));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 24 "C:\Users\bahad\source\repos\Yoklama\Restopos.Yoklama.Web\Views\Panel\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.DepartmentName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n\r\n        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 32 "C:\Users\bahad\source\repos\Yoklama\Restopos.Yoklama.Web\Views\Panel\Index.cshtml"
           Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 35 "C:\Users\bahad\source\repos\Yoklama\Restopos.Yoklama.Web\Views\Panel\Index.cshtml"
           Write(Model.Surname);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 38 "C:\Users\bahad\source\repos\Yoklama\Restopos.Yoklama.Web\Views\Panel\Index.cshtml"
           Write(Model.Username);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 41 "C:\Users\bahad\source\repos\Yoklama\Restopos.Yoklama.Web\Views\Panel\Index.cshtml"
           Write(Model.DepartmentName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n\r\n    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UserDetailViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591