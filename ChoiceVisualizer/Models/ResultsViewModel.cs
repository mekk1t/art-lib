using KitProjects.EnterpriseLibrary.Core.Models;

namespace KitProjects.ChoiceVisualizer.Models
{
    public class ResultsViewModel
    {
        public Card<Choice> Winner { get; set; }
        public Card<Choice> SecondPlace { get; set; }
        public Card<Choice> ThirdPlace { get; set; }
    }
}
