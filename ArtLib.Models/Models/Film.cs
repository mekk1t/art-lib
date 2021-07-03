using System;
using System.Collections.Generic;

namespace KitProjects.ArtLib.Core.Models
{
    public class Film : Entity
    {
        public Film()
        {

        }

        public Film(long id) : base(id)
        {
        }

        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Director { get; set; }
        public TimeSpan Duration { get; set; }
        public string Poster { get; set; }
        public virtual IEnumerable<Genre> Genres { get; set; }
    }
}
