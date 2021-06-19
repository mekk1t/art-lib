using KitProjects.EnterpriseLibrary.Core.Abstractions;
using KitProjects.EnterpriseLibrary.Core.Models;
using KitProjects.EnterpriseLibrary.Core.Models.Films;
using System;
using System.Collections.Generic;
using System.IO;

namespace KitProjects.FileSystemChoicePreparation.PrepareFilmChoices
{
    public class PrepareFilmChoicesCommand : ICommand<PrepareFilmChoicesCommandArgs, FilmChoice[]>
    {
        public FilmChoice[] Execute(PrepareFilmChoicesCommandArgs args)
        {
            if (string.IsNullOrWhiteSpace(args.ImagesDirectoryPath))
                throw new ArgumentException("Указан пустой адрес к папке изображений.");

            var imagesFilePaths = Directory.GetFiles(args.ImagesDirectoryPath);
            if (imagesFilePaths.Length == 0)
                return Array.Empty<FilmChoice>();

            var result = new List<FilmChoice>();
            foreach (var path in imagesFilePaths)
            {
                var imageFileInfo = new FileInfo(path);
                result.Add(new FilmChoice
                {
                    Title = imageFileInfo.Name.Split('.')[^2],
                    Image = new Image
                    {
                        Link = new Uri(path),
                        Base64 = Convert.ToBase64String(File.ReadAllBytes(path)),
                        ContentType = GuessContentType(imageFileInfo.Extension)
                    }
                });
            }

            return result.ToArray();
        }

        private string GuessContentType(string extension) =>
            extension switch
            {
                ".png" => ContentType.PNG,
                ".jpeg" or ".jpg" => ContentType.JPG,
                _ => string.Empty,
            };
    }
}
