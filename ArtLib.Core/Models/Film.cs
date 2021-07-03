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

        public string Name { get; init; }
        public DateTime ReleaseDate { get; init; }
        public string Director { get; init; }
        public TimeSpan Duration { get; init; }
        public string Poster { get; init; }
        public virtual IEnumerable<Genre> Genres { get; init; }
    }
}
