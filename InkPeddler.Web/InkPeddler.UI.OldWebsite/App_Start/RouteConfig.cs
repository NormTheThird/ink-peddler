using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI.WebControls;

namespace InkPeddler.UI.Website
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{resource}.js/{*pathInfo}");
            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "TattooRouting",
                url: "Tattoo/{name}",
                defaults: new { controller = "Tattoo", action = "Index" }
            );
            routes.MapRoute(
                name: "ShopRouting",
                url: "Shop/{name}",
                defaults: new { controller = "Shop", action = "Index" }
            );
            routes.MapRoute(
                name: "ArtistRouting",
                url: "Artist/{name}",
                defaults: new { controller = "Artist", action = "Index" }
            );
            routes.MapRoute(
                name: "UserRouting",
                url: "User/{name}",
                defaults: new { controller = "User", action = "Index" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
