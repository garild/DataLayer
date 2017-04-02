using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Ts3.pl
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index", /*Id = UrlParameter.Optional*/ }
            );
            routes.MapRoute(
               name: "Forum",
               url: "{controller}/{action}/{Id}",
               defaults: new { controller = "Forum", action = "Posts", Id = UrlParameter.Optional }
           );
        }
    }
}
