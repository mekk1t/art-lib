using KitProjects.EnterpriseLibrary.Core.Models;
using System.Collections.Generic;

namespace KitProjects.ChoiceVisualizer.Models
{
    public class RoundViewModel
    {
        public List<Card<Choice>> FirstHalf { get; set; }
        public List<Card<Choice>> SecondHalf { get; set; }
    }
}
