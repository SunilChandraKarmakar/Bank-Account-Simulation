#pragma checksum "F:\C# Project\Web Application - CORE\Bank-Account-Simulation\BankAccountSimulation\BankAccountSimulation\Views\LoginCustomer\LoginCustomerAccountInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b85ae411c173a67a74fcaa03acc02a214c770d36"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_LoginCustomer_LoginCustomerAccountInfo), @"mvc.1.0.view", @"/Views/LoginCustomer/LoginCustomerAccountInfo.cshtml")]
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
#line 1 "F:\C# Project\Web Application - CORE\Bank-Account-Simulation\BankAccountSimulation\BankAccountSimulation\Views\LoginCustomer\LoginCustomerAccountInfo.cshtml"
using Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b85ae411c173a67a74fcaa03acc02a214c770d36", @"/Views/LoginCustomer/LoginCustomerAccountInfo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1236d742d5623054b645a4e345045ead2574d024", @"/Views/_ViewImports.cshtml")]
    public class Views_LoginCustomer_LoginCustomerAccountInfo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Account>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 4 "F:\C# Project\Web Application - CORE\Bank-Account-Simulation\BankAccountSimulation\BankAccountSimulation\Views\LoginCustomer\LoginCustomerAccountInfo.cshtml"
  
    ViewData["Title"] = "Login Custome Account Information";
    Layout = "~/Views/Shared/_CustomerLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1 class=""haderTitle"">Account Details</h1>

<div class=""row"" id=""styleDataTableCountry"">
    <div class=""col-md-10"">
        <table class=""display table table-bordered table-striped"">
            <thead>
                <tr>
                    <th>Basic Info</th>
                    <th>Account Info</th> 
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>
                        Branch: ");
#nullable restore
#line 23 "F:\C# Project\Web Application - CORE\Bank-Account-Simulation\BankAccountSimulation\BankAccountSimulation\Views\LoginCustomer\LoginCustomerAccountInfo.cshtml"
                           Write(Model.Branch.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\n                        Type: ");
#nullable restore
#line 24 "F:\C# Project\Web Application - CORE\Bank-Account-Simulation\BankAccountSimulation\BankAccountSimulation\Views\LoginCustomer\LoginCustomerAccountInfo.cshtml"
                         Write(Model.AccountType.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\n                        Status: ");
#nullable restore
#line 25 "F:\C# Project\Web Application - CORE\Bank-Account-Simulation\BankAccountSimulation\BankAccountSimulation\Views\LoginCustomer\LoginCustomerAccountInfo.cshtml"
                           Write(Model.AccountStatus.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\n                    </td>\n                    <td>\n                        Customer: ");
#nullable restore
#line 28 "F:\C# Project\Web Application - CORE\Bank-Account-Simulation\BankAccountSimulation\BankAccountSimulation\Views\LoginCustomer\LoginCustomerAccountInfo.cshtml"
                             Write(Model.Customer.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\n                        AC No: ");
#nullable restore
#line 29 "F:\C# Project\Web Application - CORE\Bank-Account-Simulation\BankAccountSimulation\BankAccountSimulation\Views\LoginCustomer\LoginCustomerAccountInfo.cshtml"
                          Write(Model.AccountNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\n                        Balance: ");
#nullable restore
#line 30 "F:\C# Project\Web Application - CORE\Bank-Account-Simulation\BankAccountSimulation\BankAccountSimulation\Views\LoginCustomer\LoginCustomerAccountInfo.cshtml"
                            Write(Model.Balance);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\n                    </td>\n                </tr>\n            </tbody>\n        </table>\n    </div>\n</div>\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Account> Html { get; private set; }
    }
}
#pragma warning restore 1591
