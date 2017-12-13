using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public class Twins : SolverTemplate
    {
        public Twins(Puzzle p)
        {
            this.puzzle = p;
        }
        public override bool look()
        {
            /*
            for (int x = 0; x < puzzle.size; x++)
            {
                for (int y = 0; y < puzzle.size; y++)
                {
                    if (puzzle.myCells[x, y].value == -1 && puzzle.myCells[x,y].possibleValues.Count == 2)
                    {
                        int test1 = puzzle.myCells[x, y].possibleValues.ElementAt(0);
                        int test2 = puzzle.myCells[x, y].possibleValues.ElementAt(1);
                        for ( int a = 0; a < puzzle.size; a++ )
                        {
                            if ( a == y)
                            {
                                a++;
                            }
                            else if (puzzle.myCells[x,a].possibleValues.Count == 2 && puzzle.myCells[x,a].possibleValues.Contains(test1) && puzzle.myCells[x,a].possibleValues.Contains(test2))
                            {
                                for ( int b = 0; b < puzzle.size; b++ )
                                {
                                    if ( b == y)
                                    {
                                        b++;
                                    }
                                    else if (puzzle.myCells[b,y])
                                }
                            }
                        }
                    }
                }
            }
            */
            return false;
        }
    }
}
