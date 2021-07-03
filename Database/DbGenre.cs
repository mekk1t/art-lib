using ArtLib.Models;
using System.ComponentModel.DataAnnotations;

namespace Database
{
    public class DbGenre : Genre
    {
        public new long Id { get; set; }
        [Required]
        public new string Name { get; set; }
    }
}
