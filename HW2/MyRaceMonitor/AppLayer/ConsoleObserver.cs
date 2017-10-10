using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer
{
    public class ConsoleObserver : Observer
    {
        public void Update(Athlete a)
        {
            Console.WriteLine($"{a.BibNumber}\t{a.FirstName}\t{a.LastName}\t{a.Status}\t{a.Location}");
        }
    }
}
