﻿using Database.Exceptions;
using KitProjects.ArtLib.Core.Abstractions;
using KitProjects.ArtLib.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Database
{
    public class GenresRepository : ICrud<Genre, QueryArgsBase>
    {
        private readonly AppDbContext _dbContext;

        public GenresRepository(AppDbContext dbContext)
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

        public Genre Create(Genre entity)
        {
            if (entity.Id != default)
                throw new DatabaseException("Не задан ID жанра.");

            var dbGenre = new DbGenre(entity);

            var entry = _dbContext.Add(dbGenre);
            _dbContext.SaveChanges();

            return new Genre(entry.Entity.Id)
            {
                Name = entry.Entity.Name
            };
        }

        public void Delete(long id)
        {
            if (id == default)
                throw new DatabaseException("Не задан ID жанра.");

            var genre = _dbContext.Genres.FirstOrDefault(genre => genre.Id == id);
            if (genre == null)
                throw new DatabaseException($"Жанр с ID {id} не существует.");

            _dbContext.Genres.Remove(genre);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Genre> Read(QueryArgsBase baseArgs = null)
        {
            if (baseArgs == null)
                baseArgs = new();

            return _dbContext.Genres
                .AsNoTracking()
                .Where(genre => genre.Id >= baseArgs.LastId)
                .Take(baseArgs.Limit)
                .Select(genre => new Genre(genre.Id) { Name = genre.Name })
                .ToList();
        }

        public Genre ReadOrDefault(long id)
        {
            if (id == default)
                throw new DatabaseException("Не указан ID жанра.");

            var genre = _dbContext.Genres.AsNoTracking().FirstOrDefault(genre => genre.Id == id);
            if (genre == null)
                return null;

            return new Genre(id)
            {
                Name = genre.Name
            };
        }

        public void Update(Genre entity)
        {
            if (entity == null)
                throw new DatabaseException("Отсутствует жанр для обновления.");
            if (entity.Id == default)
                throw new DatabaseException("Отсутствует ID жанра.");

            var updatedGenre = new DbGenre(entity);

            _dbContext.Genres.Update(updatedGenre);
            _dbContext.SaveChanges();
        }
    }
}