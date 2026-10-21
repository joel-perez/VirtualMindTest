using System;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace MyRestfullApp.Services.Helpers
{
    /// <summary>
    /// Clase encargada de realizar llamadas HTTP.
    /// </summary>
    public class WebCommunicationHelper
    {
        #region Fields

        private readonly HttpMessageHandler _handler;

        #endregion Fields

        #region Constructors

        public WebCommunicationHelper()
            : this(null)
        {
        }

        public WebCommunicationHelper(HttpMessageHandler handler)
        {
            _handler = handler;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Crea el helper para consultar la cotizacion del dolar.
        /// Si UsarStubBancoProvincia=true, intercepta el HTTP con la respuesta historica del Banco Provincia.
        /// </summary>
        public static WebCommunicationHelper CrearParaCotizacionDolar()
        {
            var usarStub = ConfigurationManager.AppSettings["UsarStubBancoProvincia"];
            if (string.Equals(usarStub, "true", StringComparison.OrdinalIgnoreCase))
                return new WebCommunicationHelper(new BancoProvinciaCotizacionStubHandler());
            return new WebCommunicationHelper();
        }

        /// <summary>
        /// Realiza una llamada GET y devuelve los datos obtenidos como instancia del tipo indicado.
        /// </summary>
        public async Task<T> PerformGetWebCall<T>(string url)
        {
            using (var client = _handler == null ? new HttpClient() : new HttpClient(_handler, false))
            {
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var resultString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(resultString);
            }
        }

        #endregion Methods
    }
}
