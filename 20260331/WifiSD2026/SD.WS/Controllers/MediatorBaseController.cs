using Mediator;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace SD.WS.Controllers
{
    public class MediatorBaseController : ControllerBase
    {
        protected const string ID_PARAMETER = "/{Id}";

        private IMediator mediator;
        protected IMediator Mediator => mediator ??= HttpContext.RequestServices.GetService<IMediator>(); //überprüft, ob mediator bereits instanziert ist, wenn nicht, wird er über die ServiceProvider der aktuellen HTTP-Anfrage abgerufen und instanziiert.
        // ??= heißt if null, dann initialisieren 

        protected T SetLocationUri<T>(T result, string id)
        {
            if (result == null || string.IsNullOrWhiteSpace(id))
            {
                throw new HttpRequestException("Resource not found");
            }

            // Aktueller URL ermitteln
            var baseUrl = Request.HttpContext.Request.GetEncodedUrl();

            // Base Url bis zum ersten (QueryString) Parameter, falls vorhanden, kürzen
            var length = baseUrl.IndexOf('?') > 0 ? baseUrl.IndexOf('?') : baseUrl.Length;

            // Url auf gültige Länge mit Substring zuschneiden
            var uri = baseUrl.Substring(0, length);

            uri = string.Concat(uri, uri.EndsWith('/') ? string.Empty : "/", id);

            // Location Header im Response setzen
            HttpContext.Response.Headers.Append("Location", uri);

            // Http Status auf 201 - Created setzen
            HttpContext.Response.StatusCode = StatusCodes.Status201Created;

            return result;
        }
    }
}
