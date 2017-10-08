using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaceData;

namespace AppLayer
{
    public abstract class AthleteRaceStatus
    {
        public RaceData.AthleteRaceStatus Status { get; set; }
        public int BibNumber { get; set; }
        public DateTime Timestamp { get; set; }

        public AthleteRaceStatus(string u, string b, string t)
        {
            if (u == "Registered")
            {
                this.Status = (RaceData.AthleteRaceStatus)1;
            }
            else if (u == "DidNotStart")
            {
                this.Status = (RaceData.AthleteRaceStatus)2;
            }
            else if (u == "Started")
            {
                this.Status = (RaceData.AthleteRaceStatus)3;
            }
            else if (u == "OnCourse")
            {
                this.Status = (RaceData.AthleteRaceStatus)4;
            }
            else if (u == "DidNotFinish")
            {
                this.Status = (RaceData.AthleteRaceStatus)5;
            }
            else if (u == "Finished")
            {
                this.Status = (RaceData.AthleteRaceStatus)6;
            }
            this.BibNumber = Convert.ToInt32(b);
            this.Timestamp = Convert.ToDateTime(t);
        }

        public abstract void Print();
    }
}
