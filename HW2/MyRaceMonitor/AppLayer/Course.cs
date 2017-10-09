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

        public Course(int _Id, string _Name, double _TotalDistance)
        {
            Id = _Id;
            Name = _Name;
            TotalDistance = _TotalDistance;
            Races = new List<Race>();
        }

        public void addRace(Race r)
        {
            Races.Add(r);
        }
    }
}
