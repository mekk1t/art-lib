using KitProjects.Api.AspNetCore;
using KitProjects.ArtLib.Api.Genres;
using KitProjects.ArtLib.Core;
using KitProjects.ArtLib.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace KitProjects.ArtLib.Api
{
    public class GenresController : ApiJsonController
    {
        private readonly GenresService _service;

        public GenresController(ILogger<GenresController> logger, GenresService service) : base(logger)
        {
            _service = service;
        }

        /// <summary>
        /// Список всех жанров.
        /// </summary>
        /// <response code="200">Список жанров.</response>
        /// <response code="500">Ошибка на стороне сервера.</response>
        [HttpGet]
        [ProducesResponseType(typeof(ApiCollectionResponse<GenreResponse>), 200)]
        [ProducesResponseType(typeof(ApiErrorResponse), 500)]
        public IActionResult GetAllGenres() =>
            ProcessRequest(() =>
            {
                var genres = _service.GetAllGenres();
                return new ApiCollectionResponse<GenreResponse>(genres.Select(g => new GenreResponse(g.Id, g.Name)).ToList());
            });

        /// <summary>
        /// Создание нового жанра.
        /// </summary>
        /// <param name="request">Запрос на создание нового жанра.</param>
        /// <response code="200">Жанр создан.</response>
        /// <response code="500">Ошибка на стороне сервера.</response>
        [HttpPost]
        [ProducesResponseType(typeof(ApiObjectResponse<GenreResponse>), 200)]
        [ProducesResponseType(typeof(ApiErrorResponse), 500)]
        public IActionResult CreateGenre([FromBody] NewGenre request)
        {
            if (request == null)
                return ApiError("Тело запроса не может быть пустым.");

            return ProcessRequest(() =>
            {
                var result = _service.CreateGenre(new Genre { Name = request.Name });
                return new ApiObjectResponse<GenreResponse>(new GenreResponse(result.Id, result.Name));
            });
        }

        /// <summary>
        /// Детальная информация о жанре.
        /// </summary>
        /// <param name="genreId">ID жанра в числовом формате.</param>
        /// <response code="200">Детальная информация о жанре.</response>
        /// <response code="404">Жанр не найден.</response>
        /// <response code="500">Ошибка на стороне сервера.</response>
        [HttpGet("{genreId}")]
        [ProducesResponseType(typeof(ApiObjectResponse<GenreResponse>), 200)]
        [ProducesResponseType(typeof(ApiErrorResponse), 404)]
        [ProducesResponseType(typeof(ApiErrorResponse), 500)]
        public IActionResult GetGenreById([FromRoute] long genreId) =>
            ProcessRequest(() =>
            {
                var genre = _service.GetGenreByIdOrDefault(genreId);
                if (genre == null)
                    return null;

                return new ApiObjectResponse<GenreResponse>(new GenreResponse(genre.Id, genre.Name));
            });

        /// <summary>
        /// Обновление жанра по ID.
        /// </summary>
        /// <param name="request">Запрос на обновление жанра.</param>
        /// <param name="genreId">ID жанра в числовом формате.</param>
        /// <response code="204">Жанр обновлен.</response>
        /// <response code="500">Ошибка на стороне сервера.</response>
        [HttpPut("{genreId}")]
        [ProducesResponseType(typeof(ApiErrorResponse), 500)]
        [ProducesResponseType(204)]
        public IActionResult UpdateGenre([FromBody] NewGenre request, [FromRoute] long genreId)
        {
            if (request == null)
                return ApiError("Тело запроса не может быть пустым.");

            if (genreId == default)
                return ApiError("Не задан ID жанра.");

            return ProcessRequest(() =>
            {
                _service.UpdateGenre(new Genre(genreId) { Name = request.Name });
            });
        }

        /// <summary>
        /// Удаление жанра по ID.
        /// </summary>
        /// <param name="genreId">ID жанра в числовом формате.</param>
        /// <response code="500">Ошибка на стороне сервера.</response>
        /// <response code="204">Жанр удален.</response>
        [HttpDelete("{genreId}")]
        [ProducesResponseType(typeof(ApiErrorResponse), 500)]
        [ProducesResponseType(204)]
        public IActionResult DeleteGenre([FromRoute] long genreId) =>
            ProcessRequest(() => _service.DeleteGenreById(genreId));
    }
}
