using KitProjects.ArtLib.Core.Abstractions;
using KitProjects.ArtLib.Core.Models;
using System;
using System.Collections.Generic;

namespace KitProjects.ArtLib.Core
{
    public class GenresService
    {
        private readonly ICrud<Genre, QueryArgsBase> _crud;

        public GenresService(ICrud<Genre, QueryArgsBase> crud)
        {
            _crud = crud;
        }

        public Genre CreateGenre(Genre genre)
        {
            if (genre == null)
                throw new ArgumentNullException(nameof(genre), "Нельзя создать пустой жанр.");

            if (string.IsNullOrEmpty(genre.Name))
                throw new ArgumentException("Жанр должен иметь название.");

            return _crud.Create(genre);
        }

        public IEnumerable<Genre> GetAllGenres() => _crud.Read(new QueryArgsBase(lastId: 0, limit: int.MaxValue, withRelationships: true));

        public Genre GetGenreByIdOrDefault(long id) => _crud.ReadOrDefault(id);

        public void UpdateGenre(Genre genre)
        {
            if (genre == null)
                throw new ArgumentNullException(nameof(genre), "Нельзя заменить старый жанр на пустой.");

            _crud.Update(genre);
        }

        public void DeleteGenreById(long id) => _crud.Delete(id);
    }
}
