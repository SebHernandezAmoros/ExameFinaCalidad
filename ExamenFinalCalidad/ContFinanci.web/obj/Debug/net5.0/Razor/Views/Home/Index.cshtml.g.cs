#pragma checksum "D:\CICLOS\Ciclo 9\Calidad\ExameFinaCalidad\ExamenFinalCalidad\ContFinanci.web\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5c51cbea208b8a1d86e69012f24bebf7a351f74b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "D:\CICLOS\Ciclo 9\Calidad\ExameFinaCalidad\ExamenFinalCalidad\ContFinanci.web\Views\_ViewImports.cshtml"
using ContFinanci.web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\CICLOS\Ciclo 9\Calidad\ExameFinaCalidad\ExamenFinalCalidad\ContFinanci.web\Views\_ViewImports.cshtml"
using ContFinanci.web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c51cbea208b8a1d86e69012f24bebf7a351f74b", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ae0623427b2621629c29c20729240005ecef0453", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\CICLOS\Ciclo 9\Calidad\ExameFinaCalidad\ExamenFinalCalidad\ContFinanci.web\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1 id=\"Gestor\" class=\"display-4\">GESTOR DE CUENTAS</h1>\r\n    <h1");
            BeginWriteAttribute("id", " id=\"", 143, "\"", 148, 0);
            EndWriteAttribute();
            WriteLiteral(">Dolares: ");
#nullable restore
#line 7 "D:\CICLOS\Ciclo 9\Calidad\ExameFinaCalidad\ExamenFinalCalidad\ContFinanci.web\Views\Home\Index.cshtml"
                  Write(ViewBag.TotalDolares);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n    <h1");
            BeginWriteAttribute("id", " id=\"", 194, "\"", 199, 0);
            EndWriteAttribute();
            WriteLiteral(">Soles: ");
#nullable restore
#line 8 "D:\CICLOS\Ciclo 9\Calidad\ExameFinaCalidad\ExamenFinalCalidad\ContFinanci.web\Views\Home\Index.cshtml"
                Write(ViewBag.TotalSoles);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n    <h1");
            BeginWriteAttribute("id", " id=\"", 241, "\"", 246, 0);
            EndWriteAttribute();
            WriteLiteral(">Total convertido a soles: ");
#nullable restore
#line 9 "D:\CICLOS\Ciclo 9\Calidad\ExameFinaCalidad\ExamenFinalCalidad\ContFinanci.web\Views\Home\Index.cshtml"
                                   Write(ViewBag.TotalSolesConvert);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h1>
    <a href=""/home/CreateCuenta"" type=""button"" class=""btn btn-info"" style=""height: 40px; width: 1200px"">Cuenta nueva</a>

    <table class=""table table-light"">
        <thead>
            <tr>
                <th scope=""col"">#</th>
                <th scope=""col"">Nombre</th>
                <th scope=""col"">Categoria</th>
                <th scope=""col"">Saldo inicial</th>
                <th scope=""col"">Moneda</th>
                <th scope=""col"">Opciones</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 24 "D:\CICLOS\Ciclo 9\Calidad\ExameFinaCalidad\ExamenFinalCalidad\ContFinanci.web\Views\Home\Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td");
            BeginWriteAttribute("id", " id=\"", 938, "\"", 957, 1);
#nullable restore
#line 27 "D:\CICLOS\Ciclo 9\Calidad\ExameFinaCalidad\ExamenFinalCalidad\ContFinanci.web\Views\Home\Index.cshtml"
WriteAttributeValue("", 943, item.CuentaId, 943, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 27 "D:\CICLOS\Ciclo 9\Calidad\ExameFinaCalidad\ExamenFinalCalidad\ContFinanci.web\Views\Home\Index.cshtml"
                                       Write(item.CuentaId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 28 "D:\CICLOS\Ciclo 9\Calidad\ExameFinaCalidad\ExamenFinalCalidad\ContFinanci.web\Views\Home\Index.cshtml"
                   Write(item.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 29 "D:\CICLOS\Ciclo 9\Calidad\ExameFinaCalidad\ExamenFinalCalidad\ContFinanci.web\Views\Home\Index.cshtml"
                     if (@item.Propio)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td>Propio</td>\r\n");
#nullable restore
#line 32 "D:\CICLOS\Ciclo 9\Calidad\ExameFinaCalidad\ExamenFinalCalidad\ContFinanci.web\Views\Home\Index.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td>Credito</td>\r\n");
#nullable restore
#line 36 "D:\CICLOS\Ciclo 9\Calidad\ExameFinaCalidad\ExamenFinalCalidad\ContFinanci.web\Views\Home\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>");
#nullable restore
#line 37 "D:\CICLOS\Ciclo 9\Calidad\ExameFinaCalidad\ExamenFinalCalidad\ContFinanci.web\Views\Home\Index.cshtml"
                   Write(item.SaldoInicial);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 38 "D:\CICLOS\Ciclo 9\Calidad\ExameFinaCalidad\ExamenFinalCalidad\ContFinanci.web\Views\Home\Index.cshtml"
                     if (@item.Dolares)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td>Dolares</td>\r\n");
#nullable restore
#line 41 "D:\CICLOS\Ciclo 9\Calidad\ExameFinaCalidad\ExamenFinalCalidad\ContFinanci.web\Views\Home\Index.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td>Soles</td>\r\n");
#nullable restore
#line 45 "D:\CICLOS\Ciclo 9\Calidad\ExameFinaCalidad\ExamenFinalCalidad\ContFinanci.web\Views\Home\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 1606, "\"", 1648, 2);
            WriteAttributeValue("", 1613, "/home/ViewGastos/?id=", 1613, 21, true);
#nullable restore
#line 47 "D:\CICLOS\Ciclo 9\Calidad\ExameFinaCalidad\ExamenFinalCalidad\ContFinanci.web\Views\Home\Index.cshtml"
WriteAttributeValue("", 1634, item.CuentaId, 1634, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-success\">Ver gastos</a>\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 1716, "\"", 1760, 2);
            WriteAttributeValue("", 1723, "/home/ViewIngresos/?id=", 1723, 23, true);
#nullable restore
#line 48 "D:\CICLOS\Ciclo 9\Calidad\ExameFinaCalidad\ExamenFinalCalidad\ContFinanci.web\Views\Home\Index.cshtml"
WriteAttributeValue("", 1746, item.CuentaId, 1746, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger\">Ver ingresos</a>\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 51 "D:\CICLOS\Ciclo 9\Calidad\ExameFinaCalidad\ExamenFinalCalidad\ContFinanci.web\Views\Home\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
