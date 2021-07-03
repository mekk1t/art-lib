using KitProjects.ArtLib.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Database
{
    public class DbGenre : Genre
    {
        public new long Id { get; private set; }
        [Required]
        public new string Name { get; private set; }

        /// <summary>
        /// Конструктор для EF Core.
        /// </summary>
        internal DbGenre(long id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// Конструктор для маппинга данных из доменной модели.
        /// </summary>
        public DbGenre(Genre domainModel)
        {
            Id = domainModel.Id;
            Name = domainModel.Name;
        }
    }
}
