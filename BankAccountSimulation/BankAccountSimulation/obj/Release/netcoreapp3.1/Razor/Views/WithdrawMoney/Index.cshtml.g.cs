#pragma checksum "F:\C# Project\Web Application - CORE\Bank-Account-Simulation\BankAccountSimulation\BankAccountSimulation\Views\WithdrawMoney\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "23f67919e7130b2d37275ba1bfc17d6df314fa98"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_WithdrawMoney_Index), @"mvc.1.0.view", @"/Views/WithdrawMoney/Index.cshtml")]
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
#line 1 "F:\C# Project\Web Application - CORE\Bank-Account-Simulation\BankAccountSimulation\BankAccountSimulation\Views\_ViewImports.cshtml"
using BankAccountSimulation;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\C# Project\Web Application - CORE\Bank-Account-Simulation\BankAccountSimulation\BankAccountSimulation\Views\_ViewImports.cshtml"
using BankAccountSimulation.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "F:\C# Project\Web Application - CORE\Bank-Account-Simulation\BankAccountSimulation\BankAccountSimulation\Views\WithdrawMoney\Index.cshtml"
using Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23f67919e7130b2d37275ba1bfc17d6df314fa98", @"/Views/WithdrawMoney/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"50b0447c5156d9e58c2072137cb0fee380357c96", @"/Views/_ViewImports.cshtml")]
    public class Views_WithdrawMoney_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WithdrawMoney>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "F:\C# Project\Web Application - CORE\Bank-Account-Simulation\BankAccountSimulation\BankAccountSimulation\Views\WithdrawMoney\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1 class=""haderTitle"">Withdraw Money Details</h1>
<hr />

<div class=""row"" id=""styleDataTableCountry"">
    <div class=""col-md-10"">
        <table id=""dataTable"" class=""display table table-bordered table-striped"">
            <thead>
                <tr>
                    <th>My Account</th>
                    <th>Withdraw Details</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 22 "F:\C# Project\Web Application - CORE\Bank-Account-Simulation\BankAccountSimulation\BankAccountSimulation\Views\WithdrawMoney\Index.cshtml"
                 foreach (WithdrawMoney item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            Account No: ");
#nullable restore
#line 26 "F:\C# Project\Web Application - CORE\Bank-Account-Simulation\BankAccountSimulation\BankAccountSimulation\Views\WithdrawMoney\Index.cshtml"
                                   Write(item.AccountId);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\r\n                        </td>\r\n                        <td>\r\n                            Withdraw No: ");
#nullable restore
#line 29 "F:\C# Project\Web Application - CORE\Bank-Account-Simulation\BankAccountSimulation\BankAccountSimulation\Views\WithdrawMoney\Index.cshtml"
                                    Write(item.WithdrawNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\r\n                            Ammount: ");
#nullable restore
#line 30 "F:\C# Project\Web Application - CORE\Bank-Account-Simulation\BankAccountSimulation\BankAccountSimulation\Views\WithdrawMoney\Index.cshtml"
                                Write(item.Ammount);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\r\n                            Date: ");
#nullable restore
#line 31 "F:\C# Project\Web Application - CORE\Bank-Account-Simulation\BankAccountSimulation\BankAccountSimulation\Views\WithdrawMoney\Index.cshtml"
                             Write(item.WithdrawDate);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 34 "F:\C# Project\Web Application - CORE\Bank-Account-Simulation\BankAccountSimulation\BankAccountSimulation\Views\WithdrawMoney\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WithdrawMoney>> Html { get; private set; }
    }
}
#pragma warning restore 1591
