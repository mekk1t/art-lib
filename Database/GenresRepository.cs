namespace Database
{
    public class GenresRepository
    {
        private AppDbContext _dbContext;

        public GenresRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Foo()
        {
            var genres = _dbContext.Genres;
            var t = genres.Whe
        }
    }
}
