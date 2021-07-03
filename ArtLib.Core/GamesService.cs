using KitProjects.ArtLib.Core.Abstractions;
using KitProjects.ArtLib.Core.Models;
using System;
using System.Collections.Generic;

namespace KitProjects.ArtLib.Core
{
    public class GamesService
    {
        private readonly ICrud<Game, QueryArgsBase> _crud;

        public GamesService(ICrud<Game, QueryArgsBase> crud)
        {
            _crud = crud;
        }

        public Game CreateGame(Game game)
        {
            if (game == null)
                throw new ArgumentNullException(nameof(game), "Нет данных об игре.");

            if (string.IsNullOrEmpty(game.Name))
                throw new ArgumentException("Отсутствует название у игры.");

            return _crud.Create(game);
        }

        public IEnumerable<Game> GetGamesList(QueryArgsBase args) => _crud.Read(args);
        public Game GetGameOrDefault(long id) => _crud.ReadOrDefault(id);

        public void UpdateGame(Game game)
        {
            if (game == null)
                throw new ArgumentNullException(nameof(game), "Отсутствует информация об игре.");

            _crud.Update(game);
        }

        public void DeleteGameById(long id) => _crud.Delete(id);
    }
}
