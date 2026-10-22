using System.Web;
using System.Web.Optimization;

namespace MyRestfullApp
{
    /// <summary>
    /// Configuracion de los bundles de scripts y estilos de la aplicacion
    /// (jQuery, Modernizr, Bootstrap y CSS del sitio).
    /// </summary>
    public class BundleConfig
    {
        #region Methods

        /// <summary>
        /// Registra los bundles de scripts (jQuery, Modernizr, Bootstrap) y
        /// estilos (bootstrap.css, site.css) utilizados por las vistas.
        /// </summary>
        /// <param name="bundles">Coleccion de bundles a la que se agregan los bundles de la aplicacion.</param>
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }

        #endregion Methods
    }
}
