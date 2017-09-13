
namespace MyClasses
{
    public class Algorithm_Identifiers : Algorithm
    {
        public override bool MatchTest(Person p1, Person p2)
        {
            if (p1.SocialSecurityNumber == null || p1.StateFileNumber == null || p1.NewbornScreeningNumber == null )
            {
                return false;
            }
            if (p2.SocialSecurityNumber == null || p2.StateFileNumber == null || p2.NewbornScreeningNumber == null)
            {
                return false;
            }
            if ( p1?.SocialSecurityNumber == p2?.SocialSecurityNumber && p1?.StateFileNumber == p2?.StateFileNumber && p1?.NewbornScreeningNumber == p2?.NewbornScreeningNumber)
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
