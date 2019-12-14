#pragma checksum "C:\Users\Atanas\Desktop\code\C-Sharp-Projects\PetStore\Web\PetStore.Web\Views\Categories\All.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6f49d1be98efce6b08f72d053bae07139ec084b2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Categories_All), @"mvc.1.0.view", @"/Views/Categories/All.cshtml")]
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
#line 1 "C:\Users\Atanas\Desktop\code\C-Sharp-Projects\PetStore\Web\PetStore.Web\Views\_ViewImports.cshtml"
using PetStore.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Atanas\Desktop\code\C-Sharp-Projects\PetStore\Web\PetStore.Web\Views\_ViewImports.cshtml"
using PetStore.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Atanas\Desktop\code\C-Sharp-Projects\PetStore\Web\PetStore.Web\Views\_ViewImports.cshtml"
using PetStore.Services.Models.Pet;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Atanas\Desktop\code\C-Sharp-Projects\PetStore\Web\PetStore.Web\Views\_ViewImports.cshtml"
using PetStore.Services.Models.Category;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6f49d1be98efce6b08f72d053bae07139ec084b2", @"/Views/Categories/All.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c528171b4965f50596ee15d034c702bd6552cf55", @"/Views/_ViewImports.cshtml")]
    public class Views_Categories_All : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CategoryListingServiceModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Atanas\Desktop\code\C-Sharp-Projects\PetStore\Web\PetStore.Web\Views\Categories\All.cshtml"
  
    ViewData["Title"] = "All";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>All categories <a href=""/Categories/Add"" class=""btn btn-success float-right"">Add category</a></h1>

<table class=""table table-striped"">
    <thead>
        <tr>
            <th>Name</th>
            <th></th>
        </tr>
    </thead>

    <tbody>
");
#nullable restore
#line 18 "C:\Users\Atanas\Desktop\code\C-Sharp-Projects\PetStore\Web\PetStore.Web\Views\Categories\All.cshtml"
         foreach (var category in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <th scope=\"row\">");
#nullable restore
#line 21 "C:\Users\Atanas\Desktop\code\C-Sharp-Projects\PetStore\Web\PetStore.Web\Views\Categories\All.cshtml"
                           Write(category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th>\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 524, "\"", 560, 2);
            WriteAttributeValue("", 531, "/Categories/Info/", 531, 17, true);
#nullable restore
#line 23 "C:\Users\Atanas\Desktop\code\C-Sharp-Projects\PetStore\Web\PetStore.Web\Views\Categories\All.cshtml"
WriteAttributeValue("", 548, category.Id, 548, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-info\">Info</a>\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 615, "\"", 653, 2);
            WriteAttributeValue("", 622, "/Categories/Delete/", 622, 19, true);
#nullable restore
#line 24 "C:\Users\Atanas\Desktop\code\C-Sharp-Projects\PetStore\Web\PetStore.Web\Views\Categories\All.cshtml"
WriteAttributeValue("", 641, category.Id, 641, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger\">Delete</a>\r\n                </th>\r\n            </tr>\r\n");
#nullable restore
#line 27 "C:\Users\Atanas\Desktop\code\C-Sharp-Projects\PetStore\Web\PetStore.Web\Views\Categories\All.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CategoryListingServiceModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
