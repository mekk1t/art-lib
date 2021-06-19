using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitProjects.ChoiceVisualizer.Models
{
    public class Card<T>
    {
        public T Choice { get; set; }
        public bool Selected { get; set; }
    }
}
