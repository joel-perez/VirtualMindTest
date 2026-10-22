using System.Threading.Tasks;
using System.Web.Http;
using MyRestfullApp.Filters;
using MyRestfullApp.Models;
using MyRestfullApp.Services.Cotizacion;

namespace MyRestfullApp.Controllers
{
    /// <summary>
    /// Controlador para las Cotizaciones.
    /// </summary>
    [CustomExceptionFilter]
    public class CotizacionController : ApiController
    {
        #region Methods

        /// <summary>
        /// Devuelve la cotizacion actual para la moneda indicada (Dolar, Pesos o Real).
        /// </summary>
        /// <param name="moneda">Moneda a cotizar: "Dolar", "Pesos" o "Real" (no distingue mayusculas/minusculas).</param>
        /// <returns>La <see cref="ValorCotizacion"/> con los importes de compra y venta de la moneda solicitada.</returns>
        /// <remarks>
        /// Ruta: GET MyRestfullApp/Cotizacion/{moneda}.
        /// Si la moneda no es soportada responde 501 Not Implemented;
        /// si la cotizacion no esta habilitada (Pesos, Real) responde 401 Unauthorized.
        /// </remarks>
        /// <exception cref="System.NotImplementedException">Si la moneda no es ninguna de las soportadas.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Si la cotizacion de la moneda no esta habilitada.</exception>
        [HttpGet]
        [Route("MyRestfullApp/Cotizacion/{moneda}")]
        public async Task<ValorCotizacion> Get(string moneda)
        {
            var cotizacionService = new CotizacionService(moneda);
            return await cotizacionService.ObtenerCotizacion();
        }

        #endregion Methods
    }
}
