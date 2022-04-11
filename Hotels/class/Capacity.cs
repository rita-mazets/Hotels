using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels
{
    public class Capacity
    {
        public bool One=false;
        public bool Two=false;
        public bool Three=false;
        public bool Family=false;

        public string GetOne()
        {
            return "Одноместный";
        }

        public string GetTwo()
        {
            return "Двуместный";
        }

        public string GetThree()
        {
            return "Трехместный";
        }

        public string GetFamily()
        {
            return "Семейный";
        }
    }
}
