
namespace MyClasses
{
    public class PersonMatch
    {
        public Writer myWriter { get; set; }
        public string MyOutputFile { get; set; }
        public PersonCollection myPersonCollection { get; set; }
        public PairsOfPersonsCollection myPairs { get; set; }
        public PairsOfPersonsCollection myMatchedPairs { get; set; }

        public PersonMatch()
        {
            myPairs = new PairsOfPersonsCollection();
            myMatchedPairs = new PairsOfPersonsCollection();
        }

        public void Write()
        {
            myWriter?.Write(this.myMatchedPairs, MyOutputFile);
        }

        public void CreateUnmatchedPairs()
        {
            for (int x = 0; x < myPersonCollection.Count - 1; x++)
            {
                for (int y = x + 1; y < myPersonCollection.Count; y++)
                {
                    myPairs.Add(new PairsOfPersons(myPersonCollection[x], myPersonCollection[y]));
                }
            }
        }
        public void RunTest()
        {
            myMatchedPairs = myPairs.runTest();
        }
    }
}
