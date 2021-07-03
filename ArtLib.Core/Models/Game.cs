using System;
using System.Collections.Generic;

namespace KitProjects.ArtLib.Core.Models
{
    public class Game : Entity
    {
        public Game()
        {
        }

        public Game(long id) : base(id)
        {
        }

        public string Name { get; init; }
        public string Publisher { get; init; }
        public string Developer { get; init; }
        public DateTime ReleaseDate { get; init; }
        public TimeSpan HoursPlayed { get; init; }
        public bool IsCompleted { get; init; }
        public bool IsReplayable { get; init; }
        public virtual IEnumerable<Genre> Genres { get; init; }
    }
}
