using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public class Puzzle
    {
        public Cell[,] myCells;
        public int[] possibleValues;
        public int size;

        public Puzzle(int _size)
        {
            size = _size;
            myCells = new Cell[size, size];
            possibleValues = new int[size];
            for ( int x = 0; x < size; x++ )
            {
                for ( int y = 0; y < size; y++ )
                {
                    myCells[x, y] = new Cell(size);
                }
            }
        }

        public bool testIfBadPuzzle()
        {
            for ( int x = 0; x < size; x++ )
            {
                for ( int y = 0; y < size; y++ )
                {
                    Cell tempCell = myCells[x, y];
                    if (tempCell.value > 0)
                    {
                        for (int _x = y + 1; _x < size; _x++)
                        {
                            if (tempCell.value == myCells[x, _x].value)
                            {
                                return true;
                            }
                        }
                    }
                    if( tempCell.value > 0 )
                    {
                        for (int _x = x + 1; _x < size; _x++)
                        {
                            if (tempCell.value == myCells[_x, y].value)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        public void setPossibilities()
        {
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    Cell tempCell = myCells[x, y];
                    if (tempCell.value > 0)
                    {
                        for ( int z = 0; z < size; z++ )
                        {
                            myCells[x, z].possibleValues.Remove(tempCell.value);
                            myCells[z, y].possibleValues.Remove(tempCell.value);
                        }
                    }
                }
            }
        }
    }
}
