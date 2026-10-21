using System.Configuration;
using System.Globalization;
using System.Threading.Tasks;

using MyRestfullApp.Models;
using MyRestfullApp.Services.Helpers;

namespace MyRestfullApp.Services.Cotizacion
{
    public class DolarCotizacionStrategy : ICotizacionStrategy
    {
        #region Fields

        private readonly WebCommunicationHelper _webCommunicationHelper;

        #endregion Fields

        #region Constructors

        public DolarCotizacionStrategy()
            : this(WebCommunicationHelper.CrearParaCotizacionDolar())
        {
        }

        public DolarCotizacionStrategy(WebCommunicationHelper webCommunicationHelper)
        {
            _webCommunicationHelper = webCommunicationHelper;
        }

        #endregion Constructors

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
        /// Devuelve la cotizacion del Dolar: GET al servicio externo, array JSON [compra, venta, fecha].
        /// </summary>
        public async Task<ValorCotizacion> ObtenerCotizacion()
        {
            var cotizacionDolarBancoProvincia = await _webCommunicationHelper.PerformGetWebCall<string[]>(UrlBancoProvinciaCotizacionDolar);
            var compra = ParseImporte(cotizacionDolarBancoProvincia[0]);
            var venta = ParseImporte(cotizacionDolarBancoProvincia[1]);
            return new ValorCotizacion { Compra = compra, Venta = venta };
        }

        private static double ParseImporte(string valor)
        {
            double importe;
            if (double.TryParse(valor, NumberStyles.Any, CultureInfo.InvariantCulture, out importe))
                return importe;
            return double.Parse(valor, new CultureInfo("es-AR"));
        }

        #endregion Methods
    }
}
