
namespace MyClasses
{
    public class Algorithm_NameTest : Algorithm
    {
        public override bool MatchTest(Person p1, Person p2)
        {
            if ( p1.FirstName == p2.FirstName && p1.MiddleName == p2.MiddleName && p1.LastName == p2.LastName)
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
