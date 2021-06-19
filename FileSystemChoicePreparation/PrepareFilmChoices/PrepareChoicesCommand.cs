using KitProjects.EnterpriseLibrary.Core.Abstractions;
using KitProjects.EnterpriseLibrary.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace KitProjects.FileSystemChoicePreparation.PrepareFilmChoices
{
    public class PrepareChoicesCommand : ICommand<PrepareChoicesCommandArgs, Choice[]>
    {
        public Choice[] Execute(PrepareChoicesCommandArgs args)
        {
            if (string.IsNullOrWhiteSpace(args.ImagesDirectoryPath))
                throw new ArgumentException("Указан пустой адрес к папке изображений.");

            var imagesFilePaths = Directory.GetFiles(args.ImagesDirectoryPath);
            if (imagesFilePaths.Length == 0)
                return Array.Empty<Choice>();

            var result = new List<Choice>();
            foreach (var path in imagesFilePaths)
            {
                var imageFileInfo = new FileInfo(path);
                result.Add(new Choice
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

        private static string GuessContentType(string extension) =>
            extension switch
            {
                ".png" => ContentType.PNG,
                ".jpeg" or ".jpg" => ContentType.JPG,
                ".webp" => ContentType.WEBP,
                _ => string.Empty,
            };
    }
}
