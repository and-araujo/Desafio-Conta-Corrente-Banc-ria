#pragma checksum "C:\Users\Casa8\Desktop\Anderson\Cursos\Desafio\Desafio\src\Banco.App\Views\Home\_Extrato.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3031760eaf688b9026a2fe0dc749266588745b38"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home__Extrato), @"mvc.1.0.view", @"/Views/Home/_Extrato.cshtml")]
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
#line 1 "C:\Users\Casa8\Desktop\Anderson\Cursos\Desafio\Desafio\src\Banco.App\Views\_ViewImports.cshtml"
using Banco.App;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Casa8\Desktop\Anderson\Cursos\Desafio\Desafio\src\Banco.App\Views\_ViewImports.cshtml"
using Banco.App.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3031760eaf688b9026a2fe0dc749266588745b38", @"/Views/Home/_Extrato.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a98935a27743ed5f4c482eb6a77439c9a8080629", @"/Views/_ViewImports.cshtml")]
    public class Views_Home__Extrato : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Banco.App.ViewModels.ContaCorrenteViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<table class=""table"">
    <thead>
        <tr>
            <th>
                Data
            </th>
            <th>
                Tipo Transação
            </th>
            <th>
                Valor
            </th>
            <th></th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 19 "C:\Users\Casa8\Desktop\Anderson\Cursos\Desafio\Desafio\src\Banco.App\Views\Home\_Extrato.cshtml"
         foreach (var item in @Model.Transacoes)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 23 "C:\Users\Casa8\Desktop\Anderson\Cursos\Desafio\Desafio\src\Banco.App\Views\Home\_Extrato.cshtml"
               Write(Html.DisplayFor(modelItem => item.DataTransacao));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 26 "C:\Users\Casa8\Desktop\Anderson\Cursos\Desafio\Desafio\src\Banco.App\Views\Home\_Extrato.cshtml"
               Write(Html.DisplayFor(modelItem => item.TipoTransacao));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 29 "C:\Users\Casa8\Desktop\Anderson\Cursos\Desafio\Desafio\src\Banco.App\Views\Home\_Extrato.cshtml"
               Write(Html.DisplayFor(modelItem => item.ValorTransacao));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 32 "C:\Users\Casa8\Desktop\Anderson\Cursos\Desafio\Desafio\src\Banco.App\Views\Home\_Extrato.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Banco.App.ViewModels.ContaCorrenteViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
