using ArtLibTests.Fixtures;
using Database;
using Database.Exceptions;
using FluentAssertions;
using KitProjects.ArtLib.Core;
using KitProjects.ArtLib.Core.Models;
using System;
using Xunit;

namespace ArtLibTests
{
    [Collection("Db")]
    public sealed class PersistenceTests : IDisposable
    {
        private readonly GenresService _sut;
        private readonly AppDbContext _dbContext;

        public PersistenceTests(DbFixture fixture)
        {
            _dbContext = fixture.DbContext;
            _sut = new GenresService(new GenresRepository(_dbContext));
        }

        public void Dispose() => _dbContext.Dispose();

        [Fact]
        public void Cant_create_a_genre_with_set_id()
        {
            var newGenre = new Genre(1)
            {
                Name = "Blabla"
            };

            Action act = () => _sut.CreateGenre(newGenre);

            act.Should().ThrowExactly<DatabaseException>();
        }

        [Fact]
        public void Created_genre_has_new_id_generated()
        {
            var newGenre = new Genre
            {
                Name = "Новый жанр"
            };

            var result = _sut.CreateGenre(newGenre);

            result.Id.Should().NotBe(default);
        }
    }
}
