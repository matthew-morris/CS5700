using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer
{
    public class Race
    {
        public int Id;
        public string Title;
        public DateTime StartDateTime;
        public List<Athlete> Athletes;

        public Race(int _Id, string _Title, DateTime _StartDateTime)
        {
            Id = _Id;
            Title = _Title;
            StartDateTime = _StartDateTime;
            Athletes = new List<Athlete>();
        }
    }
}
