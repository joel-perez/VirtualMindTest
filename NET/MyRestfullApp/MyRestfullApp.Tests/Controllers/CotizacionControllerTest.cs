using System;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using MyRestfullApp.Controllers;

namespace MyRestfullApp.Tests.Controllers
{
    [TestClass]
    public class CotizacionControllerTest
    {
        #region Methods

        [TestMethod]
        public async Task GetDolar()
        {
            var controller = new CotizacionController();

            var result = await controller.Get("Dolar");

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void GetOther()
        {
            var controller = new CotizacionController();
            controller.Get("Other").GetAwaiter().GetResult();
        }

        [TestMethod]
        [ExpectedException(typeof(UnauthorizedAccessException))]
        public void GetPesos()
        {
            var controller = new CotizacionController();
            controller.Get("Pesos").GetAwaiter().GetResult();
        }

        [TestMethod]
        [ExpectedException(typeof(UnauthorizedAccessException))]
        public void GetReal()
        {
            var controller = new CotizacionController();
            controller.Get("Real").GetAwaiter().GetResult();
        }

        #endregion Methods
    }
}
