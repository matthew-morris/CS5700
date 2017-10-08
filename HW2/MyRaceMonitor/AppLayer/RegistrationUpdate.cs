using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaceData;

namespace AppLayer
{
    public class RegistrationUpdate : AthleteRaceStatus
    {
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string Gender { get; set; }
        private int Age { get; set; }

        public RegistrationUpdate(string u, string b, string t, string f, string l, string g, string a) : base(u, b, t)
        {
            FirstName = f;
            LastName = l;
            Gender = g;
            Age = Convert.ToInt32(a);
        }

        public override void Print()
        {
            Console.WriteLine($"{Status}\t{BibNumber}\t{Timestamp}\t{FirstName}\t{LastName}\t{Gender}\t{Age}");
        }
    }
}
