using System;
using System.Threading.Tasks;

using MyRestfullApp.Models;

namespace MyRestfullApp.Services.Cotizacion
{
    public class RealCotizacionStrategy : ICotizacionStrategy
    {
        #region Methods

        /// <summary>
        /// Devuelve la cotizacion del Real.
        /// </summary>
        /// <returns></returns>
        public Task<ValorCotizacion> ObtenerCotizacion()
        {
            throw new UnauthorizedAccessException();
        }

        #endregion Methods
    }
}