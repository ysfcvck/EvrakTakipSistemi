#pragma checksum "C:\Users\PC\Desktop\Proje\EvrakTakipSistemi\Views\User\PasswordReset.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3510f1906131957b57e426ab147708966842ade4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_PasswordReset), @"mvc.1.0.view", @"/Views/User/PasswordReset.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3510f1906131957b57e426ab147708966842ade4", @"/Views/User/PasswordReset.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57218c316b6921e2cd61027a2387edc31a2d9471", @"/Views/_ViewImports.cshtml")]
    public class Views_User_PasswordReset : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EvrakTakipSistemi.Models.ViewModels.ResetPasswordViewModel>
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\PC\Desktop\Proje\EvrakTakipSistemi\Views\User\PasswordReset.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3510f1906131957b57e426ab147708966842ade43130", async() => {
                WriteLiteral(@"
    <title>Şifre Yenile</title>
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <meta charset=""utf-8"">
    <link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css"">
    <script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js""></script>
    <script src=""https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js""></script>
");
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3510f1906131957b57e426ab147708966842ade44543", async() => {
                WriteLiteral(@"
    <div class=""container"">
        <div class=""modal fade"" id=""myModal"" role=""dialog"">
            <div class=""modal-dialog"">
                <!-- Modal content-->
                <div class=""modal-content"">
                    <div class=""modal-header"">
                        <h4 class=""modal-title"" style=""text-align:center;"">YENİ ŞİFRE TALEP</h4>
                    </div>
                    <div class=""modal-body"">

");
#nullable restore
#line 27 "C:\Users\PC\Desktop\Proje\EvrakTakipSistemi\Views\User\PasswordReset.cshtml"
                         if (ViewBag.State == null)
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "C:\Users\PC\Desktop\Proje\EvrakTakipSistemi\Views\User\PasswordReset.cshtml"
                             using (Html.BeginForm())
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <label>Eposta:</label>\r\n");
#nullable restore
#line 32 "C:\Users\PC\Desktop\Proje\EvrakTakipSistemi\Views\User\PasswordReset.cshtml"
                           Write(Html.TextBoxFor(x => x.Email, new { @placeholder = "E-posta..", @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                <div class=""modal-footer"">
                                    <button class=""btn btn-primary"" type=""submit"">Şifre Talep Et</button>
                                    <a href=""/user/login"" class=""btn btn-danger"">İptal</a>
                                </div>
");
#nullable restore
#line 38 "C:\Users\PC\Desktop\Proje\EvrakTakipSistemi\Views\User\PasswordReset.cshtml"
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "C:\Users\PC\Desktop\Proje\EvrakTakipSistemi\Views\User\PasswordReset.cshtml"
                             
                        }
                        else
                        {
                            if (ViewBag.State)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                ");
                WriteLiteral(@"<div class=""alert-info"">Şifre talebi için e-posta adresinize bilgilerindirici mail gönderilmiştir.</div><br />
                                <div class=""modal-footer"">
                                    <a href=""/user/login"" class=""btn btn-primary"">Giriş Yap</a>
                                </div>
");
#nullable restore
#line 48 "C:\Users\PC\Desktop\Proje\EvrakTakipSistemi\Views\User\PasswordReset.cshtml"

                            }
                            else
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                ");
                WriteLiteral(@"<div class=""alert-warning"">Böyle bir e-posta bulunmamaktadır.</div><br />
                                <div class=""modal-footer"">
                                    <a href=""/user/passwordreset"" class=""btn btn-primary"">Yeni Şifre Talep Et</a>
                                    <a href=""/user/login"" class=""btn btn-danger"">İptal</a>
                                </div>
");
#nullable restore
#line 57 "C:\Users\PC\Desktop\Proje\EvrakTakipSistemi\Views\User\PasswordReset.cshtml"
                            }
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
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
            WriteLiteral("\r\n</html>\r\n<script>\r\n    $(function () {\r\n        $(\'#myModal\').modal({ backdrop: \'static\', keyboard: false, show: true });\r\n    });\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EvrakTakipSistemi.Models.ViewModels.ResetPasswordViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591