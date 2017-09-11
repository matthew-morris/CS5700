using System;
using System.Collections.Generic;

namespace MyClasses
{
    public class ConsoleWriter : Writer
    {
        public override void Write(List<PairsOfPersons> list, string filename = "")
        {
            foreach (PairsOfPersons thing in list)
            {
                Console.WriteLine("Match:");
                Console.WriteLine($"\tId = {thing.p1.ObjectId}, Name = {thing.p1.FirstName} {thing.p1.MiddleName} {thing.p1.LastName}, BirthDate = {thing.p1.BirthMonth}/{thing.p1.BirthDay}/{thing.p1.BirthYear}");
                Console.WriteLine($"\tId = {thing.p2.ObjectId}, Name = {thing.p2.FirstName} {thing.p2.MiddleName} {thing.p2.LastName}, BirthDate = {thing.p2.BirthMonth}/{thing.p2.BirthDay}/{thing.p2.BirthYear}");
            }
        }
    }
}
