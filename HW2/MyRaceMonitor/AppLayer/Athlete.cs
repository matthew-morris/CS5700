using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RaceData;
using AppLayer;

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
        public RaceData.AthleteRaceStatus Status;
        public double Location;
        public DateTime startTime;
        public DateTime finishTime;

        public void NotifyObservers()
        {
            for ( int i = 0; i < Observers.Count; i++)
            {
                Observer observer = (Observer)Observers.ElementAt(i);
                observer.Update(this);
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

        public Athlete( RaceData.AthleteRaceStatus _status, int _bib, string _first, string _last, string _gender, int _age)
        {
            Status = _status;
            BibNumber = _bib;
            FirstName = _first;
            LastName = _last;
            Gender = _gender;
            Age = _age;
            Observers = new List<Observer>();
        }
    }
}
