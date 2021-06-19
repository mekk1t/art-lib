using KitProjects.EnterpriseLibrary.Core.Models.Films;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitProjects.ChoiceVisualizer.Models
{
    public class ResultsViewModel
    {
        public Card<FilmChoice> Winner { get; set; }
        public Card<FilmChoice> SecondPlace { get; set; }
        public Card<FilmChoice> ThirdPlace { get; set; }
    }
}
