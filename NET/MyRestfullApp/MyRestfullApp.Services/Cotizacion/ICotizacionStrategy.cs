using System.Threading.Tasks;

using MyRestfullApp.Models;

namespace MyRestfullApp.Services.Cotizacion
{
    /// <summary>
    /// Interface que implementan las diferentes estrategias para Cotizacion.
    /// </summary>
    public interface ICotizacionStrategy
    {
        #region Methods

        Task<ValorCotizacion> ObtenerCotizacion();

        #endregion Methods
    }
}