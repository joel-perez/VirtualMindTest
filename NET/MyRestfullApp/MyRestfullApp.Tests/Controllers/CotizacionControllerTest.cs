using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using MyRestfullApp;
using MyRestfullApp.Controllers;
using MyRestfullApp.Models;
using MyRestfullApp.Services.Cotizacion;

namespace MyRestfullApp.Tests.Controllers
{
    [TestClass]
    public class CotizacionControllerTest
    {
        #region Methods

        [TestMethod]
        public void GetDolar()
        {
            // Arrange
            var controller = new CotizacionController();

            // Act
            var result = controller.Get("Dolar");

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetDolarInternal()
        {
            // Arrange
            var cotizacionService = new CotizacionService("Dolar");

            // Act
            var result = cotizacionService.ObtenerCotizacion();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void GetOther()
        {
            // Arrange
            var controller = new CotizacionController();

            // Act
            var result = controller.Get("Other");

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(UnauthorizedAccessException))]
        public void GetPesos()
        {
            // Arrange
            var controller = new CotizacionController();

            // Act
            var result = controller.Get("Real");

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(UnauthorizedAccessException))]
        public void GetReal()
        {
            // Arrange
            var controller = new CotizacionController();

            // Act
            var result = controller.Get("Real");

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(UnauthorizedAccessException))]
        public void GetRealInternal()
        {
            // Arrange
            var cotizacionService = new CotizacionService("Real");

            // Act
            var result = cotizacionService.ObtenerCotizacion();

            // Assert
            Assert.Fail();
        }

        #endregion Methods
    }
}