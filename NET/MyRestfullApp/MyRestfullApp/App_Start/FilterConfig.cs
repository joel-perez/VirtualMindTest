using System.Web;
using System.Web.Mvc;

namespace MyRestfullApp
{
    /// <summary>
    /// Configuracion de los filtros globales MVC de la aplicacion.
    /// </summary>
    public class FilterConfig
    {
        #region Methods

        /// <summary>
        /// Registra los filtros globales MVC; agrega el <see cref="HandleErrorAttribute"/>
        /// para manejo de errores de las vistas.
        /// </summary>
        /// <param name="filters">Coleccion de filtros globales a la que se agrega el filtro de errores.</param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        #endregion Methods
    }
}
