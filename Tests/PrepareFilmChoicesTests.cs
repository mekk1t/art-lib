using FluentAssertions;
using KitProjects.EnterpriseLibrary.Core.Abstractions;
using KitProjects.EnterpriseLibrary.Core.Models.Films;
using KitProjects.FileSystemChoicePreparation.PrepareFilmChoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace KitProjects.Tests
{
    public class PrepareFilmChoicesTests
    {
        private readonly ICommand<PrepareFilmChoicesCommandArgs, FilmChoice[]> _sut;

        public PrepareFilmChoicesTests() => _sut = new PrepareFilmChoicesCommand();

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData(" ")]
        public void Cant_prepare_film_choices_with_invalid_images_directory_path(string path)
        {
            Action act = () => _sut.Execute(new PrepareFilmChoicesCommandArgs(path));

            act.Should().ThrowExactly<ArgumentException>().WithMessage("Указан пустой адрес к папке изображений.");
        }

        [Fact]
        public void Empty_folder_returns_empty_array_of_choices()
        {
            string emptyDirectoryPath = @"C:\Users\admin\Pictures\Empty";

            var result = _sut.Execute(new PrepareFilmChoicesCommandArgs(emptyDirectoryPath));

            result.Should().BeEmpty();
        }

        [Fact]
        public void Command_works()
        {
            string imagesDirectoryPath = @"C:\Users\admin\Pictures\ХронологияПрослушиваний";

            var result = _sut.Execute(new PrepareFilmChoicesCommandArgs(imagesDirectoryPath));

            result.Should().NotBeEmpty();
        }
    }
}
