﻿using System.Web.Mvc;
using System.Web.Routing;

namespace MyRestfullApp
{
    /// <summary>
    /// 
    /// </summary>
    public class RouteConfig
    {
        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="routes"></param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }

        #endregion Methods
    }
}