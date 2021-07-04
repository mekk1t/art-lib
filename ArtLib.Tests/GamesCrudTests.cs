using ArtLibTests.Fixtures;
using Database;
using FluentAssertions;
using KitProjects.ArtLib.Core;
using KitProjects.ArtLib.Core.Models;
using KitProjects.ArtLib.Database;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace KitProjectsTests.ArtLib
{
    [Collection("Db")]
    public class GamesCrudTests : IDisposable
    {
        private readonly GamesService _sut;
        private readonly AppDbContext _dbContext;
        private readonly GenresService _genresService;

        public GamesCrudTests(DbFixture fixture)
        {
            _dbContext = fixture.DbContext;
            _sut = new GamesService(new GamesRepository(_dbContext));
            _genresService = new GenresService(new GenresRepository(_dbContext));
        }

        [Fact]
        public void Can_create_new_game_without_genres()
        {
            var newGame = CreateDefaultGame();

            var result = _sut.CreateGame(newGame);

            result.Should().NotBeNull();
        }

        [Fact]
        public void Can_create_new_game_with_existing_genres()
        {
            var existingGenre = _genresService.CreateGenre(new Genre() { Name = "Пост-апокалипсис RPG" });
            var newGame = CreateDefaultGame(new[] { existingGenre });

            var result = _sut.CreateGame(newGame);

            result.Should().NotBeNull();
            result.Genres.First().Id.Should().Be(existingGenre.Id);
        }

        [Fact]
        public void Can_create_new_game_with_new_genres()
        {
            var newGame = CreateDefaultGame(new[]
            {
                new Genre() { Name = "Это что-то новенькое" },
                new Genre() { Name = "Это что-то нестаренькое" }
            });

            var result = _sut.CreateGame(newGame);

            result.Should().NotBeNull();
            result.Genres.Should().HaveCount(2);
        }

        [Fact]
        public void Can_create_new_game_with_mixed_genres()
        {
            var existingGenre = _genresService.CreateGenre(new Genre() { Name = "Амифбраихй Акаеиквич" });
            var newGame = CreateDefaultGame(new[]
            {
                existingGenre,
                new Genre() { Name = "Это что-то еще не существующее в БД!" }
            });

            var result = _sut.CreateGame(newGame);

            result.Should().NotBeNull();
            result.Genres.Should().HaveCount(2);
        }

        [Fact]
        public void Default_list_has_no_relationships()
        {
            SeedGame(new[] { new Genre() { Name = Guid.NewGuid().ToString() } });
            SeedGame(new[] { new Genre() { Name = Guid.NewGuid().ToString() } });
            var queryArgs = new QueryArgsBase();

            var result = _sut.GetGamesList(queryArgs);

            result.Should().HaveCountLessOrEqualTo(queryArgs.Limit);
            result.ToList().ForEach(game => game.Genres.Should().BeEmpty());
        }

        private Game SeedGame(IEnumerable<Genre> genres = default) => _sut.CreateGame(CreateDefaultGame(genres));

        public void Dispose() => _dbContext.Dispose();
        private static Game CreateDefaultGame(IEnumerable<Genre> genres = default) =>
            new()
            {
                Developer = "Bethesda",
                ReleaseDate = DateTime.Parse("01.01.2021"),
                IsCompleted = false,
                IsReplayable = false,
                Name = Guid.NewGuid().ToString(),
                Publisher = "Bethesda",
                Genres = genres
            };
    }
}
