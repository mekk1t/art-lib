using KitProjects.ArtLib.Core.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Database
{
    public class DbGame : Game
    {
        public new long Id { get; set; }
        [Required]
        public new string Name { get; set; }
        public new IEnumerable<DbGenre> Genres { get; set; }
    }
}
