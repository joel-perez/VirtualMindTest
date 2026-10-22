using System;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using MyRestfullApp.Services.Cotizacion;
using MyRestfullApp.Services.Helpers;

namespace MyRestfullApp.Tests.Services
{
    /// <summary>
    /// Pruebas unitarias del <see cref="CotizacionService"/>: flujo del dolar (stub),
    /// monedas no autorizadas y moneda desconocida.
    /// </summary>
    [TestClass]
    public class CotizacionServiceTest
    {
        #region Methods

        /// <summary>
        /// Verifica que la cotizacion del Dolar devuelve los importes historicos del stub del Banco Provincia.
        /// </summary>
        [TestMethod]
        public async Task ObtenerCotizacion_Dolar_DevuelveCompraYVenta()
        {
            var cotizacionService = new CotizacionService("Dolar");

            var result = await cotizacionService.ObtenerCotizacion();

            Assert.IsNotNull(result);
            Assert.AreEqual(BancoProvinciaCotizacionStub.Compra, result.Compra);
            Assert.AreEqual(BancoProvinciaCotizacionStub.Venta, result.Venta);
        }

        /// <summary>
        /// Verifica que la estrategia de Pesos lanza UnauthorizedAccessException al cotizar.
        /// </summary>
        /// <remarks>La excepcion se produce dentro del await de ObtenerCotizacion.</remarks>
        [TestMethod]
        [ExpectedException(typeof(UnauthorizedAccessException))]
        public void ObtenerCotizacion_Pesos_NoAutorizado()
        {
            var cotizacionService = new CotizacionService("Pesos");
            cotizacionService.ObtenerCotizacion().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Verifica que la estrategia de Real lanza UnauthorizedAccessException al cotizar.
        /// </summary>
        /// <remarks>La excepcion se produce dentro del await de ObtenerCotizacion.</remarks>
        [TestMethod]
        [ExpectedException(typeof(UnauthorizedAccessException))]
        public void ObtenerCotizacion_Real_NoAutorizado()
        {
            var cotizacionService = new CotizacionService("Real");
            cotizacionService.ObtenerCotizacion().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Verifica que construir el servicio con una moneda no soportada ("Euro")
        /// lanza NotImplementedException en el constructor.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void ObtenerCotizacion_MonedaDesconocida_NoImplementado()
        {
            var cotizacionService = new CotizacionService("Euro");
        }

        #endregion Methods
    }
}
