using System.Collections.Generic;

namespace MyClasses
{
    public class PairsOfPersonsCollection : List<PairsOfPersons>
    {
        public Algorithm myAlg { get; set; }

        public PairsOfPersonsCollection runTest()
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
