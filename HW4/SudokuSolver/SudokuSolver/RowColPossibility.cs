using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public class RowColPossibility : SolverTemplate
    {
        public RowColPossibility(Puzzle p)
        {
            this.puzzle = p;
        }

        public override bool look()
        {
            for (int x = 0; x < puzzle.size; x++)
            {
                for (int y = 0; y < puzzle.size; y++)
                {
                    if (puzzle.myCells[x, y].value == -1)
                    {
                        foreach(int z in puzzle.myCells[x,y].possibleValues)
                        {
                            bool fail = false;
                            // checks if possibility occurs anywhere else in row
                            for ( int a = 0; a < puzzle.size; a++ )
                            {
                                if ( a == y)
                                {
                                    a++;
                                }
                                else if ( puzzle.myCells[x, a].possibleValues.Contains(z))
                                {
                                    fail = true;
                                }
                            }
                            if ( fail == false)
                            {
                                puzzle.myCells[x, y].value = z;
                                puzzle.myCells[x, y].possibleValues.Clear();
                                return true;
                            }
                            fail = false;
                            // checks if possibility occurs anywhere else in column
                            for (int a = 0; a < puzzle.size; a++)
                            {
                                if (a == x)
                                {
                                    a++;
                                }
                                else if (puzzle.myCells[a, y].possibleValues.Contains(z))
                                {
                                    fail = true;
                                }
                            }
                            if (fail == false)
                            {
                                puzzle.myCells[x, y].value = z;
                                puzzle.myCells[x, y].possibleValues.Clear();
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
    }
}
