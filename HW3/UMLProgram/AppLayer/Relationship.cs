using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer
{
    public abstract class Relationship : Object
    {
        public Point startPoint, endPoint;
        bool[] resizeBoxesSelected;
        int boxSizes = 10;
        Rectangle thisRec;

        public Relationship(Point _startPoint, Point _endPoint)
        {
            startPoint = _startPoint;
            endPoint = _endPoint;

            x = startPoint.X;
            y = startPoint.Y;
            width = endPoint.X - startPoint.X;
            height = endPoint.Y - startPoint.Y;
            thisRec.X = x;
            thisRec.Y = y;
            thisRec.Width = width;
            thisRec.Height = height;

            isSelected = false;
            resizeBoxes = new Rectangle[2];
            resizeBoxes[0] = new Rectangle(startPoint.X - boxSizes, startPoint.Y - boxSizes, boxSizes, boxSizes);
            resizeBoxes[1] = new Rectangle(endPoint.X, endPoint.Y, boxSizes, boxSizes);
            resizeBoxesSelected = new bool[2] { false, false };
        }

        public override void draw(Graphics graphics)
        {
            graphics.DrawLine(Pens.Black, startPoint, endPoint);
            if (isSelected)
            {
                foreach(Rectangle thing in resizeBoxes)
                {
                    graphics.DrawRectangle(Pens.Red, thing);
                }
            }
            //graphics.DrawRectangle(Pens.Green, new Rectangle(x, y, width, height));
        }

        public override void move(Graphics graphics, int deltaX, int deltaY)
        {
            x += deltaX;
            y += deltaY;
            startPoint.X += deltaX;
            startPoint.Y += deltaY;
            endPoint.X += deltaX;
            endPoint.Y += deltaY;
            for ( int x = 0; x < 2; x++ )
            {
                resizeBoxes[x].X += deltaX;
                resizeBoxes[x].Y += deltaY;
            }
        }

        public override void resize(Graphics graphics, int mouseX, int mouseY, int deltaX, int deltaY, ref Rectangle Select)
        {
            if (deltaX >= -5 && deltaX <= 5 && deltaY >= -5 && deltaY <= 5)
            {
                if (resizeBoxesSelected[0] == true)
                { 
                    resizeBoxes[0].X += deltaX;
                    resizeBoxes[0].Y += deltaY;

                    startPoint.X += deltaX;
                    startPoint.Y += deltaY;

                    resizeSelectBox(ref Select);
                    resizeThisBox();
                }
                if (resizeBoxesSelected[1] == true)
                {
                    resizeBoxes[1].X += deltaX;
                    resizeBoxes[1].Y += deltaY;

                    endPoint.X += deltaX;
                    endPoint.Y += deltaY;

                    resizeSelectBox(ref Select);
                    resizeThisBox();
                }
            }
        }

        public override void testIfResizesBoxesSelected(int mouseX, int mouseY)
        {
            for ( int x = 0; x < 2; x++ )
            {
                if (mouseX >= resizeBoxes[x].X && mouseX <= resizeBoxes[x].X + resizeBoxes[x].Width)
                {
                    if (mouseY >= resizeBoxes[x].Y && mouseY <= resizeBoxes[x].Y + resizeBoxes[x].Height)
                    {
                        resizeBoxesSelected[x] = true;
                    }
                    else
                    {
                        resizeBoxesSelected[x] = false;
                    }
                }
                else
                {
                    resizeBoxesSelected[x] = false;
                }
            }
        }

        public void resizeSelectBox(ref Rectangle rec) {
            if (startPoint.Y <= endPoint.Y && startPoint.X <= endPoint.X)
            {
                rec.X = startPoint.X - boxSizes;
                rec.Y = startPoint.Y - boxSizes;
                rec.Width = endPoint.X - startPoint.X + boxSizes*2;
                rec.Height = endPoint.Y - startPoint.Y + boxSizes*2;
            }
            else if (startPoint.Y > endPoint.Y && startPoint.X <= endPoint.X)
            {
                rec.X = endPoint.X - rec.Width + boxSizes;
                rec.Y = startPoint.Y - rec.Height;
                rec.Width = endPoint.X - startPoint.X + boxSizes*2;
                rec.Height = startPoint.Y - endPoint.Y;
            }
            else if (startPoint.Y <= endPoint.Y)
            {
                rec.X = startPoint.X - rec.Width;
                rec.Y = endPoint.Y - rec.Height + boxSizes;
                rec.Width = startPoint.X - endPoint.X;
                rec.Height = endPoint.Y - startPoint.Y + boxSizes * 2;
            }
            else if (startPoint.Y > endPoint.Y)
            {
                rec.X = endPoint.X;
                rec.Y = endPoint.Y;
                rec.Width = startPoint.X - endPoint.X;
                rec.Height = startPoint.Y - endPoint.Y;
            }
        }
        public void resizeThisBox()
        {
            if (startPoint.Y <= endPoint.Y && startPoint.X <= endPoint.X)
            {
                x = startPoint.X ;
                y = startPoint.Y ;
                width = endPoint.X - startPoint.X ;
                height = endPoint.Y - startPoint.Y ;
            }
            else if (startPoint.Y > endPoint.Y && startPoint.X <= endPoint.X)
            {
                x = endPoint.X - width;
                y = startPoint.Y - height - boxSizes;
                width = endPoint.X - startPoint.X ;
                height = startPoint.Y - endPoint.Y - boxSizes*2;
            }
            else if (startPoint.Y <= endPoint.Y)
            {
                x = startPoint.X - width - boxSizes;
                y = endPoint.Y - height;
                width = startPoint.X - endPoint.X -boxSizes*2;
                height = endPoint.Y - startPoint.Y ;
            }
            else if (startPoint.Y > endPoint.Y)
            {
                x = endPoint.X +boxSizes;
                y = endPoint.Y +boxSizes;
                width = startPoint.X - endPoint.X - boxSizes * 2;
                height = startPoint.Y - endPoint.Y - boxSizes * 2;
            }
        }
    }
}