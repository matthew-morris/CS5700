using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SudokuSolver
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        Font font;
        SolidBrush brush;
        int boxSize;
        const int baseStartX = 25;
        const int baseStartY = 100;
        int offset;
        Puzzle myPuzzle;

        int onePossSuccesses = 0;
        int rowColSuccesses = 0;
        int twinsSuccesses = 0;
        int zeroPossSuccesses = 0;

        TimeSpan onePossTime, rowColTime, twinsTime, zeroPossTime;

        public Form1()
        {
            InitializeComponent();
            graphics = this.CreateGraphics();
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            textBox1.Text = "sample1.txt";
            brush = new SolidBrush(Color.Black);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            readPuzzle(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            writePuzzle(textBox2.Text);
        }
        public void readPuzzle(string filename)
        {
            char myChar;
            string firstLine;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(filename);
                label3.Text = "";
                label4.Text = "";

                //Read until you reach end of file
                if (sr.Peek() >= 0)
                {
                    //Read the first character
                    firstLine = sr.ReadLine();
                    myPuzzle = new Puzzle(Convert.ToInt32(firstLine));
                }
                boxSize = 50 - myPuzzle.size;
                offset = boxSize / 6;
                font = new Font("Arial", 30 - myPuzzle.size);

                //characters = new char[this.size];
                //puzzle = new int[this.size, this.size];


                for (int x = 0; x < myPuzzle.size; x++ )
                {
                    //Read the first character
                    myChar = (char)sr.Read();
                    if (myChar == 13 || myChar == 10 || myChar == 32)
                    {
                        x--;
                    }
                    else
                    {
                        myPuzzle.possibleValues[x] = myChar;
                    }
                }
                for (int x = 0; x < myPuzzle.size; x++)
                {
                    for (int y = 0; y < myPuzzle.size; y++)
                    {
                        //Read the first character
                        myChar = (char)sr.Read();
                        // Check that input was valid
                        //
                        if (myChar == 13 || myChar == 10 || myChar == 32)
                        {
                            y--;
                        }
                        else
                        {
                            if (myChar != '-')
                            {
                                myPuzzle.myCells[x, y].value = myChar - '0';
                            }
                            else
                            {
                                myPuzzle.myCells[x, y].value = -1;
                            }
                        }
                    }
                }
                //close the file
                sr.Close();
                if (myPuzzle.testIfBadPuzzle())
                {
                    label4.Text = "Bad Puzzle!";
                }
                refreshPuzzle();
            }
            catch
            {
                label3.Text = "File not found or is wrong format";
            }
        }
        public void writePuzzle(string filename)
        {
            // clear file
            System.IO.File.WriteAllText(filename, "");
            for ( int x = 0; x < myPuzzle.size; x++ )
            {
                for ( int y = 0; y < myPuzzle.size; y++ )
                {
                    if (myPuzzle.myCells[x, y].value < 0)
                    {
                        System.IO.File.AppendAllText(filename, "- ");
                    }
                    else
                    {
                        System.IO.File.AppendAllText(filename, myPuzzle.myCells[x, y].value.ToString() + " ");
                    }
                }
                System.IO.File.AppendAllText(filename, Environment.NewLine);
            }
        }
        public void displayPuzzle()
        {
            this.graphics.Clear(this.BackColor);
            for ( int x = 0; x < myPuzzle.size+1; x++)
            {
                graphics.DrawLine(Pens.Black, new Point(baseStartX, x*boxSize+baseStartY), new Point(baseStartX+myPuzzle.size*boxSize, x*boxSize+baseStartY));
                graphics.DrawLine(Pens.Black, new Point(baseStartX+x*boxSize, baseStartY), new Point(x*boxSize+baseStartX, baseStartY+myPuzzle.size*boxSize));
            }

            for ( int x = 0; x < myPuzzle.size; x++ )
            {
                for ( int y = 0; y < myPuzzle.size; y++ )
                {
                    if (myPuzzle.myCells[x, y].value >= 0)
                    {
                        graphics.DrawString(myPuzzle.myCells[x, y].value.ToString(), font, brush, new Point(baseStartX + offset + y * boxSize, baseStartY + offset + x * boxSize));
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OnePossibility onePoss = new OnePossibility(myPuzzle);
            RowColPossibility rowColPoss = new RowColPossibility(myPuzzle);
            ZeroPossibility zeroPoss = new ZeroPossibility(myPuzzle);

            while (true)
            {
                Response onePossResponse = onePoss.run();
                onePossTime += onePossResponse.timeSpent;
                if (onePossResponse.succeeded)
                {
                    onePossSuccesses++;
                    refreshPuzzle();
                    richTextBox1.Text += "One possibility in Cell strategy succeeded and took " + onePossResponse.timeSpent + "\n";
                    if (onePossResponse.done)
                    {
                        richTextBox1.Text += "Puzzle complete!\n";
                        break;
                    }
                }
                else
                {
                    richTextBox1.Text += "One possibility in Cell strategy failed and took " + onePossResponse.timeSpent + "\n";
                }

                Response rowColResponse = rowColPoss.run();
                rowColTime += rowColResponse.timeSpent;
                if (rowColResponse.succeeded)
                {
                    rowColSuccesses++;
                    refreshPuzzle();
                    richTextBox1.Text += "One possibility in row or column strategy succeeded and took " + rowColResponse.timeSpent + "\n";
                    if (rowColResponse.done)
                    {
                        richTextBox1.Text += "Puzzle complete!\n";
                        break;
                    }
                }
                else
                {
                    richTextBox1.Text += "One possibility in row or column strategy failed and took " + rowColResponse.timeSpent + "\n";
                }

                Response zeroPossResponse = zeroPoss.run();
                zeroPossTime += zeroPossResponse.timeSpent;
                if (zeroPossResponse.succeeded)
                {
                    zeroPossSuccesses++;
                    richTextBox1.Text += "Zero possibility succeeded and took " + zeroPossResponse.timeSpent + "\nPuzzle unsolvable!\n";
                    break;
                }
                else
                {
                    richTextBox1.Text += "Zero Possibility failed and took " + zeroPossResponse.timeSpent + "\nPuzzle still solvable!\n";
                }

                if (!onePossResponse.succeeded && !rowColResponse.succeeded)
                {
                    richTextBox1.Text += "All methods failed, puzzle unsolvable\n";
                    break;
                }
            }
        }

        public void refreshPuzzle()
        {
            displayPuzzle();
            myPuzzle.setPossibilities();
            label11.Text = onePossSuccesses.ToString();
            label12.Text = onePossTime.ToString();
            label13.Text = rowColSuccesses.ToString();
            label14.Text = rowColTime.ToString();
            label15.Text = twinsSuccesses.ToString();
            label16.Text = twinsTime.ToString();
            label17.Text = zeroPossSuccesses.ToString();
            label18.Text = zeroPossTime.ToString();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}

/* 1 Possiblity strategy
If a cell only has 1 possibility left, put it there

Twins
if 2 cells in a row or col have the same 2 possibilities and only those possibilties, the other cells in the row and col can't have those possibilities

1 possibilitiy in a row or col

0 possibility
results in bad puzzle


Template method pattern
startTimer()
look()
makeChanges()
stopTimer()
*/