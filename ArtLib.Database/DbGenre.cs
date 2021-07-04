using KitProjects.ArtLib.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Database
{
    public class DbGenre
    {
        public long Id { get; private set; }
        [Required]
        public string Name { get; private set; }

        /// <summary>
        /// Конструктор для EF Core.
        /// </summary>
        public DbGenre(long id, string name)
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
