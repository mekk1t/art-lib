using ArtLib.Models;
using System.Collections.Generic;

namespace Database
{
    public class DbGame : Game
    {
        public new long Id { get; set; }
        public new IEnumerable<DbGenre> Genres { get; set; }
    }
}
