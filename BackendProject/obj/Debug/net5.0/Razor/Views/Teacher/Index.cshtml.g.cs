#pragma checksum "C:\Users\ACER\Desktop\BackendProject\BackendProject\Views\Teacher\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "af5499851cdb711f43efaa89d08afdbc613fd547"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Teacher_Index), @"mvc.1.0.view", @"/Views/Teacher/Index.cshtml")]
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
#line 1 "C:\Users\ACER\Desktop\BackendProject\BackendProject\Views\_ViewImports.cshtml"
using BackendProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ACER\Desktop\BackendProject\BackendProject\Views\_ViewImports.cshtml"
using BackendProject.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ACER\Desktop\BackendProject\BackendProject\Views\_ViewImports.cshtml"
using BackendProject.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"af5499851cdb711f43efaa89d08afdbc613fd547", @"/Views/Teacher/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"34361eeca8f809117d889d92f2a2f5a8d728906c", @"/Views/_ViewImports.cshtml")]
    public class Views_Teacher_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Teacher>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("search"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("#"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Detail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\ACER\Desktop\BackendProject\BackendProject\Views\Teacher\Index.cshtml"
  
    ViewData["Title"] = "Index";
    var controller = ViewContext.RouteData.Values["controller"].ToString();

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!-- Banner Area Start -->\r\n");
#nullable restore
#line 8 "C:\Users\ACER\Desktop\BackendProject\BackendProject\Views\Teacher\Index.cshtml"
Write(await Component.InvokeAsync("Bunner"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@";
<!-- Banner Area End -->
<!-- Teacher Start -->
<div class=""teacher-area pt-50 pb-105"">
    <div class=""container"">
        <div class=""row"">
            <div class=""row"">
                <div class=""col-xs-12"">
                    <div class=""course-title"">
                        <h3>search courses</h3>
                    </div>
                    <div class=""course-form"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "af5499851cdb711f43efaa89d08afdbc613fd5475518", async() => {
                WriteLiteral("\r\n                            <input id=\"input-search\" type=\"search\" placeholder=\"Search...\" name=\"search\" />\r\n                            <input type=\"hidden\" name=\"name\"");
                BeginWriteAttribute("value", " value=\"", 826, "\"", 845, 1);
#nullable restore
#line 22 "C:\Users\ACER\Desktop\BackendProject\BackendProject\Views\Teacher\Index.cshtml"
WriteAttributeValue("", 834, controller, 834, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" id=\"controller\" />\r\n                            <button type=\"submit\">search</button>\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n            <div class=\"row\" id=\"old\">\r\n");
#nullable restore
#line 29 "C:\Users\ACER\Desktop\BackendProject\BackendProject\Views\Teacher\Index.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"col-md-3 col-sm-4 col-xs-12\">\r\n                        <div class=\"single-teacher mb-45\">\r\n                            <div class=\"single-teacher-img\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "af5499851cdb711f43efaa89d08afdbc613fd5478198", async() => {
                WriteLiteral("<img");
                BeginWriteAttribute("src", " src=\"", 1388, "\"", 1417, 2);
                WriteAttributeValue("", 1394, "img/teacher/", 1394, 12, true);
#nullable restore
#line 34 "C:\Users\ACER\Desktop\BackendProject\BackendProject\Views\Teacher\Index.cshtml"
WriteAttributeValue("", 1406, item.Image, 1406, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" alt=\"teacher\">");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n                            <div class=\"single-teacher-content text-center\">\r\n                                <h2>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "af5499851cdb711f43efaa89d08afdbc613fd5479975", async() => {
#nullable restore
#line 37 "C:\Users\ACER\Desktop\BackendProject\BackendProject\Views\Teacher\Index.cshtml"
                                                      Write(item.Fullanme);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</h2>\r\n                                <h4>");
#nullable restore
#line 38 "C:\Users\ACER\Desktop\BackendProject\BackendProject\Views\Teacher\Index.cshtml"
                               Write(item.Position);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                                <ul>\r\n                                    <li><a");
            BeginWriteAttribute("href", " href=\"", 1774, "\"", 1798, 1);
#nullable restore
#line 40 "C:\Users\ACER\Desktop\BackendProject\BackendProject\Views\Teacher\Index.cshtml"
WriteAttributeValue("", 1781, item.FacebookUrl, 1781, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"zmdi zmdi-facebook\"></i></a></li>\r\n                                    <li><a");
            BeginWriteAttribute("href", " href=\"", 1887, "\"", 1912, 1);
#nullable restore
#line 41 "C:\Users\ACER\Desktop\BackendProject\BackendProject\Views\Teacher\Index.cshtml"
WriteAttributeValue("", 1894, item.PinterestUrl, 1894, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"zmdi zmdi-pinterest\"></i></a></li>\r\n                                    <li><a");
            BeginWriteAttribute("href", " href=\"", 2002, "\"", 2026, 1);
#nullable restore
#line 42 "C:\Users\ACER\Desktop\BackendProject\BackendProject\Views\Teacher\Index.cshtml"
WriteAttributeValue("", 2009, item.LinkedinUrl, 2009, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"zmdi zmdi-linkedin\"></i></a></li>\r\n                                    <li><a");
            BeginWriteAttribute("href", " href=\"", 2115, "\"", 2138, 1);
#nullable restore
#line 43 "C:\Users\ACER\Desktop\BackendProject\BackendProject\Views\Teacher\Index.cshtml"
WriteAttributeValue("", 2122, item.TwitterUrl, 2122, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"zmdi zmdi-twitter\"></i></a></li>\r\n                                </ul>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 48 "C:\Users\ACER\Desktop\BackendProject\BackendProject\Views\Teacher\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n            <div class=\"row\" id=\"new\">\r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n<!-- Teacher End -->\r\n<!-- Subscribe Start -->\r\n");
#nullable restore
#line 58 "C:\Users\ACER\Desktop\BackendProject\BackendProject\Views\Teacher\Index.cshtml"
Write(await Component.InvokeAsync("Subscribe"));

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n<!-- Subscribe End -->\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Teacher>> Html { get; private set; }
    }
}
#pragma warning restore 1591
