﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClasses
{
    public class PairsOfPersons
    { 
        public Person p1 { get; set; }
        public Person p2 { get; set; }

        public PairsOfPersons(Person person1, Person person2)
        {
            p1 = person1;
            p2 = person2;
        }
    }
}