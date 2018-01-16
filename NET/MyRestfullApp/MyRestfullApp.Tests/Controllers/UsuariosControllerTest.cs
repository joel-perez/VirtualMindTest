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

namespace MyRestfullApp.Tests.Controllers
{
    [TestClass]
    public class UsuariosControllerTest
    {
        #region Methods

        [TestMethod]
        public void Get()
        {
            // Arrange
            UsuariosController controller = new UsuariosController();

            // Act
            IEnumerable<Usuario> result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count());
            Assert.AreEqual("joperezr@gmail.com", result.ElementAt(0).Email);
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            UsuariosController controller = new UsuariosController();

            // Act
            Usuario result = controller.Get(3);

            // Assert
            Assert.AreEqual("Messi", result.Apellido);
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            UsuariosController controller = new UsuariosController();

            // Act
            controller.Post(new Usuario { Password = "123456", Nombre = "Nombre Prueba", Apellido = "Apellido Prueba", Email = "email@server" + DateTime.Now.Ticks });

            // Assert
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            UsuariosController controller = new UsuariosController();

            // Act
            controller.Delete(4);

            // Assert
        }


        [TestMethod]
        public void Put()
        {
            // Arrange
            UsuariosController controller = new UsuariosController();

            // Act
            controller.Put(2, new Usuario { Password = "123456", Nombre = "Juan Martin", Apellido = "Delpotro", Email = "email@server" + DateTime.Now.Ticks });

            // Assert
        }

        #endregion Methods
    }
}