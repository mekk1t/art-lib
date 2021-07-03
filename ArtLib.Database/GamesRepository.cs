using Database;
using Database.Exceptions;
using KitProjects.ArtLib.Core.Abstractions;
using KitProjects.ArtLib.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KitProjects.ArtLib.Database
{
    public class GamesRepository : ICrud<Game, QueryArgsBase>
    {
        private readonly AppDbContext _dbContext;

        public GamesRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.SaveChangesFailed += (obj, args) =>
            {
                if (args.Exception.InnerException != null)
                    throw new DatabaseException(args.Exception.InnerException.Message, args.Exception);
                else
                    throw new DatabaseException(args.Exception.Message, args.Exception);
            };
        }

        public Game Create(Game newGame)
        {
            if (newGame.Id != default)
                throw new DatabaseException("У игры уже задан ID.");

            var dbGame = new DbGame(newGame);

            var entity = _dbContext.Add(dbGame).Entity;
            _dbContext.SaveChanges();
            return new Game(entity.Id)
            {
                Developer = entity.Developer,
                ReleaseDate = entity.ReleaseDate,
                Genres = entity.Genres.Select(g => new Genre(g.Id) { Name = g.Name }),
                HoursPlayed = entity.HoursPlayed,
                IsCompleted = entity.IsCompleted,
                IsReplayable = entity.IsReplayable,
                Name = entity.Name,
                Publisher = entity.Publisher
            };
        }

        public void Delete(long id)
        {
            if (id == default)
                throw new DatabaseException("Не задан ID игры.");

            var dbGame = _dbContext.Games.FirstOrDefault(game => game.Id == id);
            if (dbGame == null)
                throw new DatabaseException($"Игры с ID {id} не существует.");

            _dbContext.Games.Remove(dbGame);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Game> Read(QueryArgsBase baseArgs = null)
        {
            throw new NotImplementedException();
        }

        public Game ReadOrDefault(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(Game entity)
        {
            throw new NotImplementedException();
        }
    }
}
