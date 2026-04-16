using Mediator;
using SD.Core.Application.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace SD.Core.Application.Commands
{
    public class UpdateMovieDtoCommand : ICommand<MovieDto>
    {
        public Guid Id { get; set; } //Movie singular, weil der Schlüsselwert eindeutig ist und nur einen Film identifiziert
        public MovieDto MovieDto { get; set; } //hier wird das MovieDto mit den neuen Werten übergeben, damit der Handler die Änderungen vornehmen kann
    }
}
