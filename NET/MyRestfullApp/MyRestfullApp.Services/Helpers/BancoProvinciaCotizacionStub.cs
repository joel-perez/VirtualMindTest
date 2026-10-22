using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyRestfullApp.Services.Helpers
{
    /// <summary>
    /// Contrato original del servicio http://www.bancoprovincia.com.ar/Principal/Dolar:
    /// un array JSON con compra, venta y fecha.
    /// </summary>
    public static class BancoProvinciaCotizacionStub
    {
        /// <summary>
        /// Respuesta JSON de ejemplo tal como la devolvia el servicio original:
        /// array [compra, venta, fecha].
        /// </summary>
        public const string JsonRespuesta = "[\"19.55\",\"19.95\",\"15/01/2018\"]";

        /// <summary>
        /// Importe historico de compra del dolar usado como referencia en el stub.
        /// </summary>
        public const double Compra = 19.55;

        /// <summary>
        /// Importe historico de venta del dolar usado como referencia en el stub.
        /// </summary>
        public const double Venta = 19.95;
    }

    /// <summary>
    /// Simula la respuesta HTTP del Banco Provincia para tests de integracion
    /// y para cuando el servicio real ya no esta disponible.
    /// Devuelve siempre el JSON fijo definido en <see cref="BancoProvinciaCotizacionStub"/>.
    /// </summary>
    public class BancoProvinciaCotizacionStubHandler : HttpMessageHandler
    {
        #region Methods

        /// <summary>
        /// Devuelve una respuesta HTTP 200 con el JSON del stub, sin importar la peticion recibida.
        /// </summary>
        /// <param name="request">Peticion HTTP recibida; se ignora y siempre se responde con el JSON fijo.</param>
        /// <param name="cancellationToken">Token de cancelacion de la operacion.</param>
        /// <returns>Una tarea que, al completarse, contiene la respuesta con el contenido JSON simulado.</returns>
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(BancoProvinciaCotizacionStub.JsonRespuesta, Encoding.UTF8, "application/json")
            };
            return Task.FromResult(response);
        }

        #endregion Methods
    }
}
