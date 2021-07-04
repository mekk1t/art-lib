namespace KitProjects.ArtLib.Api.Genres
{
    /// <summary>
    /// Информация о жанре.
    /// </summary>
    public class GenreResponse
    {
        /// <summary>
        /// ID жанра в числовом формате.
        /// </summary>
        public long Id { get; }
        /// <summary>
        /// Название жанра.
        /// </summary>
        public string Name { get; }

        public GenreResponse(long id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
