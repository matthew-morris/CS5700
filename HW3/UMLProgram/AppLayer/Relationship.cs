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
        public ClassDiagram class1, class2;
        public Point startPoint, endPoint;

        public Relationship(Point _startPoint, Point _endPoint)
        {
            startPoint = _startPoint;
            endPoint = _endPoint;

            x = startPoint.X;
            y = startPoint.Y;
            width = endPoint.X - startPoint.X;
            height = endPoint.Y - startPoint.Y;

            isSelected = false;
            resizeBoxes = new Rectangle[2];
            resizeBoxes[0] = new Rectangle(startPoint.X - 5, startPoint.Y - 5, 5, 5);
            resizeBoxes[1] = new Rectangle(endPoint.X, endPoint.Y, 5, 5);
        }
    }
}
