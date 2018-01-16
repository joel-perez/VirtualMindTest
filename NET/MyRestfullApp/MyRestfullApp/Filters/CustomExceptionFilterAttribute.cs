using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace MyRestfullApp.Controllers
{
    /// <summary>
    /// Filtro de Excepciones Personalizadas
    /// </summary>
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is NotImplementedException)
                context.Response = new HttpResponseMessage(HttpStatusCode.NotImplemented);
            if (context.Exception is UnauthorizedAccessException)
                context.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
        }

        #endregion Methods
    }
}