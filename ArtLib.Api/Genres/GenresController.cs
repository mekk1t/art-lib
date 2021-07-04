using KitProjects.Api.AspNetCore;
using KitProjects.ArtLib.Api.Genres;
using KitProjects.ArtLib.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Runtime.CompilerServices;

namespace KitProjects.ArtLib.Api
{
    public class GenresController : ApiJsonController
    {
        private readonly GenresService _service;

        public GenresController(ILogger<GenresController> logger, GenresService service) : base(logger)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllGenres() =>
            ProcessRequest(() =>
            {
                var genres = _service.GetAllGenres();
                return new ApiCollectionResponse<GenreResponse>(genres.Select(g => new GenreResponse(g.Id, g.Name)).ToList());
            });

        [HttpPost]
        public IActionResult CreateGenre() =>
            ProcessRequest(() =>
            {

            });

        [HttpGet("{genreId}")]
        public IActionResult GetGenreById(long genreId) =>
            ProcessRequest(() =>
            {
                var genre = _service.GetGenreByIdOrDefault(genreId);
                if (genre == null)
                    return null;

                return new GenreResponse(genre.Id, genre.Name);
            });
    }
}
