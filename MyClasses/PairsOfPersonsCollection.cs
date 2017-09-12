using System.Collections.Generic;

namespace MyClasses
{
    public class PairsOfPersonsCollection : List<PairsOfPersons>
    {
        public PairsOfPersonsCollection runTest(Algorithm myAlg)
        {
            PairsOfPersonsCollection myList = new PairsOfPersonsCollection();
            foreach (PairsOfPersons thing in this)
            {
                if (myAlg.MatchTest(thing.p1, thing.p2))
                {
                    myList.Add(thing);
                }
            }

            return myList;
        }
    }
}
