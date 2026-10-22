using System;
using System.Threading.Tasks;

using MyRestfullApp.Models;

namespace MyRestfullApp.Services.Cotizacion
{
    /// <summary>
    /// Estrategia para la cotizacion del Real brasileño.
    /// Actualmente no esta implementada y siempre deniega el acceso.
    /// </summary>
    public class RealCotizacionStrategy : ICotizacionStrategy
    {
        #region Methods

        /// <summary>
        /// Devuelve la cotizacion del Real.
        /// </summary>
        /// <returns>Esta implementacion nunca retorna valor: siempre lanza excepcion.</returns>
        /// <exception cref="UnauthorizedAccessException">Siempre, ya que la cotizacion del Real no esta habilitada.</exception>
        public Task<ValorCotizacion> ObtenerCotizacion()
        {
            throw new UnauthorizedAccessException();
        }

        #endregion Methods
    }
}
