using System.Web.Http;
using System.Web.Mvc;

namespace MyRestfullApp.Areas.HelpPage
{
    public class HelpPageAreaRegistration : AreaRegistration
    {
        #region Properties

        public override string AreaName
        {
            get
            {
                return "HelpPage";
            }
        }

        #endregion Properties

        #region Methods

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "HelpPage_Default",
                "Help/{action}/{apiId}",
                new { controller = "Help", action = "Index", apiId = UrlParameter.Optional });

            HelpPageConfig.Register(GlobalConfiguration.Configuration);
        }

        #endregion Methods
    }
}