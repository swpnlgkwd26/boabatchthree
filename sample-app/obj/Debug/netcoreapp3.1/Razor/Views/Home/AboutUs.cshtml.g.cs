#pragma checksum "D:\FreeLancerAssignments\BankOfAmericaBatch3\sessionapp\sample-app\Views\Home\AboutUs.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "31fefdd6225c1d2f8ea3e3e86277f017bfbb85c0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_AboutUs), @"mvc.1.0.view", @"/Views/Home/AboutUs.cshtml")]
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
#line 1 "D:\FreeLancerAssignments\BankOfAmericaBatch3\sessionapp\sample-app\Views\_ViewImports.cshtml"
using sample_app.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\FreeLancerAssignments\BankOfAmericaBatch3\sessionapp\sample-app\Views\_ViewImports.cshtml"
using sample_app.Infrastructure;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\FreeLancerAssignments\BankOfAmericaBatch3\sessionapp\sample-app\Views\_ViewImports.cshtml"
using sample_app.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"31fefdd6225c1d2f8ea3e3e86277f017bfbb85c0", @"/Views/Home/AboutUs.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4cb728a02d735655e3dbeb63f267a06d504e48ea", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_AboutUs : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

<h2> About Us:  Lets Call Web API</h2>
<button id=""btnGetProduct"" class=""btn btn-primary""> Get Product</button>
<ul id=""ulProducts"">

</ul>
<script type=""text/javascript"">
    $(document).ready(function () {
        var ulProducts = $(""#ulProducts"");
        $(""#btnGetProduct"").click(function () {
            $.ajax({
                type: ""GET"",
                url: ""http://localhost:5001/api/products"",
                dataType: ""json"",
                success: function (data) {
                    ulProducts.empty();
                    $.each(data, function (index, val) {
                        ulProducts.append(""<li>"" + val.name + ""</li>"" )
                    })
                },
                error: function (err) {
                    alert('Something went wrong');
                    ulProducts.empty();
                }
            })
        })

    })
</script>");
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
