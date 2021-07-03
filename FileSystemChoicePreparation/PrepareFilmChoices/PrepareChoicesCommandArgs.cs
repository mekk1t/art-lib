namespace KitProjects.FileSystemChoicePreparation.PrepareFilmChoices
{
    public class PrepareChoicesCommandArgs
    {
        public string ImagesDirectoryPath { get; }

        public PrepareChoicesCommandArgs(string imagesDirectoryPath)
        {
            ImagesDirectoryPath = imagesDirectoryPath;
        }
    }
}
