using ArtLibTests.Fixtures;
using Database;
using Database.Exceptions;
using FluentAssertions;
using KitProjects.ArtLib.Core;
using KitProjects.ArtLib.Core.Models;
using System;
using System.Linq;
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

        [Fact]
        public void List_all_genres()
        {
            SeedGenre();
            SeedGenre();
            SeedGenre();

            var result = _sut.GetAllGenres();

            result.Should().NotBeEmpty();
            result.ToList().ForEach(genre => genre.Id.Should().NotBe(default));
        }

        [Fact]
        public void Cant_get_genre_by_default_id()
        {
            Action act = () => _sut.GetGenreByIdOrDefault(default);

            act.Should().ThrowExactly<DatabaseException>();
        }

        [Fact]
        public void Can_get_genre_by_id()
        {
            var seed = SeedGenre();

            var result = _sut.GetGenreByIdOrDefault(seed.Id);

            result.Should().NotBeNull();
            result.Id.Should().Be(seed.Id);
        }

        [Fact]
        public void Genre_by_nonexistent_id_returns_default()
        {
            var result = _sut.GetGenreByIdOrDefault(long.MaxValue);

            result.Should().BeNull();
        }

        [Fact]
        public void Cant_pass_null_to_update_genre()
        {
            Action act = () => _sut.UpdateGenre(null);

            act.Should().Throw<Exception>();
        }

        [Fact]
        public void Cant_update_genre_without_id()
        {
            var update = new Genre() { Name = "Новый жанр." };

            Action act = () => _sut.UpdateGenre(update);

            act.Should().Throw<DatabaseException>();
        }

        [Fact]
        public void Genre_update_overwrites_its_name()
        {
            var seed = SeedGenre();
            var update = new Genre(seed.Id) { Name = "I am Death. The destroyer of worlds." };

            Action act = () => _sut.UpdateGenre(update);
            act.Should().NotThrow();
            var result = _sut.GetGenreByIdOrDefault(seed.Id)
                .Name.Should().Be("I am Death. The destroyer of worlds.");
        }

        [Fact]
        public void Can_delete_genre_by_id()
        {
            var seed = SeedGenre();

            Action act = () => _sut.DeleteGenreById(seed.Id);

            act.Should().NotThrow();
            _sut.GetGenreByIdOrDefault(seed.Id).Should().BeNull();
        }

        private Genre SeedGenre() => _sut.CreateGenre(new Genre() { Name = Guid.NewGuid().ToString() });
    }
}
