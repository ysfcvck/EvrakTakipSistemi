#pragma checksum "C:\Users\PC\Desktop\Proje\EvrakTakipSistemi\Views\Admin\IncomingDocGet.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bc44bd67e4488a4f69b432b6ba26e0344c904f51"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_IncomingDocGet), @"mvc.1.0.view", @"/Views/Admin/IncomingDocGet.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bc44bd67e4488a4f69b432b6ba26e0344c904f51", @"/Views/Admin/IncomingDocGet.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57218c316b6921e2cd61027a2387edc31a2d9471", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_IncomingDocGet : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EvrakTakipSistemi.Models.ViewModels.IncomingDoc>
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
#line 2 "C:\Users\PC\Desktop\Proje\EvrakTakipSistemi\Views\Admin\IncomingDocGet.cshtml"
  
    ViewData["Title"] = "IncomingDocGet";
    Layout = Layout = "~/Views/Shared/_LayoutAdmin.cshtml";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bc44bd67e4488a4f69b432b6ba26e0344c904f513155", async() => {
                WriteLiteral("\r\n    <script src=\"https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js\"></script>\r\n    <script src=\"https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js\"></script>\r\n    <title>Evrak Düzenle</title>\r\n");
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bc44bd67e4488a4f69b432b6ba26e0344c904f514356", async() => {
                WriteLiteral(@"
    <div class=""container"">
        <div class=""modal fade"" id=""myModal"" role=""dialog"">
            <div class=""modal-dialog"">
                <!-- Modal content-->
                <div class=""modal-content"">
                    <div class=""modal-header"">
                        <h4 class=""modal-title"" style=""text-align:center;"">GELEN EVRAK DÜZENLEME</h4>
                    </div>
                    <div class=""modal-body"">

");
#nullable restore
#line 22 "C:\Users\PC\Desktop\Proje\EvrakTakipSistemi\Views\Admin\IncomingDocGet.cshtml"
                         using (Html.BeginForm("updateincomingdoc", "admin", FormMethod.Post))
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <b>Id</b>\r\n");
#nullable restore
#line 25 "C:\Users\PC\Desktop\Proje\EvrakTakipSistemi\Views\Admin\IncomingDocGet.cshtml"
                       Write(Html.TextBoxFor(x => x.ID, new { @readonly = true, @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <b>Barkod No</b><br />\r\n");
#nullable restore
#line 28 "C:\Users\PC\Desktop\Proje\EvrakTakipSistemi\Views\Admin\IncomingDocGet.cshtml"
                       Write(Html.ValidationMessageFor(model => model.BarcodeNo, "", new { @style = "color:red" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "C:\Users\PC\Desktop\Proje\EvrakTakipSistemi\Views\Admin\IncomingDocGet.cshtml"
                       Write(Html.TextBoxFor(x => x.BarcodeNo, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <b>Belge Tarihi</b><br />\r\n");
#nullable restore
#line 32 "C:\Users\PC\Desktop\Proje\EvrakTakipSistemi\Views\Admin\IncomingDocGet.cshtml"
                       Write(Html.ValidationMessageFor(model => model.DocDate, "", new { @style = "color:red" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 33 "C:\Users\PC\Desktop\Proje\EvrakTakipSistemi\Views\Admin\IncomingDocGet.cshtml"
                       Write(Html.TextBoxFor(x => x.DocDate, "{0:MM/dd/yyyy}", new { @placeholder = "Belge Tarihi (AA.GG.YYYY) Formatında Giriniz..", @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <b>Belge Tipi</b><br />\r\n");
#nullable restore
#line 36 "C:\Users\PC\Desktop\Proje\EvrakTakipSistemi\Views\Admin\IncomingDocGet.cshtml"
                       Write(Html.ValidationMessageFor(model => model.DocType, "", new { @style = "color:red" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 37 "C:\Users\PC\Desktop\Proje\EvrakTakipSistemi\Views\Admin\IncomingDocGet.cshtml"
                       Write(Html.TextBoxFor(x => x.DocType, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <b>Gönderen</b><br />\r\n");
#nullable restore
#line 40 "C:\Users\PC\Desktop\Proje\EvrakTakipSistemi\Views\Admin\IncomingDocGet.cshtml"
                       Write(Html.ValidationMessageFor(model => model.Sender, "", new { @style = "color:red" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 41 "C:\Users\PC\Desktop\Proje\EvrakTakipSistemi\Views\Admin\IncomingDocGet.cshtml"
                       Write(Html.TextBoxFor(x => x.Sender, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <b>Birim Id</b><br />\r\n");
#nullable restore
#line 44 "C:\Users\PC\Desktop\Proje\EvrakTakipSistemi\Views\Admin\IncomingDocGet.cshtml"
                       Write(Html.ValidationMessageFor(model => model.DepartID, "", new { @style = "color:red" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 45 "C:\Users\PC\Desktop\Proje\EvrakTakipSistemi\Views\Admin\IncomingDocGet.cshtml"
                       Write(Html.TextBoxFor(x => x.DepartID, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <b>Personel Id</b><br />\r\n");
#nullable restore
#line 48 "C:\Users\PC\Desktop\Proje\EvrakTakipSistemi\Views\Admin\IncomingDocGet.cshtml"
                       Write(Html.TextBoxFor(x => x.UserID,(String)ViewBag.userId, new {@readonly=true, @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <b>Açıklama</b><br />\r\n");
#nullable restore
#line 51 "C:\Users\PC\Desktop\Proje\EvrakTakipSistemi\Views\Admin\IncomingDocGet.cshtml"
                       Write(Html.ValidationMessageFor(model => model.Descr, "", new { @style = "color:red" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 52 "C:\Users\PC\Desktop\Proje\EvrakTakipSistemi\Views\Admin\IncomingDocGet.cshtml"
                       Write(Html.TextAreaFor(x => x.Descr, new { @class = "form-control", @id = "area" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                            <div class=""modal-footer"">
                                <button class=""btn btn-primary"">Güncelle</button>
                                <a href=""/admin/incomingdoc"" class=""btn btn-danger"">İptal</a>
                            </div>
");
#nullable restore
#line 58 "C:\Users\PC\Desktop\Proje\EvrakTakipSistemi\Views\Admin\IncomingDocGet.cshtml"
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
            WriteLiteral("\r\n<script>\r\n    $(function () {\r\n        $(\'#myModal\').modal({ backdrop: \'static\', keyboard: false, show: true });\r\n    });\r\n</script>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EvrakTakipSistemi.Models.ViewModels.IncomingDoc> Html { get; private set; }
    }
}
#pragma warning restore 1591