#pragma checksum "C:\Users\zaino\Documents\Visual Studio 2019\Projects\SmartReservation\SmartReservation\Views\Restaurant\Restaurants.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2bb7abed4aa9a37e902b0a50b3e9610251c4ce0f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Restaurant_Restaurants), @"mvc.1.0.view", @"/Views/Restaurant/Restaurants.cshtml")]
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
#line 1 "C:\Users\zaino\Documents\Visual Studio 2019\Projects\SmartReservation\SmartReservation\Views\_ViewImports.cshtml"
using SmartReservation;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\zaino\Documents\Visual Studio 2019\Projects\SmartReservation\SmartReservation\Views\_ViewImports.cshtml"
using SmartReservation.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2bb7abed4aa9a37e902b0a50b3e9610251c4ce0f", @"/Views/Restaurant/Restaurants.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f004aab76d2bdcda1a240deaf080d712866ff5de", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Restaurant_Restaurants : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SmartReservation.Model.Restaurant>>
    #nullable disable
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\zaino\Documents\Visual Studio 2019\Projects\SmartReservation\SmartReservation\Views\Restaurant\Restaurants.cshtml"
  
    ViewData["Title"] = "Restaurants";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<main id=""content"" role=""main"" class=""main"">
    <div class=""content container-fluid"">
        <div class=""page-header"">
            <div class=""row align-items-end"">
                <div class=""col-sm mb-2 mb-sm-0"">
                    <nav aria-label=""breadcrumb"">
                        <ol class=""breadcrumb breadcrumb-no-gutter"">
                            <li class=""breadcrumb-item""><a class=""breadcrumb-link"" href=""javascript:;"">Restaurants</a></li>
                            <li class=""breadcrumb-item""><a class=""breadcrumb-link"" href=""javascript:;"">Overview</a></li>
                        </ol>
                    </nav>

                    <h1 class=""page-header-title"">Active Restaurants</h1>
                </div>
            </div>
            <!-- End Row -->
        </div>
        <div class=""card"">
            <!-- Header -->
            <div class=""card-header"">
                <div class=""row justify-content-between align-items-center flex-grow-1"">
                    ");
            WriteLiteral("<div class=\"col-lg-6 mb-3 mb-lg-0\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2bb7abed4aa9a37e902b0a50b3e9610251c4ce0f4951", async() => {
                WriteLiteral(@"
                            <!-- Search -->
                            <div class=""input-group input-group-merge input-group-flush"">
                                <div class=""input-group-prepend"">
                                    <div class=""input-group-text"">
                                        <i class=""tio-search""></i>
                                    </div>
                                </div>
                                <input id=""datatableSearch"" type=""search"" class=""form-control"" placeholder=""Search orders"" aria-label=""Search orders"">
                            </div>
                            <!-- End Search -->
                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    </div>
                </div>
                <!-- End Row -->
            </div>
            <!-- End Header -->
            <!-- Table -->
            <div class=""table-responsive datatable-custom"">
                <div id=""datatable_wrapper"" class=""dataTables_wrapper no-footer"">
                    <table id=""datatable"" class=""table table-hover table-borderless table-thead-bordered table-nowrap table-align-middle card-table dataTable no-footer"" style=""width: 100%;"" data-hs-datatables-options='{
              ""order"": [],
             ""columnDefs"": [ {
                            ""targets"": 5,
                            ""orderable"": false
             } ],
             ""info"": {
               ""totalQty"": ""#datatableEntriesInfoTotalQty""
             },
             ""entries"": ""#datatableEntries"",
             ""isResponsive"": false,
             ""isShowPaging"": false,
             ""pagination"": ""datatableEntriesPagination""
                   }'>
                  ");
            WriteLiteral(@"      <thead class=""thead-light"">
                            <tr role=""row"">
                                <th>Name</th>
                                <th>Created On</th>
                                <th>Location</th>
                                <th>Phone</th>
                                <th>Active</th>
                                <th>Actions</th>
                            </tr>
                        </thead>

                        <tbody>
");
#nullable restore
#line 76 "C:\Users\zaino\Documents\Visual Studio 2019\Projects\SmartReservation\SmartReservation\Views\Restaurant\Restaurants.cshtml"
                             foreach (var item in Model)
                            {


#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr");
            BeginWriteAttribute("class", " class=\"", 3567, "\"", 3575, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                    <td class=""align-middle"">
                                        <a class=""d-flex align-items-center"">
                                            <div class=""avatar avatar-soft-primary avatar-circle"">
                                                <span class=""avatar-initials"">");
#nullable restore
#line 83 "C:\Users\zaino\Documents\Visual Studio 2019\Projects\SmartReservation\SmartReservation\Views\Restaurant\Restaurants.cshtml"
                                                                         Write(item.Name.Substring(0, 1));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                            </div>\r\n                                            <div class=\"ml-3\">\r\n                                                <span class=\"d-block h5 text-hover-primary mb-0\">");
#nullable restore
#line 86 "C:\Users\zaino\Documents\Visual Studio 2019\Projects\SmartReservation\SmartReservation\Views\Restaurant\Restaurants.cshtml"
                                                                                            Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                                            </div>
                                        </a>
                                    </td>
                                    <td class=""align-middle"">
                                        <div class=""media align-items-center"">
                                            <span>");
#nullable restore
#line 92 "C:\Users\zaino\Documents\Visual Studio 2019\Projects\SmartReservation\SmartReservation\Views\Restaurant\Restaurants.cshtml"
                                             Write(item.CreatedOn.ToString("dd MMMM yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                        </div>\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 96 "C:\Users\zaino\Documents\Visual Studio 2019\Projects\SmartReservation\SmartReservation\Views\Restaurant\Restaurants.cshtml"
                                   Write(item.Location);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 99 "C:\Users\zaino\Documents\Visual Studio 2019\Projects\SmartReservation\SmartReservation\Views\Restaurant\Restaurants.cshtml"
                                   Write(item.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 102 "C:\Users\zaino\Documents\Visual Studio 2019\Projects\SmartReservation\SmartReservation\Views\Restaurant\Restaurants.cshtml"
                                   Write(item.Active);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n");
#nullable restore
#line 104 "C:\Users\zaino\Documents\Visual Studio 2019\Projects\SmartReservation\SmartReservation\Views\Restaurant\Restaurants.cshtml"
                                     if (User.IsInRole("Admin"))
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                        <td class=""align-middle"">
                                            <div class=""hs-unfold"">
                                                <a class=""js-hs-unfold-invoker btn btn-sm btn-white"" href=""javascript:;"" data-hs-unfold-options=""{
                                            &quot;target&quot;: &quot;#");
#nullable restore
#line 109 "C:\Users\zaino\Documents\Visual Studio 2019\Projects\SmartReservation\SmartReservation\Views\Restaurant\Restaurants.cshtml"
                                                                  Write(item.restaurantID);

#line default
#line hidden
#nullable disable
            WriteLiteral("&quot;,\r\n                                            &quot;type&quot;: &quot;css-animation&quot;\r\n                                        }\" data-hs-unfold-target=\"#");
#nullable restore
#line 111 "C:\Users\zaino\Documents\Visual Studio 2019\Projects\SmartReservation\SmartReservation\Views\Restaurant\Restaurants.cshtml"
                                                              Write(item.restaurantID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-hs-unfold-invoker=\"\">\r\n                                                    Actions <i class=\"tio-chevron-down ml-1\"></i>\r\n                                                </a>\r\n\r\n                                                <div");
            BeginWriteAttribute("id", " id=\"", 5956, "\"", 5979, 1);
#nullable restore
#line 115 "C:\Users\zaino\Documents\Visual Studio 2019\Projects\SmartReservation\SmartReservation\Views\Restaurant\Restaurants.cshtml"
WriteAttributeValue("", 5961, item.restaurantID, 5961, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""hs-unfold-content dropdown-unfold dropdown-menu dropdown-menu-sm dropdown-menu-right hs-unfold-content-initialized hs-unfold-css-animation animated hs-unfold-hidden"" data-hs-target-height=""145.078"" data-hs-unfold-content="""" data-hs-unfold-content-animation-in=""slideInUp"" data-hs-unfold-content-animation-out=""fadeOut"" style=""animation-duration: 300ms;"">
                                                    <a class=""btn btn-sm btn-white""");
            BeginWriteAttribute("href", " href=\"", 6427, "\"", 6482, 1);
#nullable restore
#line 116 "C:\Users\zaino\Documents\Visual Studio 2019\Projects\SmartReservation\SmartReservation\Views\Restaurant\Restaurants.cshtml"
WriteAttributeValue("", 6434, Url.Action("Update", new { item.restaurantID} ), 6434, 48, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                                                        <i class=""tio-receipt-outlined mr-1""></i> Update
                                                    </a>
                                                </div>
                                            </div>
                                        </td>
");
#nullable restore
#line 122 "C:\Users\zaino\Documents\Visual Studio 2019\Projects\SmartReservation\SmartReservation\Views\Restaurant\Restaurants.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                        <td class=""align-middle"">
                                            <div class=""hs-unfold"">
                                                <a class=""js-hs-unfold-invoker btn btn-sm btn-white"" href=""javascript:;"" data-hs-unfold-options=""{
                                            &quot;target&quot;: &quot;#");
#nullable restore
#line 128 "C:\Users\zaino\Documents\Visual Studio 2019\Projects\SmartReservation\SmartReservation\Views\Restaurant\Restaurants.cshtml"
                                                                  Write(item.restaurantID);

#line default
#line hidden
#nullable disable
            WriteLiteral("&quot;,\r\n                                            &quot;type&quot;: &quot;css-animation&quot;\r\n                                        }\" data-hs-unfold-target=\"#");
#nullable restore
#line 130 "C:\Users\zaino\Documents\Visual Studio 2019\Projects\SmartReservation\SmartReservation\Views\Restaurant\Restaurants.cshtml"
                                                              Write(item.restaurantID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-hs-unfold-invoker=\"\">\r\n                                                    Actions <i class=\"tio-chevron-down ml-1\"></i>\r\n                                                </a>\r\n\r\n                                                <div");
            BeginWriteAttribute("id", " id=\"", 7718, "\"", 7741, 1);
#nullable restore
#line 134 "C:\Users\zaino\Documents\Visual Studio 2019\Projects\SmartReservation\SmartReservation\Views\Restaurant\Restaurants.cshtml"
WriteAttributeValue("", 7723, item.restaurantID, 7723, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""hs-unfold-content dropdown-unfold dropdown-menu dropdown-menu-sm dropdown-menu-right hs-unfold-content-initialized hs-unfold-css-animation animated hs-unfold-hidden"" data-hs-target-height=""145.078"" data-hs-unfold-content="""" data-hs-unfold-content-animation-in=""slideInUp"" data-hs-unfold-content-animation-out=""fadeOut"" style=""animation-duration: 300ms;"">
                                                    <a class=""btn btn-sm btn-white""");
            BeginWriteAttribute("href", " href=\"", 8189, "\"", 8273, 1);
#nullable restore
#line 135 "C:\Users\zaino\Documents\Visual Studio 2019\Projects\SmartReservation\SmartReservation\Views\Restaurant\Restaurants.cshtml"
WriteAttributeValue("", 8196, Url.Action("Create","Reservation", new {RestaurantID =  item.restaurantID} ), 8196, 77, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                                                        <i class=""tio-receipt-outlined mr-1""></i> RSVP
                                                    </a>
                                                </div>
                                            </div>
                                        </td>
");
#nullable restore
#line 141 "C:\Users\zaino\Documents\Visual Studio 2019\Projects\SmartReservation\SmartReservation\Views\Restaurant\Restaurants.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </tr>\r\n");
#nullable restore
#line 143 "C:\Users\zaino\Documents\Visual Studio 2019\Projects\SmartReservation\SmartReservation\Views\Restaurant\Restaurants.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </tbody>
                    </table>
                </div>
            </div>
            <!-- End Table -->
            <!-- Footer -->
            <div class=""card-footer"">
                <!-- Pagination -->
                <div class=""row justify-content-center justify-content-sm-between align-items-sm-center"">
                    <div class=""col-sm mb-2 mb-sm-0"">
");
            WriteLiteral(@"                    </div>

                    <div class=""col-sm-auto"">
                        <div class=""d-flex justify-content-center justify-content-sm-end"">
                            <!-- Pagination -->
                            <nav id=""datatableEntriesPagination"" aria-label=""Activity pagination""></nav>
                        </div>
                    </div>
                </div>
                <!-- End Pagination -->
            </div>
            <!-- End Footer -->
        </div>
    </div>
</main>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SmartReservation.Model.Restaurant>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
