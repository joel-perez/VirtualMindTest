using System.Threading.Tasks;

using MyRestfullApp.Models;

namespace MyRestfullApp.Services.Cotizacion
{
    /// <summary>
    /// Interface que implementan las diferentes estrategias para Cotizacion.
    /// Define el contrato comun para obtener el valor de una moneda determinada.
    /// </summary>
    public interface ICotizacionStrategy
    {
        #region Methods

        /// <summary>
        /// Obtiene la cotizacion actual de la moneda que implementa la estrategia.
        /// </summary>
        /// <returns>Una tarea asincrona que, al completarse, devuelve la <see cref="ValorCotizacion"/> con los importes de compra y venta.</returns>
        /// <exception cref="System.UnauthorizedAccessException">Si la estrategia no esta habilitada para devolver la cotizacion.</exception>
        /// <exception cref="System.NotImplementedException">Si la cotizacion no esta implementada para la moneda.</exception>
        Task<ValorCotizacion> ObtenerCotizacion();

        #endregion Methods
    }
}
