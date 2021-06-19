using KitProjects.EnterpriseLibrary.Core.Models.Films;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitProjects.ChoiceVisualizer.Models
{
    public class FinalsViewModel
    {
        public Card<FilmChoice> First { get; set; }
        public Card<FilmChoice> Second { get; set; }
        public List<Card<FilmChoice>> ThirdPlaceContestants { get; set; }
    }
}
