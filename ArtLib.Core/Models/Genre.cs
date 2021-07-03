namespace KitProjects.ArtLib.Core.Models
{
    public class Genre : Entity
    {
        public Genre()
        {
        }

        public Genre(long id) : base(id)
        {
        }

        public string Name { get; init; }
    }
}
