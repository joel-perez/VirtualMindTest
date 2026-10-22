using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace MyRestfullApp.Filters
{
    /// <summary>
    /// Filtro de Excepciones Personalizadas
    /// Intercepta las excepciones no controladas de la Web API y las traduce
    /// a respuestas HTTP con el codigo de estado correspondiente.
    /// </summary>
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        #region Methods

        /// <summary>
        /// Traduce las excepciones de la accion a respuestas HTTP:
        /// NotImplementedException -> 501 Not Implemented;
        /// UnauthorizedAccessException -> 401 Unauthorized.
        /// Otras excepciones no son manejadas y continuan su propagacion normal.
        /// </summary>
        /// <param name="context">Contexto de la accion ejecutada, con la excepcion lanzada y donde asignar la respuesta.</param>
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is NotImplementedException)
                context.Response = new HttpResponseMessage(HttpStatusCode.NotImplemented);
            if (context.Exception is UnauthorizedAccessException)
                context.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized)
                {
                    ReasonPhrase = "Unauthorized"
                };
        }

        #endregion Methods
    }
}
