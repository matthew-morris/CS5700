using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer
{
    public class StartedUpdate : AthleteRaceStatus
    {
        public DateTime OfficialStartTime;

        public StartedUpdate(string u, string b, string t, string o) : base(u,b,t)
        {
            OfficialStartTime = Convert.ToDateTime(o);
        }
        public override void Print()
        {
            Console.WriteLine($"{Status}\t{BibNumber}\t{Timestamp}\t{OfficialStartTime}");
        }
    }
}
