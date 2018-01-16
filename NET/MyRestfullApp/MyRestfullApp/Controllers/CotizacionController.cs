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
        /// Devuelve la cotizacion actual para la moneda indicada.
        /// </summary>
        /// <param name="moneda"></param>
        /// <returns></returns>
        [Route("MyRestfullApp/Cotizacion/{moneda}")]
        public Task<ValorCotizacion> Get(string moneda)
        {
            var cotizacionService = new CotizacionService(moneda);
            return cotizacionService.ObtenerCotizacion();
        }

        #endregion Methods
    }
}