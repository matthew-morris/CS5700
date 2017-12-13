using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public class OnePossibility : SolverTemplate
    {
        public OnePossibility(Puzzle p)
        {
            this.puzzle = p;
        }

        public override bool look()
        {
            for ( int x = 0; x < puzzle.size; x++ )
            {
                for ( int y = 0; y < puzzle.size; y++ )
                {
                    if (puzzle.myCells[x,y].value == -1 && puzzle.myCells[x, y].possibleValues.Count == 1)
                    {
                        puzzle.myCells[x, y].value = puzzle.myCells[x, y].possibleValues.ElementAt(0);
                        puzzle.myCells[x, y].possibleValues.RemoveAt(0);
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
