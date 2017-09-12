using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClasses
{
    public class Algorithm_MotherTest : Algorithm
    {
        public override bool MatchTest(Person p1, Person p2)
        {
            if ( p1.MotherFirstName == p2.MotherFirstName && p1.MotherMiddleName == p2.MotherMiddleName && p1.MotherLastName == p2.MotherLastName && p1.BirthDay == p2.BirthDay && p1.BirthMonth == p2.BirthMonth && p1.BirthYear == p2.BirthYear)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
