using System.Collections.Generic;
using System.Web.Http;

using MyRestfullApp.Models;
using MyRestfullApp.Services.Usuarios;

namespace MyRestfullApp.Controllers
{
    /// <summary>
    /// Controlador REST para Alta, Baja y Modificacion de Usuarios.
    /// </summary>
    public class UsuariosController : ApiController
    {
        #region Methods

        /// <summary>
        /// Elimina el usuario indicado.
        /// </summary>
        /// <param name="id">Identificador del usuario a eliminar.</param>
        /// <remarks>Responde 204 No Content; si el id no existe la operacion no tiene efecto.</remarks>
        [HttpDelete]
        public void Delete(int id)
        {
            new UsuariosService().EliminarUsuario(id);
        }

        /// <summary>
        /// Devuelve la lista de los usuarios.
        /// </summary>
        /// <returns>Coleccion con todos los <see cref="Usuario"/> registrados.</returns>
        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            return new UsuariosService().ObtenerUsuarios();
        }

        /// <summary>
        /// Devuelve informacion de un usuario en particular.
        /// </summary>
        /// <param name="id">Identificador del usuario a consultar.</param>
        /// <returns>El <see cref="Usuario"/> solicitado, o null si no existe.</returns>
        [HttpGet]
        public Usuario Get(int id)
        {
            return new UsuariosService().ObtenerUsuario(id);
        }

        /// <summary>
        /// Crea un nuevo usuario.
        /// </summary>
        /// <param name="user">Datos del usuario a crear, recibidos en el cuerpo de la peticion.</param>
        [HttpPost]
        public void Post([FromBody]Usuario user)
        {
            new UsuariosService().CrearUsuario(user);
        }

        /// <summary>
        /// Modifica un usuario.
        /// </summary>
        /// <param name="id">Identificador del usuario a modificar.</param>
        /// <param name="user">Nuevos datos del usuario, recibidos en el cuerpo de la peticion.</param>
        /// <remarks>Si el id no existe la operacion no tiene efecto.</remarks>
        [HttpPut]
        public void Put(int id, [FromBody]Usuario user)
        {
            new UsuariosService().ModificarUsuario(id, user);
        }

        #endregion Methods
    }
}
