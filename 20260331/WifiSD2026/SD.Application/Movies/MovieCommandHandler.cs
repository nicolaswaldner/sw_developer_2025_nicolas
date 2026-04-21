using Mediator;
using SD.Core.Application.Commands;
using SD.Core.Application.Results;
using SD.Core.Entities;
using SD.Core.Repositories.Movies;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SD.Application.Movies
{
    public class MovieCommandHandler : BaseHandler, ICommandHandler<CreateMovieDtoCommand, MovieDto>,
                                                    ICommandHandler<UpdateMovieDtoCommand, MovieDto>,
                                                    ICommandHandler<DeleteMovieDtoCommand>
    {

        protected readonly IMovieRepository movieRepository;

        public MovieCommandHandler(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        //Create Methode, die einen neuen Film erstellt und in der Datenbank speichert
        public async ValueTask<MovieDto> Handle(CreateMovieDtoCommand command, CancellationToken cancellationToken)
        {
            var movie = new Movie
            {
                Id = Guid.NewGuid(),
                Title = "n/a",
                GenreId = 1,
                MediumTypeCode = "BR"
            };

            await movieRepository.AddAsync(movie, true, cancellationToken); //true, damit die Änderungen sofort in der Datenbank gespeichert werden
                                                                            //cancellationToken, damit die Operation abgebrochen werden kann, wenn der Benutzer dies wünscht

            return MovieDto.MapFrom(movie); //um den erstellten Film als MovieDto zurückzugeben, Umwandlung Entity -> DTO
        }

        // Update Methode
        public async ValueTask<MovieDto> Handle(UpdateMovieDtoCommand command, CancellationToken cancellationToken)
        {
            command.MovieDto.Id = command.Id; //Die Id des Films wird aus dem Command übernommen, damit der Film in der Datenbank gefunden und aktualisiert werden kann
            var movie = new Movie();

            base.MapEntityProperties(command.MovieDto, movie); //Die Eigenschaften des MovieDto werden auf das Movie-Entity gemappt, damit die Änderungen in der Datenbank gespeichert werden können
            var updateMovie = await this.movieRepository.UpdateAsync(movie, command.Id, true, cancellationToken);

            return MovieDto.MapFrom(movie);
        }

        //Delete Methode
        public async ValueTask<Unit> Handle(DeleteMovieDtoCommand command, CancellationToken cancellationToken)
        {
            await this.movieRepository.RemoveByKeyAsync<Movie>(command.Id, true, cancellationToken);

            return Unit.Value; //Unit ist ein spezieller Typ, der verwendet wird, wenn keine Rückgabewerte benötigt werden.
                               //Es signalisiert, dass die Operation erfolgreich abgeschlossen wurde, ohne dass ein Wert zurückgegeben wird.
        }
    }
}
