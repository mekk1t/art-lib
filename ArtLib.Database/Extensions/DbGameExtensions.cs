using Database;
using System.Linq;

namespace KitProjects.ArtLib.Database.Extensions
{
    public static class DbGameExtensions
    {
        public static void CheckForExistingGenres(this DbGame dbGame, AppDbContext dbContext)
        {
            if (dbGame.Genres != null && dbGame.Genres.Any(genre => genre.Id != default))
            {
                var currentGenres = dbGame.Genres.ToList();
                var existingGenres = currentGenres.Where(g => g.Id != default);
                var dbGenres = dbContext.Genres.Where(g => existingGenres.Select(genre => genre.Id).ToList().Contains(g.Id)).ToList();
                dbGame.Genres.Clear();
                foreach (var genre in currentGenres)
                {
                    if (genre.Id == default)
                        dbGame.Genres.Add(genre);
                }
                dbGame.Genres.AddRange(dbGenres);
            }
        }
    }
}
