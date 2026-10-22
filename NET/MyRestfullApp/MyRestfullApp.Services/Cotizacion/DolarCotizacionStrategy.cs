using System;
using System.Configuration;
using System.Globalization;
using System.Threading.Tasks;

using MyRestfullApp.Models;
using MyRestfullApp.Services.Helpers;

namespace MyRestfullApp.Services.Cotizacion
{
    /// <summary>
    /// Estrategia que obtiene la cotizacion del Dolar consultando el servicio
    /// web del Banco Provincia (o su stub de respuesta historica en tests).
    /// </summary>
    public class DolarCotizacionStrategy : ICotizacionStrategy
    {
        #region Fields

        /// <summary>
        /// Helper HTTP utilizado para realizar la llamada al servicio externo del Banco Provincia.
        /// </summary>
        private readonly WebCommunicationHelper _webCommunicationHelper;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Inicializa una instancia usando el helper por defecto para la cotizacion del dolar
        /// (real o stub segun la configuracion "UsarStubBancoProvincia").
        /// </summary>
        public DolarCotizacionStrategy()
            : this(WebCommunicationHelper.CrearParaCotizacionDolar())
        {
        }

        /// <summary>
        /// Inicializa una instancia con un helper HTTP inyectado (util para tests).
        /// </summary>
        /// <param name="webCommunicationHelper">Helper que realizará la llamada GET al servicio externo.</param>
        public DolarCotizacionStrategy(WebCommunicationHelper webCommunicationHelper)
        {
            _webCommunicationHelper = webCommunicationHelper;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Devuelve la URL para consultar la cotizacion del Dolar en el Banco Provincia.
        /// Se lee de la clave de configuracion "UrlBancoProvinciaCotizacionDolar".
        /// </summary>
        /// <value>Cadena con la URL completa del endpoint de cotizacion.</value>
        private string UrlBancoProvinciaCotizacionDolar
        {
            get { return ConfigurationManager.AppSettings["UrlBancoProvinciaCotizacionDolar"]; }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Devuelve la cotizacion del Dolar: GET al servicio externo, array JSON [compra, venta, fecha].
        /// </summary>
        /// <returns>Una tarea asincrona con la <see cref="ValorCotizacion"/> cuyos importes son los elementos 0 (compra) y 1 (venta) de la respuesta.</returns>
        /// <exception cref="System.Net.Http.HttpRequestException">Si la llamada HTTP falla o el codigo de estado no es de exito.</exception>
        /// <exception cref="Newtonsoft.Json.JsonException">Si la respuesta no es JSON valido o no puede deserializarse.</exception>
        /// <exception cref="System.IndexOutOfRangeException">Si la respuesta no trae los importes esperados.</exception>
        public async Task<ValorCotizacion> ObtenerCotizacion()
        {
            var cotizacionDolarBancoProvincia = await _webCommunicationHelper.PerformGetWebCall<string[]>(UrlBancoProvinciaCotizacionDolar);
            var compra = ParseImporte(cotizacionDolarBancoProvincia[0]);
            var venta = ParseImporte(cotizacionDolarBancoProvincia[1]);
            return new ValorCotizacion { Compra = compra, Venta = venta };
        }

        /// <summary>
        /// Convierte una cadena de importe en numero, probando primero formato invariante
        /// y, si falla, el formato cultural "es-AR".
        /// </summary>
        /// <param name="valor">Cadena con el importe (ej. "19.55" o "19,55").</param>
        /// <returns>El importe convertido a <see cref="double"/>.</returns>
        /// <exception cref="FormatException">Si la cadena no puede convertirse con ninguno de los formatos soportados.</exception>
        /// <exception cref="OverflowException">Si el valor esta fuera del rango de <see cref="double"/>.</exception>
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
