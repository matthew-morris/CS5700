
namespace MyClasses
{
    public abstract class Algorithm
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public abstract bool MatchTest(Person p1, Person p2);
    }
}
