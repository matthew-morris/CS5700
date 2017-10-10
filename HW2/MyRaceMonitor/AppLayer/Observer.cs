using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer
{
    public interface Observer
    {
        void Update(Athlete a);
    }
}
