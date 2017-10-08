using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaceData;

namespace AppLayer
{
    public class DidNotFinishUpdate : AthleteRaceStatus
    {
        public DidNotFinishUpdate(string u, string b, string t) : base(u, b, t)
        {

        }

        public override void Print()
        {
            Console.WriteLine($"{Status}\t{BibNumber}\t{Timestamp}");
        }
    }
}
