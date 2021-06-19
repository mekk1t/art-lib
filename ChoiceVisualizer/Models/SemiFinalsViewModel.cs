using KitProjects.EnterpriseLibrary.Core.Models.Films;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitProjects.ChoiceVisualizer.Models
{
    public class SemiFinalsViewModel
    {
        public List<Card<FilmChoice>> FirstPair { get; set; }
        public List<Card<FilmChoice>> SecondPair { get; set; }
    }
}
