#pragma checksum "D:\GIT\My Repository\MoneySaving\MoneySaving\Views\FundSummary\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a0134e7d6b1d2e471cc5b345cb8f14e85cbbeb7f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_FundSummary_Index), @"mvc.1.0.view", @"/Views/FundSummary/Index.cshtml")]
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
#line 1 "D:\GIT\My Repository\MoneySaving\MoneySaving\Views\_ViewImports.cshtml"
using MoneySaving;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\GIT\My Repository\MoneySaving\MoneySaving\Views\_ViewImports.cshtml"
using MoneySaving.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a0134e7d6b1d2e471cc5b345cb8f14e85cbbeb7f", @"/Views/FundSummary/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8905f0d3bc9bf5044e82aa8527eb0e04d200a2a9", @"/Views/_ViewImports.cshtml")]
    public class Views_FundSummary_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MoneySaving.Models.FundSummary>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("mr-2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "FundPorts", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "FundTransactions", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "FundSummary", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UpdateNav", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\GIT\My Repository\MoneySaving\MoneySaving\Views\FundSummary\Index.cshtml"
  
    ViewData["Title"] = "Fund";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"mb-4\">\r\n    <h2>Fund</h2>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a0134e7d6b1d2e471cc5b345cb8f14e85cbbeb7f5554", async() => {
                WriteLiteral("Port");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a0134e7d6b1d2e471cc5b345cb8f14e85cbbeb7f7200", async() => {
                WriteLiteral("Transaction");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a0134e7d6b1d2e471cc5b345cb8f14e85cbbeb7f8653", async() => {
                WriteLiteral("Update NAV");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n\r\n");
#nullable restore
#line 13 "D:\GIT\My Repository\MoneySaving\MoneySaving\Views\FundSummary\Index.cshtml"
  
    List<FundPort> listPort = (List<FundPort>)ViewData["PortList"];

    foreach (var port in listPort)
    {
        double totalCost = 0;
        double totalCurValue = 0;
        double totalGain = 0;


#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"mb-4\">\r\n            <h5 class=\"text-primary\">");
#nullable restore
#line 23 "D:\GIT\My Repository\MoneySaving\MoneySaving\Views\FundSummary\Index.cshtml"
                                Write(Html.DisplayFor(modelItem => port.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h5>
            <div class=""table-responsive-sm"">
                <table class=""table table-sm table-hover text-right text-wrap"">
                    <thead>
                        <tr>
                            <th></th>
                            <th>
                                ");
#nullable restore
#line 30 "D:\GIT\My Repository\MoneySaving\MoneySaving\Views\FundSummary\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.unit));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n");
            WriteLiteral("                            <th>\r\n                                ");
#nullable restore
#line 36 "D:\GIT\My Repository\MoneySaving\MoneySaving\Views\FundSummary\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.cost));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 39 "D:\GIT\My Repository\MoneySaving\MoneySaving\Views\FundSummary\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.nav_price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th colspan=\"2\">\r\n                                1 Day change\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 45 "D:\GIT\My Repository\MoneySaving\MoneySaving\Views\FundSummary\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.current_value));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 48 "D:\GIT\My Repository\MoneySaving\MoneySaving\Views\FundSummary\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.gain_baht));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>%</th>\r\n                        </tr>\r\n                    </thead>\r\n                    <tbody>\r\n");
#nullable restore
#line 54 "D:\GIT\My Repository\MoneySaving\MoneySaving\Views\FundSummary\Index.cshtml"
                         foreach (var item in Model.Where(x => x.FundPort == port))
                        {
                            totalCost += item.cost;
                            totalCurValue += item.current_value;
                            totalGain += item.gain_baht;

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td class=\"text-left\">\r\n                                    ");
#nullable restore
#line 61 "D:\GIT\My Repository\MoneySaving\MoneySaving\Views\FundSummary\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.MFund.Abbr));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 64 "D:\GIT\My Repository\MoneySaving\MoneySaving\Views\FundSummary\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.unit));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n");
            WriteLiteral("                                <td>\r\n                                    ");
#nullable restore
#line 70 "D:\GIT\My Repository\MoneySaving\MoneySaving\Views\FundSummary\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.cost));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n");
            WriteLiteral("                                <td>\r\n                                    ");
#nullable restore
#line 76 "D:\GIT\My Repository\MoneySaving\MoneySaving\Views\FundSummary\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.nav_price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 79 "D:\GIT\My Repository\MoneySaving\MoneySaving\Views\FundSummary\Index.cshtml"
                               Write(string.Format("{0:N4}", item.nav_price - item.nav_prev));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n");
#nullable restore
#line 82 "D:\GIT\My Repository\MoneySaving\MoneySaving\Views\FundSummary\Index.cshtml"
                                      
                                        double val_curr = item.nav_price;
                                        double val_prev = item.nav_prev;
                                    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    ");
#nullable restore
#line 87 "D:\GIT\My Repository\MoneySaving\MoneySaving\Views\FundSummary\Index.cshtml"
                               Write(string.Format("{0:P}", (val_curr - val_prev) / val_prev));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 90 "D:\GIT\My Repository\MoneySaving\MoneySaving\Views\FundSummary\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.current_value));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n");
#nullable restore
#line 92 "D:\GIT\My Repository\MoneySaving\MoneySaving\Views\FundSummary\Index.cshtml"
                                 if (item.gain_baht >= 0)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td class=\"text-success\">\r\n                                        ");
#nullable restore
#line 95 "D:\GIT\My Repository\MoneySaving\MoneySaving\Views\FundSummary\Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.gain_baht));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td class=\"text-success\">\r\n                                        ");
#nullable restore
#line 98 "D:\GIT\My Repository\MoneySaving\MoneySaving\Views\FundSummary\Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.gain_per));

#line default
#line hidden
#nullable disable
            WriteLiteral("%\r\n                                    </td>\r\n");
#nullable restore
#line 100 "D:\GIT\My Repository\MoneySaving\MoneySaving\Views\FundSummary\Index.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td class=\"text-danger\">\r\n                                        ");
#nullable restore
#line 104 "D:\GIT\My Repository\MoneySaving\MoneySaving\Views\FundSummary\Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.gain_baht));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td class=\"text-danger\">\r\n                                        ");
#nullable restore
#line 107 "D:\GIT\My Repository\MoneySaving\MoneySaving\Views\FundSummary\Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.gain_per));

#line default
#line hidden
#nullable disable
            WriteLiteral("%\r\n                                    </td>\r\n");
#nullable restore
#line 109 "D:\GIT\My Repository\MoneySaving\MoneySaving\Views\FundSummary\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </tr>\r\n");
#nullable restore
#line 111 "D:\GIT\My Repository\MoneySaving\MoneySaving\Views\FundSummary\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                    <tfoot>\r\n                        <tr class=\"font-weight-bold\">\r\n                            <td>Total</td>\r\n                            <td></td>\r\n                            <td>");
#nullable restore
#line 117 "D:\GIT\My Repository\MoneySaving\MoneySaving\Views\FundSummary\Index.cshtml"
                           Write(string.Format("{0:C}", totalCost));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td></td>\r\n                            <td></td>\r\n                            <td></td>\r\n                            <td>");
#nullable restore
#line 121 "D:\GIT\My Repository\MoneySaving\MoneySaving\Views\FundSummary\Index.cshtml"
                           Write(string.Format("{0:C}", totalCurValue));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 122 "D:\GIT\My Repository\MoneySaving\MoneySaving\Views\FundSummary\Index.cshtml"
                             if (totalGain >= 0)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td class=\"text-success\">");
#nullable restore
#line 124 "D:\GIT\My Repository\MoneySaving\MoneySaving\Views\FundSummary\Index.cshtml"
                                                    Write(string.Format("{0:C}", totalGain));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td class=\"text-success\">");
#nullable restore
#line 125 "D:\GIT\My Repository\MoneySaving\MoneySaving\Views\FundSummary\Index.cshtml"
                                                    Write(string.Format("{0:P}", totalGain / totalCost));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 126 "D:\GIT\My Repository\MoneySaving\MoneySaving\Views\FundSummary\Index.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td class=\"text-danger\">");
#nullable restore
#line 129 "D:\GIT\My Repository\MoneySaving\MoneySaving\Views\FundSummary\Index.cshtml"
                                                   Write(string.Format("{0:C}", totalGain));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td class=\"text-danger\">");
#nullable restore
#line 130 "D:\GIT\My Repository\MoneySaving\MoneySaving\Views\FundSummary\Index.cshtml"
                                                   Write(string.Format("{0:P}", totalGain / totalCost));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 131 "D:\GIT\My Repository\MoneySaving\MoneySaving\Views\FundSummary\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tr>\r\n                    </tfoot>\r\n                </table>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 137 "D:\GIT\My Repository\MoneySaving\MoneySaving\Views\FundSummary\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MoneySaving.Models.FundSummary>> Html { get; private set; }
    }
}
#pragma warning restore 1591