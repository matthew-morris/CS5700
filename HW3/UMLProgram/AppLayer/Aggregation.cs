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
        Point trianglePoint1, trianglePoint2;
        Point[] myPoints = new Point[2];

    public Aggregation(Point _startPoint, Point _endPoint) : base(_startPoint, _endPoint)
        {
            trianglePoint1 = new Point();
            trianglePoint2 = new Point();
            myPoints[0] = trianglePoint1;
            myPoints[1] = trianglePoint2;
            recalculateTriangle();
        }

        public void draw(Graphics graphics) 
        {
            base.draw(graphics);
            recalculateTriangle();
            graphics.DrawPolygon(Pens.Black, myPoints);
        }

        public void recalculateTriangle()
        {
            trianglePoint1.X = endPoint.X + 15;
            trianglePoint1.Y = endPoint.Y;
            trianglePoint2.X = endPoint.X - 15;
            trianglePoint2.Y = endPoint.Y;
        }
    }
}
