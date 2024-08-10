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

            routes.MapPageRoute("Member", "member", "~/WebUI/Member/Member.aspx");
            routes.MapPageRoute("Add Member", "add-member", "~/WebUI/Member/AddMember.aspx");
        }
    }
}
