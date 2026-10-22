using System.Web.Mvc;

namespace MyRestfullApp.Controllers
{
    /// <summary>
    /// Controlador MVC que sirve las vistas HTML de la aplicacion,
    /// incluida la pagina principal que da acceso a la API.
    /// </summary>
    public class HomeController : Controller
    {
        #region Methods

        /// <summary>
        /// Pagina Principal
        /// </summary>
        /// <returns>La vista <c>Index</c> de la pagina principal.</returns>
        public ActionResult Index()
        {
            ViewBag.Title = "Pagina Principal";
            return View();
        }

        #endregion Methods
    }
}
