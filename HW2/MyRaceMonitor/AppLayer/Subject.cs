using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer
{
    public interface Subject
    {
        void RegisterObserver(Observer o);
        void RemoveObserver(Observer o);
        void NotifyObservers();
    }
}
