#pragma checksum "F:\C# Project\Web Application - CORE\Bank-Account-Simulation\BankAccountSimulation\BankAccountSimulation\Views\TransferMoney\TransferMoneyRecordAdmin.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "50c2fbe1c986e7ada07de39dd3f3a566571aa923"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_TransferMoney_TransferMoneyRecordAdmin), @"mvc.1.0.view", @"/Views/TransferMoney/TransferMoneyRecordAdmin.cshtml")]
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
#line 1 "F:\C# Project\Web Application - CORE\Bank-Account-Simulation\BankAccountSimulation\BankAccountSimulation\Views\TransferMoney\TransferMoneyRecordAdmin.cshtml"
using Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"50c2fbe1c986e7ada07de39dd3f3a566571aa923", @"/Views/TransferMoney/TransferMoneyRecordAdmin.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"50b0447c5156d9e58c2072137cb0fee380357c96", @"/Views/_ViewImports.cshtml")]
    public class Views_TransferMoney_TransferMoneyRecordAdmin : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<TransferMoney>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "F:\C# Project\Web Application - CORE\Bank-Account-Simulation\BankAccountSimulation\BankAccountSimulation\Views\TransferMoney\TransferMoneyRecordAdmin.cshtml"
  
    ViewData["Title"] = "Transfer Money Record";
    Layout = "~/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1 class=""haderTitle"">Transfer Money Record</h1>

<div class=""row"" id=""styleDataTableCountry"">
    <div class=""col-md-6"">
        <table id=""dataTable"" class=""display table table-bordered table-striped"">
            <thead>
                <tr>
                    <th>Sender Account</th>
                    <th>Transfer Information</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 21 "F:\C# Project\Web Application - CORE\Bank-Account-Simulation\BankAccountSimulation\BankAccountSimulation\Views\TransferMoney\TransferMoneyRecordAdmin.cshtml"
                 foreach (TransferMoney item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>Sender Account: ");
#nullable restore
#line 24 "F:\C# Project\Web Application - CORE\Bank-Account-Simulation\BankAccountSimulation\BankAccountSimulation\Views\TransferMoney\TransferMoneyRecordAdmin.cshtml"
                                       Write(item.AccountId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>\r\n                            Transfer Account: ");
#nullable restore
#line 26 "F:\C# Project\Web Application - CORE\Bank-Account-Simulation\BankAccountSimulation\BankAccountSimulation\Views\TransferMoney\TransferMoneyRecordAdmin.cshtml"
                                         Write(item.SendAccountNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\r\n                            Total Ammount: ");
#nullable restore
#line 27 "F:\C# Project\Web Application - CORE\Bank-Account-Simulation\BankAccountSimulation\BankAccountSimulation\Views\TransferMoney\TransferMoneyRecordAdmin.cshtml"
                                      Write(item.Ammount);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\r\n                            Date: ");
#nullable restore
#line 28 "F:\C# Project\Web Application - CORE\Bank-Account-Simulation\BankAccountSimulation\BankAccountSimulation\Views\TransferMoney\TransferMoneyRecordAdmin.cshtml"
                             Write(item.TransferMoneyDate);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 31 "F:\C# Project\Web Application - CORE\Bank-Account-Simulation\BankAccountSimulation\BankAccountSimulation\Views\TransferMoney\TransferMoneyRecordAdmin.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<TransferMoney>> Html { get; private set; }
    }
}
#pragma warning restore 1591
