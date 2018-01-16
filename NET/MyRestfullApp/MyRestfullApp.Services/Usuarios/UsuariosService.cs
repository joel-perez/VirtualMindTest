using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyRestfullApp.Data;
using MyRestfullApp.Models;

namespace MyRestfullApp.Services.Usuarios
{
    public class UsuariosService
    {
        private MyRestfullAppEntities _db;

        public UsuariosService()
        {
            _db = new MyRestfullAppEntities();
        }

        public List<Usuario> ObtenerUsuarios()
        {
            var users = _db.User.ToList();
            var result = users.Select(user => new Usuario { Apellido = user.apellido, Email = user.email, Id = user.id, Nombre = user.nombre, Password = user.password }).ToList();
            return result;
        }

        public Usuario ObtenerUsuario(int id)
        {
            Usuario result = null;
            var user = _db.User.FirstOrDefault(x => x.id == id);
            if (user != null)
                result = new Usuario { Apellido = user.apellido, Email = user.email, Id = user.id, Nombre = user.nombre, Password = user.password };
            return result;
        }

        public void EliminarUsuario(int id)
        {
            var user = _db.User.FirstOrDefault(x => x.id == id);
            if (user == null)
                return;
            _db.User.Remove(user);
            _db.SaveChanges();
        }

        public void CrearUsuario(Usuario user)
        {
            var newUser = new User { apellido = user.Apellido, email = user.Email, nombre = user.Nombre, password = user.Password };
            _db.User.Add(newUser);
            _db.SaveChanges();
        }

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
    }
}
