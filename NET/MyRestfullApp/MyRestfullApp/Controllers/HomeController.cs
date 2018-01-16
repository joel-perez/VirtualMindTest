using System.Web.Mvc;

namespace MyRestfullApp.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class HomeController : Controller
    {
        #region Methods

        /// <summary>
        /// Pagina Principal
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.Title = "Pagina Principal";
            return View();
        }

        #endregion Methods
    }
}