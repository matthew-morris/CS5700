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
        int size;
        char[] characters;
        int[,] puzzle;
        Font font;
        SolidBrush brush;
        int boxSize;
        const int baseStartX = 25;
        const int baseStartY = 100;
        int offset;

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

                //Read until you reach end of file
                if (sr.Peek() >= 0)
                {
                    //Read the first character
                    firstLine = sr.ReadLine();
                    this.size = Convert.ToInt32(firstLine);
                }
                boxSize = 50 - this.size;
                offset = boxSize / 6;
                font = new Font("Arial", 30 - this.size);
                characters = new char[this.size];
                puzzle = new int[this.size, this.size];

                for (int x = 0; x < this.size; x++ )
                {
                    //Read the first character
                    myChar = (char)sr.Read();
                    if (myChar == 13 || myChar == 10 || myChar == 32)
                    {
                        x--;
                    }
                    else
                    {
                        characters[x] = myChar;
                        Console.Write(myChar);
                    }
                }
                for (int x = 0; x < this.size; x++)
                {
                    for (int y = 0; y < this.size; y++)
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
                                puzzle[x, y] = myChar - '0';
                            }
                            else
                            {
                                puzzle[x, y] = -1;
                            }
                        }
                    }
                }
                //close the file
                sr.Close();
                displayPuzzle();
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
            for ( int x = 0; x < this.size; x++ )
            {
                for ( int y = 0; y < this.size; y++ )
                {
                    if (puzzle[x, y] < 0)
                    {
                        System.IO.File.AppendAllText(filename, "- ");
                    }
                    else
                    {
                        System.IO.File.AppendAllText(filename, puzzle[x, y].ToString() + " ");
                    }
                }
                System.IO.File.AppendAllText(filename, Environment.NewLine);
            }
        }
        public void displayPuzzle()
        {
            this.graphics.Clear(this.BackColor);
            for ( int x = 0; x < this.size+1; x++)
            {
                graphics.DrawLine(Pens.Black, new Point(baseStartX, x*boxSize+baseStartY), new Point(baseStartX+this.size*boxSize, x*boxSize+baseStartY));
                graphics.DrawLine(Pens.Black, new Point(baseStartX+x*boxSize, baseStartY), new Point(x*boxSize+baseStartX, baseStartY+this.size*boxSize));
            }

            for ( int x = 0; x < this.size; x++ )
            {
                for ( int y = 0; y < this.size; y++ )
                {
                    if (puzzle[x, y] >= 0)
                    {
                        graphics.DrawString(puzzle[x, y].ToString(), font, brush, new Point(baseStartX + offset + y * boxSize, baseStartY + offset + x * boxSize));
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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