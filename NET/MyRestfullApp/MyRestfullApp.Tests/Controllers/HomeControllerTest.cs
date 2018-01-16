using System.Web.Mvc;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using MyRestfullApp;
using MyRestfullApp.Controllers;

namespace MyRestfullApp.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        #region Methods

        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Pagina Principal", result.ViewBag.Title);
        }

        #endregion Methods
    }
}