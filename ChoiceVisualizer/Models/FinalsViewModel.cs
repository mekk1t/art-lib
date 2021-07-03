using KitProjects.EnterpriseLibrary.Core.Models;
using System.Collections.Generic;

namespace KitProjects.ChoiceVisualizer.Models
{
    public class FinalsViewModel
    {
        public Card<Choice> First { get; set; }
        public Card<Choice> Second { get; set; }
        public List<Card<Choice>> ThirdPlaceContestants { get; set; }
    }
}
