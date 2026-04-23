using Mediator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using SD.Core.Application.Queries;
using SD.Core.Application.Results;

namespace SD.WS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : Controller
    {
        private IMediator mediator;
        protected IMediator Mediator => mediator ??= HttpContext.RequestServices.GetService<IMediator>(); //überprüft, ob mediator bereits instanziert ist, wenn nicht, wird er über die ServiceProvider der aktuellen HTTP-Anfrage abgerufen und instanziiert.


        [HttpGet(nameof(MovieDto))]
        public async Task<IEnumerable<MovieDto>> GetMovieDtos([FromQuery] GetMovieDtosQuery query, CancellationToken cancellationToken)
        {
            return await Mediator.Send(query, cancellationToken);
        }
    }
}
