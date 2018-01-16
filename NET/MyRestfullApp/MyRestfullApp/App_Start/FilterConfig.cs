using System.Web;
using System.Web.Mvc;

namespace MyRestfullApp
{
    public class FilterConfig
    {
        #region Methods

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        #endregion Methods
    }
}