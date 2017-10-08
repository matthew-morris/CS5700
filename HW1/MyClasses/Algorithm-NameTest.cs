
namespace MyClasses
{
    public class Algorithm_NameTest : Algorithm
    {
        public override bool MatchTest(Person p1, Person p2)
        {
            if (p1 != null && p2 != null)
            {
                if (p1.FirstName == null && p1.MiddleName == null && p1.LastName == null && p2.FirstName == null && p2.MiddleName == null && p2.LastName == null)
                {
                    return false;
                }
                if (p1?.FirstName == p2?.FirstName && p1?.MiddleName == p2?.MiddleName && p1?.LastName == p2?.LastName)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
