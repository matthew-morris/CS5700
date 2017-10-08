using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer
{
    public class Course
    {
        public int Id;
        public string Name;
        public double TotalDistance;
        public List<Race> Races;
    }
}
