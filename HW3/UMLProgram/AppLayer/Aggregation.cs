using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer
{
    public class Aggregation : Relationship
    {
        public Aggregation(Point _startPoint, Point _endPoint) : base(_startPoint, _endPoint)
        {
        }

        public override void draw(Graphics graphics)
        {
            graphics.DrawLine(Pens.Black, startPoint, endPoint);
            if (isSelected)
            {
                foreach (Rectangle thing in resizeBoxes)
                {
                    graphics.DrawRectangle(Pens.Red, thing);
                }
            }
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
            
        }

        public override void testIfResizesBoxesSelected(int mouseX, int mouseY)
        {
            
        }
    }
}
