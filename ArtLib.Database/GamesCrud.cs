using Database;
using KitProjects.ArtLib.Core.Abstractions;
using KitProjects.ArtLib.Core.Models;
using KitProjects.ArtLib.Database.Exceptions;
using KitProjects.ArtLib.Database.Extensions;
using KitProjects.ArtLib.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KitProjects.ArtLib.Database
{
    public class GamesCrud : ICrud<Game, QueryArgsBase>
    {
        private readonly AppDbContext _dbContext;

        public GamesCrud(AppDbContext dbContext)
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
            dbGame.CheckForExistingGenres(_dbContext);

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
            if (baseArgs == null)
                baseArgs = new();

            var query = _dbContext.Games.AsNoTracking();

            if (baseArgs.WithRelationships)
                query = query.Include(g => g.Genres);

            query = query
                .Where(g => g.Id >= baseArgs.LastId)
                .Take(baseArgs.Limit);

            return query
                .Select(g => new Game(g.Id)
                {
                    Developer = g.Developer,
                    ReleaseDate = g.ReleaseDate,
                    Genres = baseArgs.WithRelationships
                        ? g.Genres.Select(genre => new Genre(genre.Id) { Name = genre.Name })
                        : Array.Empty<Genre>(),
                    HoursPlayed = g.HoursPlayed,
                    IsCompleted = g.IsCompleted,
                    IsReplayable = g.IsReplayable,
                    Name = g.Name,
                    Publisher = g.Publisher
                })
                .ToList();
        }

        public Game ReadOrDefault(long id)
        {
            if (id == default)
                throw new DatabaseException("Указан ID игры по умолчанию.");

            var game = _dbContext.Games
                .AsNoTracking()
                .Include(g => g.Genres)
                .FirstOrDefault(g => g.Id == id);
            if (game == null)
                return null;

            return new Game(game.Id)
            {
                Developer = game.Developer,
                ReleaseDate = game.ReleaseDate,
                Genres = game.Genres.Select(g => new Genre(g.Id) { Name = g.Name }),
                HoursPlayed = game.HoursPlayed,
                IsCompleted = game.IsCompleted,
                IsReplayable = game.IsReplayable,
                Name = game.Name,
                Publisher = game.Publisher
            };
        }

        public void Update(Game entity)
        {
            if (entity == null)
                throw new DatabaseException("Отсутствует информация об игре.");
            if (entity.Id == default)
                throw new DatabaseException("Отсутствует ID игры.");

            var dbGame = _dbContext.Games.FirstOrDefault(g => g.Id == entity.Id);
            if (dbGame == null)
                throw new DatabaseException($"Игры с ID {entity.Id} не существует.");

            dbGame.Update(entity);
            dbGame.CheckForExistingGenres(_dbContext);

            _dbContext.SaveChanges();
        }
    }
}
