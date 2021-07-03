using KitProjects.ArtLib.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Database
{
    public class DbGame : Game
    {
        public new long Id { get; private set; }
        [Required]
        public new string Name { get; private set; }
        public new IEnumerable<DbGenre> Genres { get; private set; }

        /// <summary>
        /// Конструктор для EF Core.
        /// </summary>
        internal DbGame(
            long id,
            string name,
            string developer,
            string publisher,
            DateTime releaseDate,
            TimeSpan hoursPlayed,
            bool isCompleted,
            bool isReplayable,
            IEnumerable<DbGenre> genres)
        {
            Id = id;
            Name = name;
            Developer = developer;
            Publisher = publisher;
            ReleaseDate = releaseDate;
            HoursPlayed = hoursPlayed;
            IsCompleted = isCompleted;
            IsReplayable = isReplayable;
            Genres = genres;
        }

        /// <summary>
        /// Конструктор для получения данных из доменной модели.
        /// </summary>
        /// <param name="domainModel"></param>
        public DbGame(Game domainModel)
        {
            Id = domainModel.Id;
            Name = domainModel.Name;
            Developer = domainModel.Developer;
            Publisher = domainModel.Publisher;
            ReleaseDate = domainModel.ReleaseDate;
            HoursPlayed = domainModel.HoursPlayed;
            IsCompleted = domainModel.IsCompleted;
            IsReplayable = domainModel.IsReplayable;
            Genres = domainModel.Genres.Select(g => new DbGenre(g));
        }
    }
}
