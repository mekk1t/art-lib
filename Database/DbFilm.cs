using ArtLib.Models;
using System.Collections.Generic;

namespace Database
{
    public class DbFilm : Film
    {
        public new long Id { get; set; }
        public new IEnumerable<DbGenre> Genres { get; set; }
    }
}
