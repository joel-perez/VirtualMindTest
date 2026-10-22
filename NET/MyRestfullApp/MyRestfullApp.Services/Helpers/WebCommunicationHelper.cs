using System;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace MyRestfullApp.Services.Helpers
{
    /// <summary>
    /// Clase encargada de realizar llamadas HTTP.
    /// Permite inyectar un <see cref="HttpMessageHandler"/> para tests o para
    /// interceptar la comunicacion (ej. stub del Banco Provincia).
    /// </summary>
    public class WebCommunicationHelper
    {
        #region Fields

        /// <summary>
        /// Handler HTTP inyectado; si es null se usa el <see cref="HttpClient"/> por defecto.
        /// </summary>
        private readonly HttpMessageHandler _handler;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Inicializa una instancia sin handler personalizado (usa el HttpClient por defecto).
        /// </summary>
        public WebCommunicationHelper()
            : this(null)
        {
        }

        /// <summary>
        /// Inicializa una instancia con el handler HTTP indicado.
        /// </summary>
        /// <param name="handler">Handler que interceptara las peticiones; null para usar el comportamiento por defecto.</param>
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
        /// <returns>Una instancia de <see cref="WebCommunicationHelper"/> lista para consultar la cotizacion del dolar.</returns>
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
        /// <typeparam name="T">Tipo de resultado al deserializar el JSON de la respuesta (ej. string[]).</typeparam>
        /// <param name="url">URL completa del recurso a consultar.</param>
        /// <returns>Una tarea asincrona con la instancia deserializada del tipo <typeparamref name="T"/>.</returns>
        /// <exception cref="HttpRequestException">Si la llamada HTTP falla o el codigo de estado no es de exito.</exception>
        /// <exception cref="JsonException">Si la respuesta no es JSON valido o no puede convertirse al tipo indicado.</exception>
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
