#pragma checksum "C:\Users\ACER\Desktop\BackendProject\BackendProject\Areas\AdminPanel\Views\Teacher\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9d4f349bba8cebd3de0001e28b9412a840a9b70f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_AdminPanel_Views_Teacher_Detail), @"mvc.1.0.view", @"/Areas/AdminPanel/Views/Teacher/Detail.cshtml")]
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
#line 1 "C:\Users\ACER\Desktop\BackendProject\BackendProject\Areas\AdminPanel\Views\_ViewImports.cshtml"
using BackendProject.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ACER\Desktop\BackendProject\BackendProject\Areas\AdminPanel\Views\_ViewImports.cshtml"
using BackendProject.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9d4f349bba8cebd3de0001e28b9412a840a9b70f", @"/Areas/AdminPanel/Views/Teacher/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0cdad0a2d173cd075249e8b663df17e474702f6c", @"/Areas/AdminPanel/Views/_ViewImports.cshtml")]
    public class Areas_AdminPanel_Views_Teacher_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Teacher>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Alternate Text"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("mb-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "C:\Users\ACER\Desktop\BackendProject\BackendProject\Areas\AdminPanel\Views\Teacher\Detail.cshtml"
  
    ViewData["Title"] = "Detail";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"col-lg-6\">\r\n    <div class=\"card mb-4\">\r\n        <div class=\"card-header\">\r\n            <div class=\"d-flex justify-content-between align-items-center\">\r\n                <div>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9d4f349bba8cebd3de0001e28b9412a840a9b70f5215", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 278, "~/img/teacher/", 278, 14, true);
#nullable restore
#line 13 "C:\Users\ACER\Desktop\BackendProject\BackendProject\Areas\AdminPanel\Views\Teacher\Detail.cshtml"
AddHtmlAttributeValue("", 292, Model.Image, 292, 12, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                <h2 class=\"fs-17 font-weight-600 mb-1\">Fullanme:</h2>");
#nullable restore
#line 14 "C:\Users\ACER\Desktop\BackendProject\BackendProject\Areas\AdminPanel\Views\Teacher\Detail.cshtml"
                                                                Write(Model.Fullanme);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <p class=\"fs-17 font-weight-600 mb-1\">Position:</p>");
#nullable restore
#line 15 "C:\Users\ACER\Desktop\BackendProject\BackendProject\Areas\AdminPanel\Views\Teacher\Detail.cshtml"
                                                              Write(Model.Position);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <p class=\"fs-17 font-weight-600 mb-1\">AboutMe:</p>");
#nullable restore
#line 16 "C:\Users\ACER\Desktop\BackendProject\BackendProject\Areas\AdminPanel\Views\Teacher\Detail.cshtml"
                                                             Write(Model.AboutMe);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <p class=\"fs-17 font-weight-600 mb-1\">Degree:</p>");
#nullable restore
#line 17 "C:\Users\ACER\Desktop\BackendProject\BackendProject\Areas\AdminPanel\Views\Teacher\Detail.cshtml"
                                                            Write(Model.Degree);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <p class=\"fs-17 font-weight-600 mb-1\">EXPERIENCE:</p>");
#nullable restore
#line 18 "C:\Users\ACER\Desktop\BackendProject\BackendProject\Areas\AdminPanel\Views\Teacher\Detail.cshtml"
                                                                Write(Model.EXPERIENCE);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <h6 class=\"fs-17 font-weight-600 mb-1\">HOBBIES:</h6>");
#nullable restore
#line 19 "C:\Users\ACER\Desktop\BackendProject\BackendProject\Areas\AdminPanel\Views\Teacher\Detail.cshtml"
                                                               Write(Model.HOBBIES);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <h6 class=\"fs-17 font-weight-600 mb-1\">FACULTY:</h6>");
#nullable restore
#line 20 "C:\Users\ACER\Desktop\BackendProject\BackendProject\Areas\AdminPanel\Views\Teacher\Detail.cshtml"
                                                               Write(Model.FACULTY);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <h6 class=\"fs-17 font-weight-600 mb-1\">Mail:</h6>");
#nullable restore
#line 21 "C:\Users\ACER\Desktop\BackendProject\BackendProject\Areas\AdminPanel\Views\Teacher\Detail.cshtml"
                                                            Write(Model.Mail);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <h6 class=\"fs-17 font-weight-600 mb-1\">Phone:</h6>");
#nullable restore
#line 22 "C:\Users\ACER\Desktop\BackendProject\BackendProject\Areas\AdminPanel\Views\Teacher\Detail.cshtml"
                                                             Write(Model.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <h6 class=\"fs-17 font-weight-600 mb-1\">Skype:</h6>");
#nullable restore
#line 23 "C:\Users\ACER\Desktop\BackendProject\BackendProject\Areas\AdminPanel\Views\Teacher\Detail.cshtml"
                                                             Write(Model.Skype);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <h6 class=\"fs-17 font-weight-600 mb-1\">TeamLeader:</h6>");
#nullable restore
#line 24 "C:\Users\ACER\Desktop\BackendProject\BackendProject\Areas\AdminPanel\Views\Teacher\Detail.cshtml"
                                                                  Write(Model.TeamLeader);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <h6 class=\"fs-17 font-weight-600 mb-1\">Language:</h6>");
#nullable restore
#line 25 "C:\Users\ACER\Desktop\BackendProject\BackendProject\Areas\AdminPanel\Views\Teacher\Detail.cshtml"
                                                                Write(Model.Language);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <h6 class=\"fs-17 font-weight-600 mb-1\">Design:</h6>");
#nullable restore
#line 26 "C:\Users\ACER\Desktop\BackendProject\BackendProject\Areas\AdminPanel\Views\Teacher\Detail.cshtml"
                                                              Write(Model.Design);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <h6 class=\"fs-17 font-weight-600 mb-1\">Development:</h6>");
#nullable restore
#line 27 "C:\Users\ACER\Desktop\BackendProject\BackendProject\Areas\AdminPanel\Views\Teacher\Detail.cshtml"
                                                                   Write(Model.Development);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <h6 class=\"fs-17 font-weight-600 mb-1\">Innovation:</h6>");
#nullable restore
#line 28 "C:\Users\ACER\Desktop\BackendProject\BackendProject\Areas\AdminPanel\Views\Teacher\Detail.cshtml"
                                                                  Write(Model.Innovation);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <h6 class=\"fs-17 font-weight-600 mb-1\">Communication:</h6>");
#nullable restore
#line 29 "C:\Users\ACER\Desktop\BackendProject\BackendProject\Areas\AdminPanel\Views\Teacher\Detail.cshtml"
                                                                     Write(Model.Communication);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9d4f349bba8cebd3de0001e28b9412a840a9b70f12891", async() => {
                WriteLiteral("Cancel");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Teacher> Html { get; private set; }
    }
}
#pragma warning restore 1591
