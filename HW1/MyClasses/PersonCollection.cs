﻿using System;
using System.Collections.Generic;

namespace MyClasses
{
    public class PersonCollection : List<Person>
    {
        public Reader myReader { get; set; }
        public string MyDataFile { get; set; }

        public void PrintCollection(string header)
        {
            Console.WriteLine("");
            Console.WriteLine($"Number of {header} back in: {Count}");

            foreach (Person thing in this)
            {
                Console.WriteLine(thing);
            }
        }

        public void Read()
        {
            myReader?.Read(this, MyDataFile);
        }
    }
}
