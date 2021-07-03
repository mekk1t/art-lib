﻿using System;
using System.Collections.Generic;

namespace ArtLib.Models
{
    public class Film : Entity
    {
        public Film(long id) : base(id)
        {
        }

        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Director { get; set; }
        public IEnumerable<string> Genres { get; set; }
        public TimeSpan Duration { get; set; }
        public string Poster { get; set; }
    }
}
