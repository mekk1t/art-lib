using KitProjects.EnterpriseLibrary.Core.Models.Films;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitProjects.ChoiceVisualizer.Models
{
    public class RoundViewModel
    {
        public List<Card<FilmChoice>> FirstHalf { get; set; }
        public List<Card<FilmChoice>> SecondHalf { get; set; }
    }
}
