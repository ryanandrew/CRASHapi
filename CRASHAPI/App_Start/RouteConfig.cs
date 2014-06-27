﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CRASHAPI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

  /*          routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            */
            routes.MapRoute(
            "Help Area",
            "",
            new { controller = "Help", action = "Index" }
          ).DataTokens = new RouteValueDictionary(new { area = "HelpPage" });
            

        /*routes.MapRoute(
            "Help Area",
            "HelpArea/{controller}/{action}/{id}",
        new { controller = "Help", action = "Index", id = UrlParameter.Optional }
    ).DataTokens.Add("area", "Help Area");*/
        }
    }
}