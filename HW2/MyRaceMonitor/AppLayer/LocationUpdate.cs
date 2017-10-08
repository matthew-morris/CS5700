using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer
{
    public class LocationUpdate : AthleteRaceStatus
    {
        public double Location;

        public LocationUpdate(string u, string b, string t, string l) : base(u, b, t)
        {
            Location = Convert.ToDouble(l);
        }

        public override void Print()
        {
            Console.WriteLine($"{Status}\t{BibNumber}\t{Timestamp}\t{Location}");
        }
    }
}
