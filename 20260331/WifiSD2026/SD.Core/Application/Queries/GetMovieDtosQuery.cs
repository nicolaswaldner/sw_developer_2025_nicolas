using Mediator;
using SD.Core.Application.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace SD.Core.Application.Queries
{
    public class GetMovieDtosQuery : IQuery<IEnumerable<MovieDto>>
    {
        public int? GenreId { get; set; } //optionaler parameter, deshalb nullable, damit die abfrage auch ohne genre-id funktioniert und alle filme zurückgibt
        public string? MediumTypeCode { get; set; } //auch optional
        public string? SearchText { get; set; } //optional, damit die abfrage auch ohne textsuche funktioniert und alle filme zurückgibt
        public int Take { get; set; } = 10; //default wert, damit nicht unendlich viele filme zurückgegeben werden, wenn kein take angegeben wird
        public int Skip { get; set; } = 0; //default wert, damit die abfrage bei 0 beginnt, wenn kein skip angegeben wird
    }
}
