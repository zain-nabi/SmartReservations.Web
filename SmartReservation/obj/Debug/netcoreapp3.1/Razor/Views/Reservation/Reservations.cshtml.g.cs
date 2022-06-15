#pragma checksum "C:\Users\zaino\Documents\Visual Studio 2019\Projects\SmartReservation\SmartReservation\Views\Reservation\Reservations.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9a98ed16a81577275ba4f56ab22e1ee4d9a74a61"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Reservation_Reservations), @"mvc.1.0.view", @"/Views/Reservation/Reservations.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9a98ed16a81577275ba4f56ab22e1ee4d9a74a61", @"/Views/Reservation/Reservations.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f004aab76d2bdcda1a240deaf080d712866ff5de", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Reservation_Reservations : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SmartReservation.Model.Reservation>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\zaino\Documents\Visual Studio 2019\Projects\SmartReservation\SmartReservation\Views\Reservation\Reservations.cshtml"
  
    ViewData["Title"] = "Reservations";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<!-- ========== MAIN ========== -->
<main id=""content"" role=""main"" class=""main"">
    <!-- Content -->
    <div class=""content container-fluid"">
        <!-- Page Header -->
        <div class=""page-header"">
            <div class=""row align-items-end"">
                <div class=""col-sm mb-2 mb-sm-0"">
                    <nav aria-label=""breadcrumb"">
                        <ol class=""breadcrumb breadcrumb-no-gutter"">
                            <li class=""breadcrumb-item""><a class=""breadcrumb-link"" href=""javascript:;"">Reservations</a></li>
                            <li class=""breadcrumb-item active"" aria-current=""page"">Current</li>
                        </ol>
                    </nav>

                    <h1 class=""page-header-title"">All Reservations</h1>
                </div>
            </div>
            <!-- End Row -->
        </div>
        <!-- End Page Header -->
    </div>
    <div class=""content container-fluid my-n9"">
        <div class=""row"">
");
#nullable restore
#line 32 "C:\Users\zaino\Documents\Visual Studio 2019\Projects\SmartReservation\SmartReservation\Views\Reservation\Reservations.cshtml"
             foreach (var item in Model.OrderBy(model => model.Time))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div id=\"stickyBlockStartPoint\" class=\"col-lg-4 mb-3 mb-lg-0\"");
            BeginWriteAttribute("style", " style=\"", 1319, "\"", 1327, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    <div class=""js-sticky-block"" data-hs-sticky-block-options=""{
                   &quot;parentSelector&quot;: &quot;#stickyBlockStartPoint&quot;,
                   &quot;breakpoint&quot;: &quot;lg&quot;,
                   &quot;startPoint&quot;: &quot;#stickyBlockStartPoint&quot;,
                   &quot;endPoint&quot;: &quot;#stickyBlockEndPoint&quot;,
                   &quot;stickyOffsetTop&quot;: 20
                 }""");
            BeginWriteAttribute("style", " style=\"", 1784, "\"", 1792, 0);
            EndWriteAttribute();
            WriteLiteral(@">

                        <!-- End Row -->


                    <div class=""card h-100"">
                            <!-- Header -->
                        <div class=""card-header"" style=""background-color:gold"">

                                <div class=""navbar-collapse collapse d-sm-inline-flex flex-sm-row-reverse"">
                                    <h5 class=""card-header-title"">");
#nullable restore
#line 51 "C:\Users\zaino\Documents\Visual Studio 2019\Projects\SmartReservation\SmartReservation\Views\Reservation\Reservations.cshtml"
                                                             Write(item.RestaurantName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                                    <ul class=\"nav navbar-nav navbar-right\">\r\n                                        <li><a");
            BeginWriteAttribute("href", " href=\"", 2344, "\"", 2433, 1);
#nullable restore
#line 53 "C:\Users\zaino\Documents\Visual Studio 2019\Projects\SmartReservation\SmartReservation\Views\Reservation\Reservations.cshtml"
WriteAttributeValue("", 2351, Url.Action("ReservationOrders", "Order", new{ReservationID = item.reservationID}), 2351, 82, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@"><span class=""glyphicon glyphicon-log-out""></span> Orders</a></li>
                                    </ul>
                                </div>
                            </div>
                            <!-- End Header -->
                            <!-- Body -->
                        <div class=""card-body"" style=""background-color:mintcream"">
                                <dl class=""row"">
                                    <dt class=""col-sm-3"">Name</dt>
                                    <dd class=""col-sm-9"">");
#nullable restore
#line 62 "C:\Users\zaino\Documents\Visual Studio 2019\Projects\SmartReservation\SmartReservation\Views\Reservation\Reservations.cshtml"
                                                    Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n\r\n                                    <dt class=\"col-sm-3\">People</dt>\r\n                                    <dd class=\"col-sm-9\">");
#nullable restore
#line 65 "C:\Users\zaino\Documents\Visual Studio 2019\Projects\SmartReservation\SmartReservation\Views\Reservation\Reservations.cshtml"
                                                    Write(item.People);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n\r\n                                    <dt class=\"col-sm-3\">Time</dt>\r\n                                    <dd class=\"col-sm-9\">");
#nullable restore
#line 68 "C:\Users\zaino\Documents\Visual Studio 2019\Projects\SmartReservation\SmartReservation\Views\Reservation\Reservations.cshtml"
                                                    Write(item.Time);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n\r\n\r\n\r\n                                    <dt class=\"col-sm-3\">Phone</dt>\r\n                                    <dd class=\"col-sm-9\">");
#nullable restore
#line 73 "C:\Users\zaino\Documents\Visual Studio 2019\Projects\SmartReservation\SmartReservation\Views\Reservation\Reservations.cshtml"
                                                    Write(item.Cell);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n\r\n");
#nullable restore
#line 75 "C:\Users\zaino\Documents\Visual Studio 2019\Projects\SmartReservation\SmartReservation\Views\Reservation\Reservations.cshtml"
                                      
                                        var color = "";
                                        var status = "";
                                        if (item.ReservationStatusID == 1)
                                        {
                                            status = "Booked";
                                            color = "success";
                                        }
                                        else if (item.ReservationStatusID == 2)
                                        {
                                            status = "Complete";
                                            color = "danger";
                                        }
                                        else
                                        {
                                            status = "Arrived";
                                            color = "dark";
                                        }
                                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <dt class=\"col-sm-3 text-truncate\">Status</dt>\r\n                                    <dd class=\"col-sm-9\">\r\n                                        <span");
            BeginWriteAttribute("class", " class=\"", 4658, "\"", 4698, 5);
            WriteAttributeValue("", 4666, "badge", 4666, 5, true);
            WriteAttributeValue(" ", 4671, "bg-soft-", 4672, 9, true);
#nullable restore
#line 96 "C:\Users\zaino\Documents\Visual Studio 2019\Projects\SmartReservation\SmartReservation\Views\Reservation\Reservations.cshtml"
WriteAttributeValue("", 4680, color, 4680, 6, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 4686, "text-", 4687, 6, true);
#nullable restore
#line 96 "C:\Users\zaino\Documents\Visual Studio 2019\Projects\SmartReservation\SmartReservation\Views\Reservation\Reservations.cshtml"
WriteAttributeValue("", 4692, color, 4692, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 96 "C:\Users\zaino\Documents\Visual Studio 2019\Projects\SmartReservation\SmartReservation\Views\Reservation\Reservations.cshtml"
                                                                                  Write(status);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                                    </dd>
                                </dl>
                            </div>
                            <!-- End Body -->
                        <div class=""card-footer"">
                                <a");
            BeginWriteAttribute("href", " href=\"", 4966, "\"", 5077, 1);
#nullable restore
#line 102 "C:\Users\zaino\Documents\Visual Studio 2019\Projects\SmartReservation\SmartReservation\Views\Reservation\Reservations.cshtml"
WriteAttributeValue("", 4973, Url.Action("Create","Order", new{reservationID = item.reservationID, RestaurantID = item.RestaurantID}), 4973, 104, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\">Place Order</a>\r\n                                <a");
            BeginWriteAttribute("href", " href=\"", 5154, "\"", 5237, 1);
#nullable restore
#line 103 "C:\Users\zaino\Documents\Visual Studio 2019\Projects\SmartReservation\SmartReservation\Views\Reservation\Reservations.cshtml"
WriteAttributeValue("", 5161, Url.Action("Update","Reservation", new{reservationID = item.reservationID}), 5161, 76, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""btn btn-primary"">Edit</a>
                                <div class=""hs-unfold"">
                                    <a class=""js-hs-unfold-invoker btn btn-primary"" href=""javascript:;"" data-hs-unfold-options=""{
                                            &quot;target&quot;: &quot;#");
#nullable restore
#line 106 "C:\Users\zaino\Documents\Visual Studio 2019\Projects\SmartReservation\SmartReservation\Views\Reservation\Reservations.cshtml"
                                                                  Write(item.reservationID);

#line default
#line hidden
#nullable disable
            WriteLiteral("&quot;,\r\n                                            &quot;type&quot;: &quot;css-animation&quot;\r\n                                        }\" data-hs-unfold-target=\"#");
#nullable restore
#line 108 "C:\Users\zaino\Documents\Visual Studio 2019\Projects\SmartReservation\SmartReservation\Views\Reservation\Reservations.cshtml"
                                                              Write(item.reservationID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-hs-unfold-invoker=\"\">\r\n                                        Actions <i class=\"tio-chevron-down ml-1\"></i>\r\n                                    </a>\r\n\r\n                                    <div");
            BeginWriteAttribute("id", " id=\"", 5936, "\"", 5960, 1);
#nullable restore
#line 112 "C:\Users\zaino\Documents\Visual Studio 2019\Projects\SmartReservation\SmartReservation\Views\Reservation\Reservations.cshtml"
WriteAttributeValue("", 5941, item.reservationID, 5941, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""hs-unfold-content dropdown-unfold dropdown-menu dropdown-menu-sm dropdown-menu-right hs-unfold-content-initialized hs-unfold-css-animation animated hs-unfold-hidden"" data-hs-target-height=""145.078"" data-hs-unfold-content="""" data-hs-unfold-content-animation-in=""slideInUp"" data-hs-unfold-content-animation-out=""fadeOut"" style=""animation-duration: 300ms;"">
                                        <a class=""ml-2""");
            BeginWriteAttribute("href", " href=\"", 6380, "\"", 6492, 1);
#nullable restore
#line 113 "C:\Users\zaino\Documents\Visual Studio 2019\Projects\SmartReservation\SmartReservation\Views\Reservation\Reservations.cshtml"
WriteAttributeValue("", 6387, Url.Action("Arrived","Reservation", new {reservationID =  item.reservationID, ReservationStatusID = 3} ), 6387, 105, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                            Arrived\r\n                                        </a>\r\n                                        <br>\r\n                                        <a class=\"ml-2\"");
            BeginWriteAttribute("href", " href=\"", 6696, "\"", 6809, 1);
#nullable restore
#line 117 "C:\Users\zaino\Documents\Visual Studio 2019\Projects\SmartReservation\SmartReservation\Views\Reservation\Reservations.cshtml"
WriteAttributeValue("", 6703, Url.Action("Complete","Reservation", new {reservationID =  item.reservationID, ReservationStatusID = 2} ), 6703, 106, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                                            Complete
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
");
#nullable restore
#line 126 "C:\Users\zaino\Documents\Visual Studio 2019\Projects\SmartReservation\SmartReservation\Views\Reservation\Reservations.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</main>\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SmartReservation.Model.Reservation>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591