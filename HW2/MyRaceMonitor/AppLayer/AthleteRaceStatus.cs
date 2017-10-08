using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaceData;

namespace AppLayer
{
    public class AthleteRaceStatus
    {
        private RaceData.AthleteRaceStatus Status { get; set; }
        private int BibNumber { get; set; }
        private DateTime Timestamp { get; set; }

        public AthleteRaceStatus(RaceData.AthleteRaceStatus u, int b, DateTime t)
        {
            this.Status = u;
            this.BibNumber = b;
            this.Timestamp = t;
        }

        public void printAthleteRaceStatus()
        {
            Console.WriteLine($"{Status}\t{BibNumber}\t{Timestamp}");
        }
    }
}
