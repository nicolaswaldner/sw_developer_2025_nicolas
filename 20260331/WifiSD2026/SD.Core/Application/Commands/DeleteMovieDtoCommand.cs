using Mediator;
using SD.Core.Application.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace SD.Core.Application.Commands
{
    public class DeleteMovieDtoCommand : ICommand //kein <MovieDto< weil kein Rückgabewert, da der Film gelöscht wird
                                                  //und somit kein MovieDto mehr existiert, das zurückgegeben werden könnte
    {
        public Guid Id { get; set; }
    }
}
