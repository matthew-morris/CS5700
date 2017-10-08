using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer
{
    public class FinishedUpdate : AthleteRaceStatus
    {
        public DateTime OfficialEndTime;

        public FinishedUpdate(string u, string b, string t, string o) : base(u,b,t)
        {
            OfficialEndTime = Convert.ToDateTime(o);
        }

        public override void Print()
        {
            Console.WriteLine($"{Status}\t{BibNumber}\t{Timestamp}\t{OfficialEndTime}");
        }
    }
}
