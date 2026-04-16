using Mediator;
using SD.Core.Application.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace SD.Core.Application.Queries
{
    public class GetMovieDtoQuery : IQuery<MovieDto>
    {
        public Guid Id { get; set; } //Movie singular, weil der Schlüsselwert eindeutig ist und nur einen Film identifiziert,
                                     //im Gegensatz zu GetMoviesQuery, wo mehrere Filme zurückgegeben werden können
    }
}
