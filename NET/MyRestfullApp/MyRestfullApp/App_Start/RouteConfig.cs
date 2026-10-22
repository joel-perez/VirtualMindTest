using System.Web.Mvc;
using System.Web.Routing;

namespace MyRestfullApp
{
    /// <summary>
    /// Configuracion de las rutas MVC de la aplicacion (vistas HTML).
    /// </summary>
    public class RouteConfig
    {
        #region Methods

        /// <summary>
        /// Registra las rutas MVC: ignora los recursos .axd y define la ruta por defecto
        /// {controller}/{action}/{id} apuntando a Home/Index.
        /// </summary>
        /// <param name="routes">Coleccion de rutas a la que se agregan las rutas MVC.</param>
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
