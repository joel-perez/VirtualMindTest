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
        public const string JsonRespuesta = "[\"19.55\",\"19.95\",\"15/01/2018\"]";
        public const double Compra = 19.55;
        public const double Venta = 19.95;
    }

    /// <summary>
    /// Simula la respuesta HTTP del Banco Provincia para tests de integracion
    /// y para cuando el servicio real ya no esta disponible.
    /// </summary>
    public class BancoProvinciaCotizacionStubHandler : HttpMessageHandler
    {
        #region Methods

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
