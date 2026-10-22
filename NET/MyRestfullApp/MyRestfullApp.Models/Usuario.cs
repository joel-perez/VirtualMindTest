namespace MyRestfullApp.Models
{
    /// <summary>
    /// Modelo de transferencia de datos que representa a un usuario del sistema.
    /// Se usa en los endpoints de alta, baja, modificacion y consulta de usuarios.
    /// </summary>
    public class Usuario
    {
        #region Properties

        /// <summary>
        /// Identificador unico del usuario asignado por el sistema.
        /// </summary>
        /// <value>Valor entero identificador; 0 en objetos nuevos sin persistir.</value>
        public int Id
        {
            get; set;
        }

        /// <summary>
        /// Nombre del usuario.
        /// </summary>
        /// <value>Cadena con el nombre.</value>
        public string Nombre
        {
            get; set;
        }

        /// <summary>
        /// Apellido del usuario.
        /// </summary>
        /// <value>Cadena con el apellido.</value>
        public string Apellido
        {
            get; set;
        }

        /// <summary>
        /// Correo electronico del usuario; se usa como dato de contacto.
        /// </summary>
        /// <value>Cadena con la direccion de correo electronico.</value>
        public string Email
        {
            get; set;
        }

        /// <summary>
        /// Password del usuario.
        /// </summary>
        /// <value>Cadena con la contrasena en texto plano tal como se almacena en la base de datos.</value>
        public string Password
        {
            get; set;
        }

        #endregion Properties
    }
}
