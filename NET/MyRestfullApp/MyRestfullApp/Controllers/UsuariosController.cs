using System.Collections.Generic;
using System.Web.Http;
using MyRestfullApp.Models;
using MyRestfullApp.Services.Usuarios;

namespace MyRestfullApp.Controllers
{
    /// <summary>
    /// Controlador para Alta, Baja y Modificacion de Usuarios.
    /// </summary>
    public class UsuariosController : ApiController
    {
        #region Methods

        /// <summary>
        /// Elimina el usuario indicado.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            new UsuariosService().EliminarUsuario(id);
        }

        /// <summary>
        /// Devuelve la lista de los usuarios.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Usuario> Get()
        {
            return new UsuariosService().ObtenerUsuarios();
        }

        /// <summary>
        /// Devuelve informacion de un usuario en particular.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Usuario Get(int id)
        {
            return new UsuariosService().ObtenerUsuario(id);
        }

        /// <summary>
        /// Crea un nuevo usuario.
        /// </summary>
        /// <param name="user"></param>
        public void Post([FromBody]Usuario user)
        {
            new UsuariosService().CrearUsuario(user);
        }

        /// <summary>
        /// Modifica un usuario.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        public void Put(int id, [FromBody]Usuario user)
        {
            new UsuariosService().ModificarUsuario(id, user);
        }

        #endregion Methods
    }
}