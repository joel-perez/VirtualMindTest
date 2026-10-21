using System.Net.Http.Headers;
using System.Web.Http;
using MyRestfullApp.Filters;

namespace MyRestfullApp
{
    public static class WebApiConfig
    {
        #region Methods

        public static void Register(HttpConfiguration config)
        {
            config.Filters.Add(new CustomExceptionFilterAttribute());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "MyRestfullApp/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }

        #endregion Methods
    }
}