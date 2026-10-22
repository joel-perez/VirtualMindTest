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
    /// <summary>
    /// Pruebas unitarias del <see cref="UsuariosController"/>: consulta, alta, baja y modificacion de usuarios.
    /// Requiere una base de datos con datos de prueba precargados (3 usuarios, id 2 y 3 conocidos).
    /// </summary>
    [TestClass]
    public class UsuariosControllerTest
    {
        #region Methods

        /// <summary>
        /// Verifica que el listado de usuarios devuelve 3 usuarios con el primero esperado.
        /// </summary>
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

        /// <summary>
        /// Verifica que obtener un usuario por id devuelve el usuario correcto (id 3 = Messi).
        /// </summary>
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

        /// <summary>
        /// Verifica que crear un usuario no lanza excepciones (alta exitosa).
        /// </summary>
        [TestMethod]
        public void Post()
        {
            // Arrange
            UsuariosController controller = new UsuariosController();

            // Act
            controller.Post(new Usuario { Password = "123456", Nombre = "Nombre Prueba", Apellido = "Apellido Prueba", Email = "email@server" + DateTime.Now.Ticks });

            // Assert
        }

        /// <summary>
        /// Verifica que eliminar un usuario por id no lanza excepciones (baja exitosa).
        /// </summary>
        [TestMethod]
        public void Delete()
        {
            // Arrange
            UsuariosController controller = new UsuariosController();

            // Act
            controller.Delete(4);

            // Assert
        }


        /// <summary>
        /// Verifica que modificar un usuario por id no lanza excepciones (modificacion exitosa).
        /// </summary>
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