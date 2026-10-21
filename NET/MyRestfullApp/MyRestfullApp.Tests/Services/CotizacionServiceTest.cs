using System;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using MyRestfullApp.Services.Cotizacion;
using MyRestfullApp.Services.Helpers;

namespace MyRestfullApp.Tests.Services
{
    [TestClass]
    public class CotizacionServiceTest
    {
        #region Methods

        [TestMethod]
        public async Task ObtenerCotizacion_Dolar_DevuelveCompraYVenta()
        {
            var cotizacionService = new CotizacionService("Dolar");

            var result = await cotizacionService.ObtenerCotizacion();

            Assert.IsNotNull(result);
            Assert.AreEqual(BancoProvinciaCotizacionStub.Compra, result.Compra);
            Assert.AreEqual(BancoProvinciaCotizacionStub.Venta, result.Venta);
        }

        [TestMethod]
        [ExpectedException(typeof(UnauthorizedAccessException))]
        public void ObtenerCotizacion_Pesos_NoAutorizado()
        {
            var cotizacionService = new CotizacionService("Pesos");
            cotizacionService.ObtenerCotizacion().GetAwaiter().GetResult();
        }

        [TestMethod]
        [ExpectedException(typeof(UnauthorizedAccessException))]
        public void ObtenerCotizacion_Real_NoAutorizado()
        {
            var cotizacionService = new CotizacionService("Real");
            cotizacionService.ObtenerCotizacion().GetAwaiter().GetResult();
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void ObtenerCotizacion_MonedaDesconocida_NoImplementado()
        {
            var cotizacionService = new CotizacionService("Euro");
        }

        #endregion Methods
    }
}
