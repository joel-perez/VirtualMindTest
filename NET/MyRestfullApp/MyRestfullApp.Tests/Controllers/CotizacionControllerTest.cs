using System;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using MyRestfullApp.Controllers;

namespace MyRestfullApp.Tests.Controllers
{
    /// <summary>
    /// Pruebas unitarias del <see cref="CotizacionController"/>: cotizacion de dolar,
    /// moneda desconocida y monedas no habilitadas (Pesos, Real).
    /// </summary>
    [TestClass]
    public class CotizacionControllerTest
    {
        #region Methods

        /// <summary>
        /// Verifica que consultar la cotizacion del Dolar devuelve una <c>ValorCotizacion</c> no nula.
        /// </summary>
        [TestMethod]
        public async Task GetDolar()
        {
            var controller = new CotizacionController();

            var result = await controller.Get("Dolar");

            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Verifica que una moneda no soportada ("Other") lanza NotImplementedException.
        /// </summary>
        /// <remarks>El filtro global la traduce a HTTP 501 Not Implemented.</remarks>
        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void GetOther()
        {
            var controller = new CotizacionController();
            controller.Get("Other").GetAwaiter().GetResult();
        }

        /// <summary>
        /// Verifica que consultar la cotizacion del Pesos lanza UnauthorizedAccessException (no habilitada).
        /// </summary>
        /// <remarks>El filtro global la traduce a HTTP 401 Unauthorized.</remarks>
        [TestMethod]
        [ExpectedException(typeof(UnauthorizedAccessException))]
        public void GetPesos()
        {
            var controller = new CotizacionController();
            controller.Get("Pesos").GetAwaiter().GetResult();
        }

        /// <summary>
        /// Verifica que consultar la cotizacion del Real lanza UnauthorizedAccessException (no habilitada).
        /// </summary>
        /// <remarks>El filtro global la traduce a HTTP 401 Unauthorized.</remarks>
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
