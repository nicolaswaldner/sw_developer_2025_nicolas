using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SD.Application.Services;
using SD.Core.Application.Commands;
using SD.Core.Application.Queries;
using SD.Core.Application.Results;
using SD.Core.Entities;
using SD.Core.EnumDescriptors;
using SD.Web.Extensions;

namespace SD.Web.Controllers
{
    [Authorize]
    public class MoviesController : MediatorBaseController
    {
        private readonly IApplicationCacheService applicationCacheService;
        
        public MoviesController(IApplicationCacheService applicationCacheService)
        {
            this.applicationCacheService = applicationCacheService;
        }

        // GET: Movies
        // [AllowAnonymous]
        public async Task<IActionResult> Index([FromQuery] GetMovieDtosQuery query, CancellationToken cancellationToken)
        {
            var movieDtos = await base.Mediator.Send(query, cancellationToken);            
            return View(movieDtos);
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details([FromRoute] GetMovieDtoQuery query, CancellationToken cancellationToken)
        {
            var movieDto = await base.Mediator.Send(query, cancellationToken);
            return View(movieDto);
        }


        /* Nicht notwendig, weil mit POST immer eine neue Movie Entität angelegt wird - aber für Redirect nach Login benötigt */
        // GET: Movies/Create
        [HttpGet, ActionName("Create")]
        public async Task<IActionResult> CreateRedirect(CancellationToken cancellationToken)
        {
            return await this.Create(cancellationToken);
        }
        

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CancellationToken cancellationToken)
        {
            var movieDto = await base.Mediator.Send(new CreateMovieDtoCommand(), cancellationToken);

            /* ViewDate = ViewBag */
            await this.InitMovieDtoNavigationProperties(movieDto.GenreId, movieDto.MediumTypeCode, movieDto.Rating, cancellationToken);          
            return View(movieDto);
        }

        // GET: Movies/Edit/5
        //public async Task<IActionResult> Edit(Guid? id, CancellationToken cancellationToken)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var query = new GetMovieDtoQuery { Id = id.Value };
        //    var movieDto = await base.Mediator.Send(query, cancellationToken);

        //    if (movieDto == null)
        //    {
        //        return NotFound();
        //    }

        //    /* ViewDate = ViewBag */
        //    await this.InitMovieDtoNavigationProperties(movieDto.GenreId, movieDto.MediumTypeCode, movieDto.Rating, cancellationToken);
        //    return View(movieDto);
        //}


        [HttpGet] // GET: Movies/Edit/5
        public async Task<ActionResult> Edit([FromRoute] Guid? id, CancellationToken cancellationToken)
        {

            if (id == null)
            {
                return NotFound();
            }

            var query = new GetMovieDtoQuery { Id = id.Value };
            var movieDto = await base.Mediator.Send(query, cancellationToken);

            if (movieDto == null)
            {
                return NotFound();
            }
                       

            /* Genres, MediumTypes, Ratings für Dropdowns initialisieren */
            await this.InitMovieDtoNavigationProperties(movieDto.GenreId, movieDto.MediumTypeCode, movieDto.Rating, cancellationToken);

            return PartialView("_EditModal", movieDto);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut] /* Um HttpPut zu verwenden muss die folgende Zeile in die Programm.cs vor app.UseRouting(); eingefügt werden.
                   * Dann muss im <form> Tag die das folgende hidden Input ergänzt werden: <input type="hidden" value="PUT" name="_method" /> */
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute]Guid id, [FromForm]MovieDto movieDto, CancellationToken cancellationToken)
        {
            if (id != movieDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var command = new UpdateMovieDtoCommand { Id = id, MovieDto = movieDto };
                    await this.Mediator.Send(command, cancellationToken);
                }
                catch(Exception ex)
                {
                    throw;
                }
                //catch (DbUpdateConcurrencyException)
                //{
                    //if (!MovieExists(movie.Id))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                    //    throw;
                    //}
                //}
                return RedirectToAction(nameof(Index));
            }

            await this.InitMovieDtoNavigationProperties(movieDto.GenreId, movieDto.MediumTypeCode, movieDto.Rating, cancellationToken);
            return View(movieDto);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(Guid? id, CancellationToken cancellationToken)
        {
            if (id == null)
            {
                return NotFound();
            }

            var query = new GetMovieDtoQuery { Id = id.Value };
            var movieDto = await base.Mediator.Send(query, cancellationToken);

            if (movieDto == null)
            {
                return NotFound();
            }

            return View(movieDto);
        }

        // POST: Movies/Delete/5
        [HttpDelete, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteMovieDtoCommand { Id = id };
            await base.Mediator.Send(command, cancellationToken);
            return RedirectToAction(nameof(Index));
        }

        private async Task InitMovieDtoNavigationProperties(int? genreId, string mediumTypeCode = default, Ratings? ratings = default, CancellationToken cancellationToken = default)
        {
            var genres = HttpContext.Session.Get<IEnumerable<Genre>> (nameof(Genre));
            if(genres == null)
            {
                genres = await base.Mediator.Send(new GetGenresQuery(), cancellationToken);
                HttpContext.Session.Set(nameof(Genre), genres);
            }
            var genreSelectList = new SelectList(genres, nameof(Genre.Id), nameof(Genre.Name), genreId);


            var mediumTypeCodes = await this.applicationCacheService.RetrieveFromCacheAsync(nameof(MediumType),
                                                                                            async () => await base.Mediator.Send(new GetMediumTypesQuery(),cancellationToken), TimeSpan.FromMinutes(5));
                                

            //var mediumTypeCodes = await base.Mediator.Send(new GetMediumTypesQuery(), cancellationToken);
            var mediumTypeCodeList = new SelectList(mediumTypeCodes, nameof(MediumType.Code), nameof(MediumType.Name), mediumTypeCode);


            var ratingDesciptors = this.applicationCacheService.RetrieveFromCache(nameof(Ratings),
                                                                                  () => RatingsDescriptor.All.Select(s => new { Rating = (int)s.Enum, RatingName = s.ToString() }).ToList());

            //var ratingDesciptors = RatingsDescriptor.All.Select(s => new { Rating = (int)s.Enum, RatingName = s.ToString() }).ToList();
            var ratingsList = new SelectList(ratingDesciptors, "Rating", "RatingName", (int)ratings);

            ViewBag.GenreId = genreSelectList;
            ViewData[nameof(MovieDto.MediumTypeCode)] = mediumTypeCodeList;
            ViewBag.Ratings = ratingsList;
        }


        private async Task<bool> MovieExists(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetMovieDtoQuery { Id = id };
            var movieDto = await base.Mediator.Send(query, cancellationToken);
            return movieDto != null;
           
        }
    }
}
