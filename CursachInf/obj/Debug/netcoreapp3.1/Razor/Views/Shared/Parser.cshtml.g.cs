#pragma checksum "C:\Users\truen\source\repos\CursachInf\CursachInf\Views\Shared\Parser.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f8f0e99378552c2a8a8c356786b77cc53c9cabb0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Parser), @"mvc.1.0.view", @"/Views/Shared/Parser.cshtml")]
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
#line 2 "C:\Users\truen\source\repos\CursachInf\CursachInf\_ViewImports.cshtml"
using ShieldUI.AspNetCore.Mvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\truen\source\repos\CursachInf\CursachInf\Views\Shared\Parser.cshtml"
using CursachInf.Models.ViewComponents;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\truen\source\repos\CursachInf\CursachInf\Views\Shared\Parser.cshtml"
using CursachInf.Domain.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f8f0e99378552c2a8a8c356786b77cc53c9cabb0", @"/Views/Shared/Parser.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"89aac9129633dde07899f5ea9040d18985faeffb", @"/_ViewImports.cshtml")]
    public class Views_Shared_Parser : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Koefficient>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("align", new global::Microsoft.AspNetCore.Html.HtmlString("center"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-asp-controller", new global::Microsoft.AspNetCore.Html.HtmlString("Home"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\truen\source\repos\CursachInf\CursachInf\Views\Shared\Parser.cshtml"
  

    Layout = null;


#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\truen\source\repos\CursachInf\CursachInf\Views\Shared\Parser.cshtml"
  
    var XLabels = Newtonsoft.Json.JsonConvert.SerializeObject(ViewBag.DataPoints1);
    var YValues = Newtonsoft.Json.JsonConvert.SerializeObject(ViewBag.DataPoints2);
    ViewData["Title"] = "Line Chart";
    int count = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f8f0e99378552c2a8a8c356786b77cc53c9cabb05331", async() => {
                WriteLiteral("\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <title>График по взятым из файла данным</title>\r\n    <link href=\"https://cdn.datatables.net/1.10.20/css/dataTables.bootstrap4.min.css\" rel=\"stylesheet\" />\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f8f0e99378552c2a8a8c356786b77cc53c9cabb06530", async() => {
                WriteLiteral("\r\n\r\n    <div class=\"box-body\">\r\n\r\n        <div class=\"chart-container\">\r\n            <canvas id=\"chart\" style=\"width:100%; height:500px\"></canvas>\r\n        </div>\r\n    </div>\r\n\r\n\r\n\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f8f0e99378552c2a8a8c356786b77cc53c9cabb07000", async() => {
                    WriteLiteral(@"
        <input type=""submit"" value=""Проверить на значимость"" />
        <button type=""button"" class=""btn btn-primary"" id=""save-btn"">Сохранить график</button>
        <input type=""submit"" value=""На главную"" />
        <details open=""open"" title=""Расчёты"">Подробности</details>

    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <table class=\"table\" border=\"1\" align=\"center\">\r\n        <thead>\r\n            <tr>\r\n                <th align=\"center\">\r\n                    ");
#nullable restore
#line 46 "C:\Users\truen\source\repos\CursachInf\CursachInf\Views\Shared\Parser.cshtml"
               Write(Html.DisplayNameFor(model => model.X));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </th>\r\n\r\n                <th align=\"center\">\r\n                    ");
#nullable restore
#line 50 "C:\Users\truen\source\repos\CursachInf\CursachInf\Views\Shared\Parser.cshtml"
               Write(Html.DisplayNameFor(model => model.Y));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                </th>

                <th align=""center"">
                    x<sup>2</sup>
                </th>
                <th align=""center"">
                    y<sup>2</sup>
                </th>
                <th align=""center"">
                    ");
#nullable restore
#line 60 "C:\Users\truen\source\repos\CursachInf\CursachInf\Views\Shared\Parser.cshtml"
               Write(Html.DisplayNameFor(model => model.XmultY));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                </th>
                <th align=""center"">
                    Σx
                </th>
                <th align=""center"">
                    Σy
                </th>
                <th align=""center"">
                    Σx<sup>2</sup>
                </th>
                <th align=""center"">
                    Σx<sup>2</sup>
                </th>
                <th align=""center"">
                    Σxy
                </th>
                <th align=""center"">
                    Среднее величина x
                </th> 
                <th align=""center"">
                    Среднее величина y
                </th>
                <th align=""center"">
                    Среднее величина x<sup>2</sup>
                </th>
                <th align=""center""> 
                    Среднее величина y<sup>2</sup>
                </th>
                <th align=""center"">
                    Среднее величина xy
                </th>
                <th align=""");
                WriteLiteral("center\">\r\n                    ");
#nullable restore
#line 93 "C:\Users\truen\source\repos\CursachInf\CursachInf\Views\Shared\Parser.cshtml"
               Write(Html.DisplayNameFor(model => model.r));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </th>\r\n                <th align=\"center\">\r\n                    ");
#nullable restore
#line 96 "C:\Users\truen\source\repos\CursachInf\CursachInf\Views\Shared\Parser.cshtml"
               Write(Html.DisplayNameFor(model => model.Connection));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 101 "C:\Users\truen\source\repos\CursachInf\CursachInf\Views\Shared\Parser.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <tr>\r\n                <td align=\"center\">\r\n                    ");
#nullable restore
#line 105 "C:\Users\truen\source\repos\CursachInf\CursachInf\Views\Shared\Parser.cshtml"
               Write(Html.DisplayFor(modelItem => item.X));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </td>\r\n\r\n                <td align=\"center\">\r\n                    ");
#nullable restore
#line 109 "C:\Users\truen\source\repos\CursachInf\CursachInf\Views\Shared\Parser.cshtml"
               Write(Html.DisplayFor(modelItem => item.Y));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </td>\r\n                <td align=\"center\">\r\n                    ");
#nullable restore
#line 112 "C:\Users\truen\source\repos\CursachInf\CursachInf\Views\Shared\Parser.cshtml"
               Write(Html.DisplayFor(modelItem => item.SquareX));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </td>\r\n                <td align=\"center\">\r\n                    ");
#nullable restore
#line 115 "C:\Users\truen\source\repos\CursachInf\CursachInf\Views\Shared\Parser.cshtml"
               Write(Html.DisplayFor(modelItem => item.SquareY));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </td>\r\n                <td align=\"center\">\r\n                    ");
#nullable restore
#line 118 "C:\Users\truen\source\repos\CursachInf\CursachInf\Views\Shared\Parser.cshtml"
               Write(Html.DisplayFor(modelItem => item.XmultY));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </td>\r\n                \r\n                   \r\n               \r\n\r\n");
#nullable restore
#line 124 "C:\Users\truen\source\repos\CursachInf\CursachInf\Views\Shared\Parser.cshtml"
                   if (count == 0)
                    {


#line default
#line hidden
#nullable disable
                WriteLiteral("                        <td align=\"center\">\r\n                            ");
#nullable restore
#line 128 "C:\Users\truen\source\repos\CursachInf\CursachInf\Views\Shared\Parser.cshtml"
                       Write(Html.DisplayFor(modelItem => item.SumX));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td align=\"center\">\r\n                            ");
#nullable restore
#line 131 "C:\Users\truen\source\repos\CursachInf\CursachInf\Views\Shared\Parser.cshtml"
                       Write(Html.DisplayFor(modelItem => item.SumY));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td align=\"center\">\r\n                            ");
#nullable restore
#line 134 "C:\Users\truen\source\repos\CursachInf\CursachInf\Views\Shared\Parser.cshtml"
                       Write(Html.DisplayFor(modelItem => item.SumSqrX));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td align=\"center\">\r\n                            ");
#nullable restore
#line 137 "C:\Users\truen\source\repos\CursachInf\CursachInf\Views\Shared\Parser.cshtml"
                       Write(Html.DisplayFor(modelItem => item.SumSqrY));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td align=\"center\">\r\n                            ");
#nullable restore
#line 140 "C:\Users\truen\source\repos\CursachInf\CursachInf\Views\Shared\Parser.cshtml"
                       Write(Html.DisplayFor(modelItem => item.SumXmultY));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td align=\"center\">\r\n                            ");
#nullable restore
#line 143 "C:\Users\truen\source\repos\CursachInf\CursachInf\Views\Shared\Parser.cshtml"
                       Write(Html.DisplayFor(modelItem => item.AvgX));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td align=\"center\">\r\n                            ");
#nullable restore
#line 146 "C:\Users\truen\source\repos\CursachInf\CursachInf\Views\Shared\Parser.cshtml"
                       Write(Html.DisplayFor(modelItem => item.AvgY));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td align=\"center\">\r\n                            ");
#nullable restore
#line 149 "C:\Users\truen\source\repos\CursachInf\CursachInf\Views\Shared\Parser.cshtml"
                       Write(Html.DisplayFor(modelItem => item.AvgSqrX));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td align=\"center\">\r\n                            ");
#nullable restore
#line 152 "C:\Users\truen\source\repos\CursachInf\CursachInf\Views\Shared\Parser.cshtml"
                       Write(Html.DisplayFor(modelItem => item.AvgSqrY));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td align=\"center\">\r\n                            ");
#nullable restore
#line 155 "C:\Users\truen\source\repos\CursachInf\CursachInf\Views\Shared\Parser.cshtml"
                       Write(Html.DisplayFor(modelItem => item.AvgXmultY));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n");
                WriteLiteral("                        <td align=\"center\">\r\n                            ");
#nullable restore
#line 159 "C:\Users\truen\source\repos\CursachInf\CursachInf\Views\Shared\Parser.cshtml"
                       Write(Html.DisplayFor(modelItem => item.r));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td align=\"center\">\r\n                            ");
#nullable restore
#line 162 "C:\Users\truen\source\repos\CursachInf\CursachInf\Views\Shared\Parser.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Connection));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n");
#nullable restore
#line 164 "C:\Users\truen\source\repos\CursachInf\CursachInf\Views\Shared\Parser.cshtml"
                        count++;
                    }
                

#line default
#line hidden
#nullable disable
                WriteLiteral("            </tr>\r\n");
#nullable restore
#line 168 "C:\Users\truen\source\repos\CursachInf\CursachInf\Views\Shared\Parser.cshtml"

            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </tbody>\r\n    </table>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
#nullable restore
#line 174 "C:\Users\truen\source\repos\CursachInf\CursachInf\Views\Shared\Parser.cshtml"
Write(await Html.PartialAsync("ScriptsPartial"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<script type=\"text/javascript\">\r\n\r\n\r\n\r\n        $(function () {\r\n    var chartName = \"chart\";\r\n        var ctx = document.getElementById(chartName).getContext(\'2d\');\r\n        var data = {\r\n                labels: ");
#nullable restore
#line 184 "C:\Users\truen\source\repos\CursachInf\CursachInf\Views\Shared\Parser.cshtml"
                   Write(Html.Raw(XLabels));

#line default
#line hidden
#nullable disable
            WriteLiteral(@",
                datasets: [{
                    label: ""График по файлу"",
                    fill: false,
                    backgroundColor: [
                        'rgba(94, 6, 254,0.2)',
                        'rgba(255, 99, 132, 0.2)',
                        'rgba(54, 162, 235, 0.2)',
                        'rgba(255, 206, 86, 0.2)',
                        'rgba(75, 192, 192, 0.2)',
                        'rgba(153, 102, 255, 0.2)',
                        'rgba(255, 159, 64, 0.2)',
                        'rgba(255, 0, 0)',
                        'rgba(0, 255, 0)',
                        'rgba(0, 0, 255)',
                        'rgba(192, 192, 192)',
                        'rgba(255, 255, 0)',
                        'rgba(255, 0, 255)'
                    ],
                    borderColor: [
                        'rgb(24, 14, 159)'
");
            WriteLiteral("                    ],\r\n\r\n                    borderWidth: 2,\r\n                    data: ");
#nullable restore
#line 209 "C:\Users\truen\source\repos\CursachInf\CursachInf\Views\Shared\Parser.cshtml"
                     Write(Html.Raw(YValues));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    }]
            };

var options = {
                maintainAspectRatio: false,
                scales: {
                    yAxes: [{
                        ticks: {
                            min: 0,
                            beginAtZero: true
                        },
                        gridLines: {
                            display: true,
                            color: ""rgba(255,99,164,0.2)""
                        }
}],
                    xAxes: [{
                        ticks: {
                            min: 0,
                            beginAtZero: true
                        },
                        gridLines: {
                            display: false
                        }
                    }]
                }
            };

       var myChart = new  Chart(ctx, {
                options: options,
                data: data,
                type:'line'

       });

        });
");
            WriteLiteral("\r\n\r\n    $(\"#save-btn\").click(function () {\r\n        $(\"#chart\").get(0).toBlob(function (blob) {\r\n            saveAs(blob, \"downloaded_chart\");\r\n        });\r\n    });\r\n\r\n</script>  ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Koefficient>> Html { get; private set; }
    }
}
#pragma warning restore 1591
