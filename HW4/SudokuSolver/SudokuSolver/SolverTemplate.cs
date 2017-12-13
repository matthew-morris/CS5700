using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public abstract class SolverTemplate
    {
        public Puzzle puzzle;
        public Stopwatch stopwatch = new Stopwatch();
        public bool succeeded = false;

        public Response run()
        {
            startTimer();
            succeeded = look();
            stopTimer();
            return new Response(getTimeSpent(), succeeded, checkIfDone());
        }

        public void startTimer()
        {
            succeeded = false;
            stopwatch.Start();
        }

        public abstract bool look();

        public void stopTimer()
        {
            stopwatch.Stop();
        }

        public TimeSpan getTimeSpent()
        {
            return stopwatch.Elapsed;
        }

        public bool checkIfDone()
        {
            for ( int x = 0; x < puzzle.size; x++ )
            {
                for ( int y = 0; y < puzzle.size; y++ )
                {
                    if (puzzle.myCells[x, y].value == -1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
