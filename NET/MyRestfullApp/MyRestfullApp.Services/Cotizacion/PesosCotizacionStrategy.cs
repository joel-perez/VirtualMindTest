using System;
using System.Threading.Tasks;

using MyRestfullApp.Models;

namespace MyRestfullApp.Services.Cotizacion
{
    public class PesosCotizacionStrategy : ICotizacionStrategy
    {
        #region Methods

        /// <summary>
        /// Devuelve la cotizacion del Peso.
        /// </summary>
        /// <returns></returns>
        public Task<ValorCotizacion> ObtenerCotizacion()
        {
            throw new UnauthorizedAccessException();
        }

        #endregion Methods
    }
}