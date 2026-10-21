using System;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using MyRestfullApp.Models;
using MyRestfullApp.Services.Usuarios;

namespace MyRestfullApp.Tests.Services
{
    [TestClass]
    public class UsuariosServiceTest
    {
        #region Methods

        [TestMethod]
        public void ObtenerUsuarios_DevuelveTodosLosUsuarios()
        {
            var service = new UsuariosService();

            var result = service.ObtenerUsuarios();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count >= 3);
            Assert.IsTrue(result.Any(x => x.Email == "joperezr@gmail.com"));
        }

        [TestMethod]
        public void ObtenerUsuario_PorId_DevuelveElUsuario()
        {
            var service = new UsuariosService();

            var result = service.ObtenerUsuario(3);

            Assert.IsNotNull(result);
            Assert.AreEqual("Messi", result.Apellido);
        }

        [TestMethod]
        public void CrearUsuario_AgregaUnUsuario()
        {
            var service = new UsuariosService();
            var email = "email@server" + DateTime.Now.Ticks;

            service.CrearUsuario(new Usuario
            {
                Password = "123456",
                Nombre = "Nombre Prueba",
                Apellido = "Apellido Prueba",
                Email = email
            });

            var creado = service.ObtenerUsuarios().FirstOrDefault(x => x.Email == email);
            Assert.IsNotNull(creado);
        }

        [TestMethod]
        public void ModificarUsuario_ActualizaLosDatos()
        {
            var service = new UsuariosService();
            var email = "email@server" + DateTime.Now.Ticks;

            service.ModificarUsuario(2, new Usuario
            {
                Password = "123456",
                Nombre = "Juan Martin",
                Apellido = "Delpotro",
                Email = email
            });

            var modificado = service.ObtenerUsuario(2);
            Assert.AreEqual("Delpotro", modificado.Apellido);
            Assert.AreEqual("Juan Martin", modificado.Nombre);
        }

        [TestMethod]
        public void EliminarUsuario_QuitaElUsuario()
        {
            var service = new UsuariosService();
            var email = "borrar@server" + DateTime.Now.Ticks;
            service.CrearUsuario(new Usuario
            {
                Password = "123456",
                Nombre = "Borrar",
                Apellido = "Usuario",
                Email = email
            });
            var creado = service.ObtenerUsuarios().First(x => x.Email == email);

            service.EliminarUsuario(creado.Id);

            Assert.IsNull(service.ObtenerUsuario(creado.Id));
        }

        #endregion Methods
    }
}
