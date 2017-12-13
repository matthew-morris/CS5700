using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public class Cell
    {
        public int value;
        public List<int> possibleValues;

        public Cell(int size)
        {
            value = -1;
            possibleValues = new List<int>();
            for ( int x =0; x < size; x++ )
            {
                possibleValues.Add(x+1);
            }
        }
    }
}
