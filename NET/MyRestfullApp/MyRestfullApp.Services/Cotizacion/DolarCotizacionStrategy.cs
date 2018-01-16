using System.Configuration;
using System.Globalization;
using System.Threading.Tasks;

using MyRestfullApp.Models;
using MyRestfullApp.Services.Helpers;

namespace MyRestfullApp.Services.Cotizacion
{
    public class DolarCotizacionStrategy : ICotizacionStrategy
    {
        #region Properties

        /// <summary>
        /// Devuelve la URL para consultar la cotizacion del Dolar en el Banco Provincia.
        /// </summary>
        private string UrlBancoProvinciaCotizacionDolar
        {
            get { return ConfigurationManager.AppSettings["UrlBancoProvinciaCotizacionDolar"]; }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Devuelve la cotizacion del Dolar.
        /// </summary>
        /// <returns></returns>
        public async Task<ValorCotizacion> ObtenerCotizacion()
        {
            var cotizacionDolarBancoProvincia = await WebCommunicationHelper.PerformPostWebCall<string[]>(UrlBancoProvinciaCotizacionDolar, null);
            var compra = double.Parse(cotizacionDolarBancoProvincia[0], CultureInfo.InvariantCulture);
            var venta = double.Parse(cotizacionDolarBancoProvincia[1], CultureInfo.InvariantCulture);
            return new ValorCotizacion { Compra = compra, Venta = venta };
        }

        #endregion Methods
    }
}