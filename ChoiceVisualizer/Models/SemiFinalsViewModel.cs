using KitProjects.EnterpriseLibrary.Core.Models;
using System.Collections.Generic;

namespace KitProjects.ChoiceVisualizer.Models
{
    public class SemiFinalsViewModel
    {
        public List<Card<Choice>> FirstPair { get; set; }
        public List<Card<Choice>> SecondPair { get; set; }
    }
}
