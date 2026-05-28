using Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Identity.Client;
using SD.Core.Application.Commands;
using SD.Core.Application.Queries;
using SD.Core.Application.Results;

namespace SD.WS.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class MovieController : MediatorBaseController
    {
        

        [HttpGet(nameof(MovieDto) + ID_PARAMETER)]
        public async Task<MovieDto> GetMovieDto([FromRoute] GetMovieDtoQuery query, CancellationToken cancellationToken)
        {
            return await Mediator.Send(query, cancellationToken);
        }


        [AllowAnonymous]
        [HttpGet(nameof(MovieDto))]
        public async Task<IEnumerable<MovieDto>> GetMovieDtos([FromQuery] GetMovieDtosQuery query, CancellationToken cancellationToken)
        {
            return await Mediator.Send(query, cancellationToken);
        }

        [HttpPost(nameof(MovieDto))]
        [ProducesResponseType(typeof(MovieDto), StatusCodes.Status201Created)] //dass Schnittstellen-beschreibung über Open Api richtig angezeigt wird
        public async Task<MovieDto> CreateMovieDto(CancellationToken cancellationToken)
        {
            var result = await base.Mediator.Send(new CreateMovieDtoCommand(), cancellationToken);
            return base.SetLocationUri<MovieDto>(result, result.Id.ToString());
        }

        [HttpPut(nameof(MovieDto) + ID_PARAMETER)]
        public async Task<MovieDto> UpdateMovieDto([FromRoute] Guid Id, [FromBody] MovieDto movieDto, CancellationToken cancellationToken)
        {
            return await base.Mediator.Send(new UpdateMovieDtoCommand {  Id = Id, MovieDto = movieDto }, cancellationToken);
        }

        [HttpDelete(nameof(MovieDto) + ID_PARAMETER)]
        public async Task DeleteMovieDto([FromRoute] DeleteMovieDtoCommand command, CancellationToken cancellationToken)
        {
            await base.Mediator.Send(command, cancellationToken);
        }
    }
}
