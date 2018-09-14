using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace serniaMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Index", action = "Index", id = UrlParameter.Optional }
            //);

            routes.MapRoute(
                name: "Index",
                url: string.Empty,
                defaults: new { controller = "Index", action = "Index", lan = "ja" }
            );

            routes.MapRoute(
                name: "Index2",
                url: "index/index2",
                defaults: new { controller = "Index", action = "Index2", lan = "ja" }
            );

            routes.MapRoute(
                name: "Admin",
                url: "Admin/{action}/{id}",
                defaults: new { controller = "Admin", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Sernia",
                url: "{lan}/Sernia/",
                defaults: new { controller = "Sernia", action = "Index", lan = "ja" }
            );

            routes.MapRoute(
                name: "Dev",
                url: "{lan}/Dev/{page}",
                defaults: new { controller = "Dev", action = "Index", page = UrlParameter.Optional, lan = "ja" }
            );

            routes.MapRoute(
                name: "DevDetails",
                url: "{lan}/Dev/Details/{id}",
                defaults: new { controller = "Dev", action = "Details", id = UrlParameter.Optional, lan = "ja" }
            );
        }
    }
}