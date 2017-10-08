
namespace MyClasses
{
    public class Algorithm_MotherTest : Algorithm
    {
        public override bool MatchTest(Person p1, Person p2)
        {
            if (p1.MotherFirstName == null || p1.MotherMiddleName == null || p1.MotherLastName == null)
            {
                return false;
            }
            if (p2.MotherFirstName == null || p2.MotherMiddleName == null || p2.MotherLastName == null)
            {
                return false;
            }
            if (p1.BirthDay.Equals(null) || p1.BirthMonth.Equals(null) || p1.BirthYear.Equals(null) )
            {
                return false;
            }
            if (p2.BirthDay.Equals(null) || p2.BirthMonth.Equals(null) || p2.BirthYear.Equals(null))
            {
                return false;
            }
            if ( p1?.MotherFirstName == p2?.MotherFirstName && p1?.MotherMiddleName == p2?.MotherMiddleName && p1?.MotherLastName == p2?.MotherLastName && p1?.BirthDay == p2?.BirthDay && p1?.BirthMonth == p2?.BirthMonth && p1?.BirthYear == p2?.BirthYear)
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
