using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyRestfullApp.Data;
using MyRestfullApp.Models;

namespace MyRestfullApp.Services.Usuarios
{
    /// <summary>
    /// Servicio de usuarios: operaciones de alta, baja, modificacion y consulta
    /// de usuarios contra la base de datos de la aplicacion (Entity Framework).
    /// </summary>
    public class UsuariosService
    {
        #region Fields

        /// <summary>
        /// Contexto de Entity Framework utilizado para las operaciones contra la base de datos.
        /// </summary>
        private MyRestfullAppEntities _db;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Inicializa una nueva instancia creando el contexto de base de datos.
        /// </summary>
        public UsuariosService()
        {
            _db = new MyRestfullAppEntities();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Crea un usuario nuevo en la base de datos a partir de los datos del modelo.
        /// </summary>
        /// <param name="user">Datos del usuario a crear (nombre, apellido, email y password).</param>
        public void CrearUsuario(Usuario user)
        {
            var newUser = new User { apellido = user.Apellido, email = user.Email, nombre = user.Nombre, password = user.Password };
            _db.User.Add(newUser);
            _db.SaveChanges();
        }

        /// <summary>
        /// Elimina el usuario con el id indicado. Si el usuario no existe, no hace nada.
        /// </summary>
        /// <param name="id">Identificador del usuario a eliminar.</param>
        public void EliminarUsuario(int id)
        {
            var user = _db.User.FirstOrDefault(x => x.id == id);
            if (user == null)
                return;
            _db.User.Remove(user);
            _db.SaveChanges();
        }

        /// <summary>
        /// Actualiza los datos del usuario existente con el id indicado. Si no existe, no hace nada.
        /// </summary>
        /// <param name="id">Identificador del usuario a modificar.</param>
        /// <param name="newUserData">Nuevos datos del usuario (nombre, apellido, email y password).</param>
        public void ModificarUsuario(int id, Usuario newUserData)
        {
            var user = _db.User.FirstOrDefault(x => x.id == id);
            if (user == null)
                return;
            user.apellido = newUserData.Apellido;
            user.email = newUserData.Email;
            user.nombre = newUserData.Nombre;
            user.password = newUserData.Password;
            _db.SaveChanges();
        }

        /// <summary>
        /// Devuelve el usuario con el id indicado, o null si no existe.
        /// </summary>
        /// <param name="id">Identificador del usuario a consultar.</param>
        /// <returns>El <see cref="Usuario"/> encontrado, o null si no hay coincidencia.</returns>
        public Usuario ObtenerUsuario(int id)
        {
            Usuario result = null;
            var user = _db.User.FirstOrDefault(x => x.id == id);
            if (user != null)
                result = new Usuario { Apellido = user.apellido, Email = user.email, Id = user.id, Nombre = user.nombre, Password = user.password };
            return result;
        }

        /// <summary>
        /// Devuelve la lista completa de usuarios registrados.
        /// </summary>
        /// <returns>Coleccion de <see cref="Usuario"/> con todos los usuarios de la base de datos.</returns>
        public List<Usuario> ObtenerUsuarios()
        {
            var users = _db.User.ToList();
            var result = users.Select(user => new Usuario { Apellido = user.apellido, Email = user.email, Id = user.id, Nombre = user.nombre, Password = user.password }).ToList();
            return result;
        }

        #endregion Methods
    }
}
