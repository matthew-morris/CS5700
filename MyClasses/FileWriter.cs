using System;
using System.Collections.Generic;

namespace MyClasses
{
    public class FileWriter : Writer
    {
        public override void Write(List<PairsOfPersons> list, string filename)
        {
            filename = AppendExtension(filename, "txt");
            System.IO.File.WriteAllText(filename, "");
            foreach (PairsOfPersons thing in list)
            {
                using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(filename, true))
                {
                    file.WriteLine($"{thing.p1.ObjectId}, {thing.p2.ObjectId}");
                }

            }
            Console.WriteLine($"Successfully wrote to {filename}");
        }
    }
}
