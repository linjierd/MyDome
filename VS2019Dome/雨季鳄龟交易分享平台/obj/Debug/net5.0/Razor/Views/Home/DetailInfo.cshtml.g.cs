#pragma checksum "C:\Users\linji\Documents\GitHub\desktop-tutorial\VS2019Dome\雨季鳄龟交易分享平台\Views\Home\DetailInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4cf354533241d42d7369090f1dba1cc97a7b4566"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_DetailInfo), @"mvc.1.0.view", @"/Views/Home/DetailInfo.cshtml")]
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
#line 1 "C:\Users\linji\Documents\GitHub\desktop-tutorial\VS2019Dome\雨季鳄龟交易分享平台\Views\_ViewImports.cshtml"
using 雨季鳄龟交易分享平台;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\linji\Documents\GitHub\desktop-tutorial\VS2019Dome\雨季鳄龟交易分享平台\Views\Home\DetailInfo.cshtml"
using 雨季鳄龟交易分享平台.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4cf354533241d42d7369090f1dba1cc97a7b4566", @"/Views/Home/DetailInfo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"daf1ebaeb85b5350898271993cb8f100c53797ec", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_DetailInfo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 8 "C:\Users\linji\Documents\GitHub\desktop-tutorial\VS2019Dome\雨季鳄龟交易分享平台\Views\Home\DetailInfo.cshtml"
  
    YuJi_Sell info = ViewBag.Info;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<input type=\"button\" name=\"name\" value=\"返回\" onclick=\"javascript: history.back()\" />\r\n\r\n<div><h4>");
#nullable restore
#line 14 "C:\Users\linji\Documents\GitHub\desktop-tutorial\VS2019Dome\雨季鳄龟交易分享平台\Views\Home\DetailInfo.cshtml"
    Write(info.yj_Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4><span style=\"color:red\">￥");
#nullable restore
#line 14 "C:\Users\linji\Documents\GitHub\desktop-tutorial\VS2019Dome\雨季鳄龟交易分享平台\Views\Home\DetailInfo.cshtml"
                                                Write(info.yj_price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></div>\r\n<div>\r\n    QQ:<i>");
#nullable restore
#line 16 "C:\Users\linji\Documents\GitHub\desktop-tutorial\VS2019Dome\雨季鳄龟交易分享平台\Views\Home\DetailInfo.cshtml"
     Write(info.yj_QQ);

#line default
#line hidden
#nullable disable
            WriteLiteral("</i>\r\n    微信:<i>");
#nullable restore
#line 17 "C:\Users\linji\Documents\GitHub\desktop-tutorial\VS2019Dome\雨季鳄龟交易分享平台\Views\Home\DetailInfo.cshtml"
     Write(info.yj_WeiXin);

#line default
#line hidden
#nullable disable
            WriteLiteral("</i>\r\n</div>\r\n<div>\r\n    ");
#nullable restore
#line 20 "C:\Users\linji\Documents\GitHub\desktop-tutorial\VS2019Dome\雨季鳄龟交易分享平台\Views\Home\DetailInfo.cshtml"
Write(info.yj_Desc);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n<div>\r\n");
#nullable restore
#line 24 "C:\Users\linji\Documents\GitHub\desktop-tutorial\VS2019Dome\雨季鳄龟交易分享平台\Views\Home\DetailInfo.cshtml"
     foreach (var img in info.imgs)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <img  style=\"max-width:300px;max-height:500px\"");
            BeginWriteAttribute("src", "  src=\"", 586, "\"", 607, 1);
#nullable restore
#line 26 "C:\Users\linji\Documents\GitHub\desktop-tutorial\VS2019Dome\雨季鳄龟交易分享平台\Views\Home\DetailInfo.cshtml"
WriteAttributeValue("", 593, img.yj_ImgSrc, 593, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 608, "\"", 628, 1);
#nullable restore
#line 26 "C:\Users\linji\Documents\GitHub\desktop-tutorial\VS2019Dome\雨季鳄龟交易分享平台\Views\Home\DetailInfo.cshtml"
WriteAttributeValue("", 614, info.yj_Title, 614, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n");
#nullable restore
#line 27 "C:\Users\linji\Documents\GitHub\desktop-tutorial\VS2019Dome\雨季鳄龟交易分享平台\Views\Home\DetailInfo.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n<input type=\"button\" name=\"name\" value=\"返回\" onclick=\"javascript: history.back()\" />");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
