using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer
{
    public class Athlete : Subject
    {
        public List<Observer> Observers;
        public int BibNumber;
        public string FirstName;
        public string LastName;
        public string Gender;
        public int Age;

        public void NotifyObservers()
        {
            for ( int i = 0; i < Observers.Count; i++)
            {
                Observer observer = (Observer)Observers.ElementAt(i);
                observer.Update();
            }
        }

        public void RegisterObserver(Observer o)
        {
            Observers.Add(o);
        }

        public void RemoveObserver(Observer o)
        {
            int i = Observers.IndexOf(o);
            if (i >= 0)
            {
                Observers.RemoveAt(i);
            }
        }
    }
}
