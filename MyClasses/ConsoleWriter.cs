using System;
using System.Collections.Generic;

namespace MyClasses
{
    public class ConsoleWriter : Writer
    {
        public override void Write(List<Person> list, string filename = "")
        {
            foreach (Person thing in list)
            {
                Console.WriteLine(thing.ToString());
            }
        }
    }
}
