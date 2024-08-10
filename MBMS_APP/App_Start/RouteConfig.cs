using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace MBMS_APP
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);

            routes.MapPageRoute("Admin Dashboard", "admin-dashboard", "~/WebUI/Dashboard/Dashboard.aspx");
            routes.MapPageRoute("Purchase Orders", "purchase-orders", "~/WebUI/Purchase/Orders.aspx");
            routes.MapPageRoute("View Admin", "view-admin", "~/WebUI/Admin/ViewAdmin.aspx");
            routes.MapPageRoute("View Staff", "view-staff", "~/WebUI/Staff/ViewStaff.aspx");
        }
    }
}
