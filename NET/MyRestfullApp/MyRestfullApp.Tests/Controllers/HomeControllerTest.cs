using System.Web.Mvc;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using MyRestfullApp;
using MyRestfullApp.Controllers;

namespace MyRestfullApp.Tests.Controllers
{
    /// <summary>
    /// Pruebas unitarias del <see cref="HomeController"/>.
    /// </summary>
    [TestClass]
    public class HomeControllerTest
    {
        #region Methods

        /// <summary>
        /// Verifica que la accion Index devuelve la vista principal con el titulo "Pagina Principal".
        /// </summary>
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