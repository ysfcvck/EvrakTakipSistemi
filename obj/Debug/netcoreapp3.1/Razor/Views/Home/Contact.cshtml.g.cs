#pragma checksum "C:\Users\PC\Desktop\Proje\EvrakTakipSistemi\Views\Home\Contact.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b971798973a7de05f044437e646fae633e8beb2f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Contact), @"mvc.1.0.view", @"/Views/Home/Contact.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b971798973a7de05f044437e646fae633e8beb2f", @"/Views/Home/Contact.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57218c316b6921e2cd61027a2387edc31a2d9471", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Contact : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EvrakTakipSistemi.Models.ViewModels.Contact>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\PC\Desktop\Proje\EvrakTakipSistemi\Views\Home\Contact.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<title>İletişim</title>\r\n<h1 class=\"baslık\">İletişim Formu</h1>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b971798973a7de05f044437e646fae633e8beb2f3042", async() => {
                WriteLiteral("\r\n    <div class=\"content-regist\">\r\n");
#nullable restore
#line 10 "C:\Users\PC\Desktop\Proje\EvrakTakipSistemi\Views\Home\Contact.cshtml"
         using (Html.BeginForm())
        {


#line default
#line hidden
#nullable disable
                WriteLiteral("            <div>\r\n                ");
#nullable restore
#line 14 "C:\Users\PC\Desktop\Proje\EvrakTakipSistemi\Views\Home\Contact.cshtml"
           Write(Html.TextBoxFor(x => x.baslik, new { @placeholder = "Konu", @class = "form-control-registration" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                ");
#nullable restore
#line 15 "C:\Users\PC\Desktop\Proje\EvrakTakipSistemi\Views\Home\Contact.cshtml"
           Write(Html.ValidationMessageFor(model => model.baslik, "", new { @style = "color:red" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n            </div>\r\n            <div>\r\n                ");
#nullable restore
#line 19 "C:\Users\PC\Desktop\Proje\EvrakTakipSistemi\Views\Home\Contact.cshtml"
           Write(Html.TextBoxFor(x => x.AdSoyad, new { @placeholder = "Ad Soyad", @class = "form-control-registration" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                ");
#nullable restore
#line 20 "C:\Users\PC\Desktop\Proje\EvrakTakipSistemi\Views\Home\Contact.cshtml"
           Write(Html.ValidationMessageFor(model => model.AdSoyad, "", new { @style = "color:red" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n            </div>\r\n            <div>\r\n                ");
#nullable restore
#line 24 "C:\Users\PC\Desktop\Proje\EvrakTakipSistemi\Views\Home\Contact.cshtml"
           Write(Html.TextBoxFor(x => x.eposta, new { @placeholder = "Eposta", @class = "form-control-registration" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                ");
#nullable restore
#line 25 "C:\Users\PC\Desktop\Proje\EvrakTakipSistemi\Views\Home\Contact.cshtml"
           Write(Html.ValidationMessageFor(model => model.eposta, "", new { @style = "color:red" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n            </div>\r\n            <div>\r\n                ");
#nullable restore
#line 29 "C:\Users\PC\Desktop\Proje\EvrakTakipSistemi\Views\Home\Contact.cshtml"
           Write(Html.TextAreaFor(x => x.icerik, new { @placeholder = "İçerik..", @class = "form-control-registration", @id = "contactArea" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                ");
#nullable restore
#line 30 "C:\Users\PC\Desktop\Proje\EvrakTakipSistemi\Views\Home\Contact.cshtml"
           Write(Html.ValidationMessageFor(model => model.icerik, "", new { @style = "color:red" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n            </div>\r\n");
                WriteLiteral("            <div>\r\n                <input type=\"submit\" value=\"Gönder\">\r\n            </div><br />\r\n            <div class=\"alert alert-info\" style=\"color:red; margin-left:28px;\">\r\n                ");
#nullable restore
#line 38 "C:\Users\PC\Desktop\Proje\EvrakTakipSistemi\Views\Home\Contact.cshtml"
           Write(TempData["Message"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </div>\r\n");
#nullable restore
#line 40 "C:\Users\PC\Desktop\Proje\EvrakTakipSistemi\Views\Home\Contact.cshtml"
            
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("    </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EvrakTakipSistemi.Models.ViewModels.Contact> Html { get; private set; }
    }
}
#pragma warning restore 1591