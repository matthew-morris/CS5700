using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuSolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Tests
{
    [TestClass()]
    public class PuzzleTests
    {
        [TestMethod()]
        public void testIfBadPuzzleTest()
        {
            // make puzzle of size 4
            Puzzle puzzle = new Puzzle(4);

            puzzle.myCells[1, 2] = new Cell(4);
            puzzle.myCells[1, 2].value = 3;

            if(puzzle.testIfBadPuzzle())
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void setPossibilitiesTest()
        {
            // make puzzle of size 4
            Puzzle puzzle = new Puzzle(4);

            for ( int x = 0; x < 3; x++ )
            {
                puzzle.myCells[0, x] = new Cell(4);
                puzzle.myCells[0, x].value = x+1;
            }

            puzzle.setPossibilities();

            if (!(puzzle.myCells[0,3].possibleValues.Count == 1))
            {
                Assert.Fail();
            }
        }
    }
}