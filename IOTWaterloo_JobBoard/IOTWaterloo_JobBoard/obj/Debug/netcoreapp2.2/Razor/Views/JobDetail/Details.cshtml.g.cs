#pragma checksum "A:\IoT-Waterloo Job Board\IoT-Waterloo-Job-Board\IOTWaterloo_JobBoard\IOTWaterloo_JobBoard\Views\JobDetail\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "394b8b21a7720329597fd91b95455b50e390d939"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_JobDetail_Details), @"mvc.1.0.view", @"/Views/JobDetail/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/JobDetail/Details.cshtml", typeof(AspNetCore.Views_JobDetail_Details))]
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
#line 1 "A:\IoT-Waterloo Job Board\IoT-Waterloo-Job-Board\IOTWaterloo_JobBoard\IOTWaterloo_JobBoard\Views\_ViewImports.cshtml"
using IOTWaterloo_JobBoard;

#line default
#line hidden
#line 2 "A:\IoT-Waterloo Job Board\IoT-Waterloo-Job-Board\IOTWaterloo_JobBoard\IOTWaterloo_JobBoard\Views\_ViewImports.cshtml"
using IOTWaterloo_JobBoard.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"394b8b21a7720329597fd91b95455b50e390d939", @"/Views/JobDetail/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d37f6272f09165ee68874f5abc71bc06c4f70fe", @"/Views/_ViewImports.cshtml")]
    public class Views_JobDetail_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IOTWaterloo_JobBoard.Models.JobDetails>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-white text-decoration-none"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(24, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(73, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "A:\IoT-Waterloo Job Board\IoT-Waterloo-Job-Board\IOTWaterloo_JobBoard\IOTWaterloo_JobBoard\Views\JobDetail\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(118, 531, true);
            WriteLiteral(@"    <div>
        &nbsp;
        <h4 class=""text-center"">Details of Job Details</h4>
       
    </div>
<div class=""container"">
    <div>

        <div class=""container"">
            <div class=""container-fluid"">
                <div class=""border rounded font-weight-bold text-justify p-4 "">
                    <div class=""row"">
                        <div class=""col-md-11"">

                            <dl class=""row"">
                                <dt class=""col-sm-5"">
                                    ");
            EndContext();
            BeginContext(650, 44, false);
#line 23 "A:\IoT-Waterloo Job Board\IoT-Waterloo-Job-Board\IOTWaterloo_JobBoard\IOTWaterloo_JobBoard\Views\JobDetail\Details.cshtml"
                               Write(Html.DisplayNameFor(model => model.JobTitle));

#line default
#line hidden
            EndContext();
            BeginContext(694, 132, true);
            WriteLiteral("\r\n                                </dt>\r\n                                <dd class=\"col-sm-5\">\r\n                                    ");
            EndContext();
            BeginContext(827, 40, false);
#line 26 "A:\IoT-Waterloo Job Board\IoT-Waterloo-Job-Board\IOTWaterloo_JobBoard\IOTWaterloo_JobBoard\Views\JobDetail\Details.cshtml"
                               Write(Html.DisplayFor(model => model.JobTitle));

#line default
#line hidden
            EndContext();
            BeginContext(867, 132, true);
            WriteLiteral("\r\n                                </dd>\r\n                                <dt class=\"col-sm-5\">\r\n                                    ");
            EndContext();
            BeginContext(1000, 44, false);
#line 29 "A:\IoT-Waterloo Job Board\IoT-Waterloo-Job-Board\IOTWaterloo_JobBoard\IOTWaterloo_JobBoard\Views\JobDetail\Details.cshtml"
                               Write(Html.DisplayNameFor(model => model.Category));

#line default
#line hidden
            EndContext();
            BeginContext(1044, 132, true);
            WriteLiteral("\r\n                                </dt>\r\n                                <dd class=\"col-sm-5\">\r\n                                    ");
            EndContext();
            BeginContext(1177, 40, false);
#line 32 "A:\IoT-Waterloo Job Board\IoT-Waterloo-Job-Board\IOTWaterloo_JobBoard\IOTWaterloo_JobBoard\Views\JobDetail\Details.cshtml"
                               Write(Html.DisplayFor(model => model.Category));

#line default
#line hidden
            EndContext();
            BeginContext(1217, 132, true);
            WriteLiteral("\r\n                                </dd>\r\n                                <dt class=\"col-sm-5\">\r\n                                    ");
            EndContext();
            BeginContext(1350, 44, false);
#line 35 "A:\IoT-Waterloo Job Board\IoT-Waterloo-Job-Board\IOTWaterloo_JobBoard\IOTWaterloo_JobBoard\Views\JobDetail\Details.cshtml"
                               Write(Html.DisplayNameFor(model => model.Location));

#line default
#line hidden
            EndContext();
            BeginContext(1394, 132, true);
            WriteLiteral("\r\n                                </dt>\r\n                                <dd class=\"col-sm-5\">\r\n                                    ");
            EndContext();
            BeginContext(1527, 40, false);
#line 38 "A:\IoT-Waterloo Job Board\IoT-Waterloo-Job-Board\IOTWaterloo_JobBoard\IOTWaterloo_JobBoard\Views\JobDetail\Details.cshtml"
                               Write(Html.DisplayFor(model => model.Location));

#line default
#line hidden
            EndContext();
            BeginContext(1567, 132, true);
            WriteLiteral("\r\n                                </dd>\r\n                                <dt class=\"col-sm-5\">\r\n                                    ");
            EndContext();
            BeginContext(1700, 43, false);
#line 41 "A:\IoT-Waterloo Job Board\IoT-Waterloo-Job-Board\IOTWaterloo_JobBoard\IOTWaterloo_JobBoard\Views\JobDetail\Details.cshtml"
                               Write(Html.DisplayNameFor(model => model.Jobtype));

#line default
#line hidden
            EndContext();
            BeginContext(1743, 132, true);
            WriteLiteral("\r\n                                </dt>\r\n                                <dd class=\"col-sm-5\">\r\n                                    ");
            EndContext();
            BeginContext(1876, 39, false);
#line 44 "A:\IoT-Waterloo Job Board\IoT-Waterloo-Job-Board\IOTWaterloo_JobBoard\IOTWaterloo_JobBoard\Views\JobDetail\Details.cshtml"
                               Write(Html.DisplayFor(model => model.Jobtype));

#line default
#line hidden
            EndContext();
            BeginContext(1915, 41, true);
            WriteLiteral("\r\n                                </dd>\r\n");
            EndContext();
            BeginContext(2709, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(3087, 91, true);
            WriteLiteral("                                <dt class=\"col-sm-5\">\r\n                                    ");
            EndContext();
            BeginContext(3179, 52, false);
#line 66 "A:\IoT-Waterloo Job Board\IoT-Waterloo-Job-Board\IOTWaterloo_JobBoard\IOTWaterloo_JobBoard\Views\JobDetail\Details.cshtml"
                               Write(Html.DisplayNameFor(model => model.NumberOfPosition));

#line default
#line hidden
            EndContext();
            BeginContext(3231, 132, true);
            WriteLiteral("\r\n                                </dt>\r\n                                <dd class=\"col-sm-5\">\r\n                                    ");
            EndContext();
            BeginContext(3364, 48, false);
#line 69 "A:\IoT-Waterloo Job Board\IoT-Waterloo-Job-Board\IOTWaterloo_JobBoard\IOTWaterloo_JobBoard\Views\JobDetail\Details.cshtml"
                               Write(Html.DisplayFor(model => model.NumberOfPosition));

#line default
#line hidden
            EndContext();
            BeginContext(3412, 132, true);
            WriteLiteral("\r\n                                </dd>\r\n                                <dt class=\"col-sm-5\">\r\n                                    ");
            EndContext();
            BeginContext(3545, 47, false);
#line 72 "A:\IoT-Waterloo Job Board\IoT-Waterloo-Job-Board\IOTWaterloo_JobBoard\IOTWaterloo_JobBoard\Views\JobDetail\Details.cshtml"
                               Write(Html.DisplayNameFor(model => model.JobPostDate));

#line default
#line hidden
            EndContext();
            BeginContext(3592, 132, true);
            WriteLiteral("\r\n                                </dt>\r\n                                <dd class=\"col-sm-5\">\r\n                                    ");
            EndContext();
            BeginContext(3725, 43, false);
#line 75 "A:\IoT-Waterloo Job Board\IoT-Waterloo-Job-Board\IOTWaterloo_JobBoard\IOTWaterloo_JobBoard\Views\JobDetail\Details.cshtml"
                               Write(Html.DisplayFor(model => model.JobPostDate));

#line default
#line hidden
            EndContext();
            BeginContext(3768, 132, true);
            WriteLiteral("\r\n                                </dd>\r\n                                <dt class=\"col-sm-5\">\r\n                                    ");
            EndContext();
            BeginContext(3901, 49, false);
#line 78 "A:\IoT-Waterloo Job Board\IoT-Waterloo-Job-Board\IOTWaterloo_JobBoard\IOTWaterloo_JobBoard\Views\JobDetail\Details.cshtml"
                               Write(Html.DisplayNameFor(model => model.JobExpiryDate));

#line default
#line hidden
            EndContext();
            BeginContext(3950, 132, true);
            WriteLiteral("\r\n                                </dt>\r\n                                <dd class=\"col-sm-5\">\r\n                                    ");
            EndContext();
            BeginContext(4083, 45, false);
#line 81 "A:\IoT-Waterloo Job Board\IoT-Waterloo-Job-Board\IOTWaterloo_JobBoard\IOTWaterloo_JobBoard\Views\JobDetail\Details.cshtml"
                               Write(Html.DisplayFor(model => model.JobExpiryDate));

#line default
#line hidden
            EndContext();
            BeginContext(4128, 132, true);
            WriteLiteral("\r\n                                </dd>\r\n                                <dt class=\"col-sm-5\">\r\n                                    ");
            EndContext();
            BeginContext(4261, 43, false);
#line 84 "A:\IoT-Waterloo Job Board\IoT-Waterloo-Job-Board\IOTWaterloo_JobBoard\IOTWaterloo_JobBoard\Views\JobDetail\Details.cshtml"
                               Write(Html.DisplayNameFor(model => model.Compnay));

#line default
#line hidden
            EndContext();
            BeginContext(4304, 132, true);
            WriteLiteral("\r\n                                </dt>\r\n                                <dd class=\"col-sm-5\">\r\n                                    ");
            EndContext();
            BeginContext(4437, 51, false);
#line 87 "A:\IoT-Waterloo Job Board\IoT-Waterloo-Job-Board\IOTWaterloo_JobBoard\IOTWaterloo_JobBoard\Views\JobDetail\Details.cshtml"
                               Write(Html.DisplayFor(model => model.Compnay.CompanyName));

#line default
#line hidden
            EndContext();
            BeginContext(4488, 132, true);
            WriteLiteral("\r\n                                </dd>\r\n                                <dt class=\"col-sm-5\">\r\n                                    ");
            EndContext();
            BeginContext(4621, 50, false);
#line 90 "A:\IoT-Waterloo Job Board\IoT-Waterloo-Job-Board\IOTWaterloo_JobBoard\IOTWaterloo_JobBoard\Views\JobDetail\Details.cshtml"
                               Write(Html.DisplayNameFor(model => model.JobDescription));

#line default
#line hidden
            EndContext();
            BeginContext(4671, 132, true);
            WriteLiteral("\r\n                                </dt>\r\n                                <dd class=\"col-sm-5\">\r\n                                    ");
            EndContext();
            BeginContext(4804, 46, false);
#line 93 "A:\IoT-Waterloo Job Board\IoT-Waterloo-Job-Board\IOTWaterloo_JobBoard\IOTWaterloo_JobBoard\Views\JobDetail\Details.cshtml"
                               Write(Html.DisplayFor(model => model.JobDescription));

#line default
#line hidden
            EndContext();
            BeginContext(4850, 210, true);
            WriteLiteral("\r\n                                </dd>\r\n                            </dl>\r\n                        </div>\r\n                        <div>\r\n                            <button class=\"btn btn-group-lg bg-purple\">");
            EndContext();
            BeginContext(5060, 97, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "394b8b21a7720329597fd91b95455b50e390d93916039", async() => {
                BeginContext(5149, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 98 "A:\IoT-Waterloo Job Board\IoT-Waterloo-Job-Board\IOTWaterloo_JobBoard\IOTWaterloo_JobBoard\Views\JobDetail\Details.cshtml"
                                                                                                                                      WriteLiteral(Model.JobId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5157, 85, true);
            WriteLiteral(" </button> |\r\n                            <button class=\"btn btn-group-lg bg-purple\">");
            EndContext();
            BeginContext(5242, 101, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "394b8b21a7720329597fd91b95455b50e390d93918677", async() => {
                BeginContext(5333, 6, true);
                WriteLiteral("Delete");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 99 "A:\IoT-Waterloo Job Board\IoT-Waterloo-Job-Board\IOTWaterloo_JobBoard\IOTWaterloo_JobBoard\Views\JobDetail\Details.cshtml"
                                                                                                                                        WriteLiteral(Model.JobId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5343, 85, true);
            WriteLiteral(" </button> |\r\n                            <button class=\"btn btn-group-lg bg-purple\">");
            EndContext();
            BeginContext(5428, 78, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "394b8b21a7720329597fd91b95455b50e390d93921318", async() => {
                BeginContext(5490, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5506, 214, true);
            WriteLiteral(" </button>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n<div>&nbsp;<br /> &nbsp;</div>\r\n<div>&nbsp;<br /> &nbsp;</div>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IOTWaterloo_JobBoard.Models.JobDetails> Html { get; private set; }
    }
}
#pragma warning restore 1591
