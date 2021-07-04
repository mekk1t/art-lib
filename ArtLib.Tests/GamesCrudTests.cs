using ArtLibTests.Fixtures;
using Database;
using FluentAssertions;
using KitProjects.ArtLib.Core;
using KitProjects.ArtLib.Core.Models;
using KitProjects.ArtLib.Database;
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

        public GamesCrudTests(DbFixture fixture)
        {
            _dbContext = fixture.DbContext;
            _sut = new GamesService(new GamesRepository(_dbContext));
        }

        [Fact]
        public void Can_create_new_game_without_genres()
        {
            var newGame = new Game
            {
                Developer = "Bethesda",
                ReleaseDate = DateTime.Parse("01.01.2021"),
                IsCompleted = false,
                IsReplayable = false,
                Name = "Fallout",
                Publisher = "Bethesda"
            };

            var result = _sut.CreateGame(newGame);

            result.Should().NotBeNull();
        }

        [Fact]
        public void Can_create_new_game_with_existing_genres()
        {

        }

        [Fact]
        public void Can_create_new_game_with_new_genres()
        {

        }

        public void Dispose() => _dbContext.Dispose();
    }
}
