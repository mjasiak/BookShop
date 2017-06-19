using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Shop.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "SearchStringApi",
                routeTemplate: "api/{controller}/{action}/{searchString}"
            );

            config.Routes.MapHttpRoute(
                name: "TypeApi",
                routeTemplate: "api/{controller}/{action}/{type}"
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/"
            );

        }
    }
}
