using KitProjects.ArtLib.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Database
{
    public class DbGame
    {
        public long Id { get; private set; }
        [Required]
        public string Name { get; private set; }
        public string Developer { get; private set; }
        public string Publisher { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public TimeSpan HoursPlayed { get; private set; }
        public bool IsCompleted { get; private set; }
        public bool IsReplayable { get; private set; }
        public IEnumerable<DbGenre> Genres { get; private set; }

        /// <summary>
        /// Конструктор для EF Core.
        /// </summary>
        public DbGame(
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
