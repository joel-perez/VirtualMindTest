using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace MyRestfullApp.Services.Helpers
{
    /// <summary>
    /// Clase encargada de realizar llamadas HTTP.
    /// </summary>
    public class WebCommunicationHelper
    {
        #region Methods

        /// <summary>
        /// Realiza una llamada POST con sus correspondientes parametros y devuelve los datos obtenidos como instancia del tipo indicado.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static async Task<T> PerformPostWebCall<T>(string url, object parameters)
        {
            var handler = new HttpClientHandler();
            var client = new HttpClient(handler);
            var jsonData = JsonConvert.SerializeObject(parameters);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            var resultString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(resultString);
            return result;
        }

        #endregion Methods
    }
}