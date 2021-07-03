using System;
using System.Collections.Generic;

namespace ArtLib.Models
{
    public class Game : Entity
    {
        public Game()
        {

        }

        public Game(long id) : base(id)
        {
        }

        public string Name { get; set; }
        public string Publisher { get; set; }
        public string Developer { get; set; }
        public DateTime ReleaseDate { get; set; }
        public TimeSpan HoursPlayed { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsReplayable { get; set; }
        public virtual IEnumerable<Genre> Genres { get; set; }
    }
}
