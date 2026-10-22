using System.Net.Http.Headers;
using System.Web.Http;
using MyRestfullApp.Filters;

namespace MyRestfullApp
{
    /// <summary>
    /// Configuracion de la Web API: filtros globales, rutas por atributo y por defecto,
    /// y formateadores de contenido.
    /// </summary>
    public static class WebApiConfig
    {
        #region Methods

        /// <summary>
        /// Registra la configuracion de la Web API: filtro global de excepciones,
        /// rutas por atributo, ruta por defecto "MyRestfullApp/{controller}/{id}"
        /// y soporte de text/html en el formateador JSON.
        /// </summary>
        /// <param name="config">Configuracion de la Web API a la que se aplican los registros.</param>
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
