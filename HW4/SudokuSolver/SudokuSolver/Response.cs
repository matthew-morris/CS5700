using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public class Response
    {
        public TimeSpan timeSpent;
        public bool succeeded;
        public bool done;

        public Response(TimeSpan _timeSpent, bool _succeeded, bool _done)
        {
            timeSpent = _timeSpent;
            succeeded = _succeeded;
            done = _done;
        }
    }
}
