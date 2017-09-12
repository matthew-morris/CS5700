
namespace MyClasses
{
    public class Algorithm_Identifiers : Algorithm
    {
        public override bool MatchTest(Person p1, Person p2)
        {
            if ( p1.SocialSecurityNumber == p2.SocialSecurityNumber && p1.StateFileNumber == p2.StateFileNumber && p1.NewbornScreeningNumber == p2.NewbornScreeningNumber)
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
