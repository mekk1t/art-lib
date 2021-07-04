using KitProjects.ArtLib.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace KitProjects.ArtLib.Database.Models
{
    public class DbFilm
    {
        public long Id { get; private set; }
        [Required]
        public string Name { get; private set; }
        public IEnumerable<DbGenre> Genres { get; } = new List<DbGenre>();
        public string Poster { get; private set; }
        public string Director { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public TimeSpan Duration { get; private set; }

        /// <summary>
        /// Конструктор для EF Core.
        /// </summary>
        private DbFilm(long id, string name, string poster, string director, DateTime releaseDate, TimeSpan duration)
        {
            Id = id;
            Name = name;
            Poster = poster;
            Director = director;
            ReleaseDate = releaseDate;
            Duration = duration;
        }

        public DbFilm(Film domainModel)
        {
            Id = domainModel.Id;
            Name = domainModel.Name;
            Poster = domainModel.Poster;
            Genres = domainModel.Genres.Select(g => new DbGenre(g));
            Director = domainModel.Director;
            ReleaseDate = domainModel.ReleaseDate;
            Duration = domainModel.Duration;
        }
    }
}
