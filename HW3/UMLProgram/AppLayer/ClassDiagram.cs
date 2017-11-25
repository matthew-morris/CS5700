using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer
{
    public class ClassDiagram : Object
    {
        bool[] resizeBoxesSelected;
        int boxSizes = 15;
        Point line1, line2;
        Brush brush;

        public ClassDiagram(int _x, int _y, int _width, int _height)
        {
            x = _x;
            y = _y;
            width = _width;
            height = _height;

            isSelected = false;
            resizeBoxes = new Rectangle[4];
            resizeBoxes[0] = new Rectangle(x - boxSizes, y - boxSizes, boxSizes, boxSizes);
            resizeBoxes[1] = new Rectangle(x - boxSizes, y + height, boxSizes, boxSizes);
            resizeBoxes[2] = new Rectangle(x + width, y - boxSizes, boxSizes, boxSizes);
            resizeBoxes[3] = new Rectangle(x + width, y + height, boxSizes, boxSizes);
            resizeBoxesSelected = new bool[4] { false, false, false, false };

            brush = new SolidBrush(Color.Black);
            title = "title";
            line1 = new Point(x, y + (height / 4));
            line2 = new Point(x + width, y + (height / 4));
        }

        public override void draw(Graphics graphics)
        {

            Rectangle rectangle = new Rectangle(x, y, width, height);
            graphics.DrawRectangle(Pens.Black, rectangle);
            if (isSelected)
            {
                foreach( Rectangle thing in resizeBoxes)
                {
                    graphics.DrawRectangle(Pens.Red, thing);
                }
            }
            recalculateLine();
            graphics.DrawLine(Pens.Black, line1, line2);
            graphics.DrawString(title, new Font("Arial", height / 7), brush, new Point(x + 5, y + 5));
        }

        public override void move(Graphics graphics, int deltaX, int deltaY)
        {
            x += deltaX;
            y += deltaY;
            for ( int x = 0; x < 4; x++ )
            {
                resizeBoxes[x].X += deltaX;
                resizeBoxes[x].Y += deltaY;
            }
        }

        public void recalculateLine()
        {
            line1.X = x;
            line1.Y = y + (height / 4);
            line2.X = x + width;
            line2.Y = y + (height / 4);
        }

        public override void resize(Graphics graphics, int mouseX, int mouseY, int deltaX, int deltaY, ref Rectangle Select)
        {
            if (deltaX >= -5 && deltaX <= 5 && deltaY >= -5 && deltaY <= 5)
            {
                if (resizeBoxesSelected[0] == true)
                {
                    x += deltaX;
                    width -= deltaX;
                    y += deltaY;
                    height -= deltaY;

                    Select.X += deltaX;
                    Select.Y += deltaY;
                    Select.Width -= deltaX;
                    Select.Height -= deltaY;

                    resizeBoxes[0].X += deltaX;
                    resizeBoxes[0].Y += deltaY;
                    resizeBoxes[1].X += deltaX;
                    resizeBoxes[2].Y += deltaY;
                }
                else if (resizeBoxesSelected[1] == true)
                {
                    x += deltaX;
                    width -= deltaX;
                    height += deltaY;

                    Select.X += deltaX;
                    Select.Width -= deltaX;
                    Select.Height += deltaY;

                    resizeBoxes[0].X += deltaX;
                    resizeBoxes[1].X += deltaX;
                    resizeBoxes[1].Y += deltaY;
                    resizeBoxes[3].Y += deltaY;
                }
                else if (resizeBoxesSelected[2] == true)
                {
                    y += deltaY;
                    width += deltaX;
                    height -= deltaY;

                    Select.Y += deltaY;
                    Select.Width += deltaX;
                    Select.Height -= deltaY;

                    resizeBoxes[0].Y += deltaY;
                    resizeBoxes[2].X += deltaX;
                    resizeBoxes[2].Y += deltaY;
                    resizeBoxes[3].X += deltaX;
                }
                else if (resizeBoxesSelected[3] == true)
                {
                    width += deltaX;
                    height += deltaY;

                    Select.Width += deltaX;
                    Select.Height += deltaY;

                    resizeBoxes[1].Y += deltaY;
                    resizeBoxes[2].X += deltaX;
                    resizeBoxes[3].Y += deltaY;
                    resizeBoxes[3].X += deltaX;
                }
            }
        }

        public override void testIfResizesBoxesSelected(int mouseX, int mouseY)
        {
            for ( int x = 0; x < 4; x++ )
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
    }
}
