namespace ArtLib.Models
{
    public class Genre : Entity
    {
        public Genre()
        {

        }

        public Genre(long id) : base(id)
        {
        }

        public string Name { get; set; }
    }
}
