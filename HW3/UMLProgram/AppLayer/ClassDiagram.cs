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
        public ClassDiagram(int _x, int _y, int _width, int _height)
        {
            x = _x;
            y = _y;
            width = _width;
            height = _height;
        }

        public override void draw(Graphics graphics)
        {
            Rectangle rectangle = new Rectangle(x, y, width, height);
            graphics.DrawRectangle(Pens.Black, rectangle);
        }

        public override void move(Graphics graphics)
        {
            
        }
    }
}
