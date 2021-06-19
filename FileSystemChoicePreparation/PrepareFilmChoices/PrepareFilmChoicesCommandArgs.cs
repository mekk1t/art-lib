namespace KitProjects.FileSystemChoicePreparation.PrepareFilmChoices
{
    public class PrepareFilmChoicesCommandArgs
    {
        public string ImagesDirectoryPath { get; }

        public PrepareFilmChoicesCommandArgs(string imagesDirectoryPath)
        {
            ImagesDirectoryPath = imagesDirectoryPath;
        }
    }
}
