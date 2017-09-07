using System;
using System.Collections.Generic;

namespace MyClasses
{
    public class FileWriter : Writer
    {
        public override void Write(List<Person> list, string filename)
        {
            filename = AppendExtension(filename, "txt");
            System.IO.File.WriteAllText(filename, "");
            foreach (Person thing in list)
            {
                using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(filename, true))
                {
                    file.WriteLine(thing.ToString());
                }

            }
            Console.WriteLine($"Successfully wrote to {filename}");
        }
    }
}
