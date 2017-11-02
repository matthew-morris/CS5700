using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer
{
    public class Dependency : Relationship
    {
        Point trianglePoint1, trianglePoint2;

        public Dependency(Point _startPoint, Point _endPoint, bool _isDotted) : base(_startPoint, _endPoint, _isDotted)
        {
            trianglePoint1 = new Point();
            trianglePoint2 = new Point();
            recalculateTriangle();
        }

        public override void draw(Graphics graphics)
        {
            recalculateTriangle();
            Point[] myPoints = {
                trianglePoint1,
                trianglePoint2,
                endPoint
            };
            graphics.DrawPolygon(Pens.Black, myPoints);
            base.draw(graphics);
        }

        public void recalculateTriangle()
        {
            //find slope
            double slope = -((double)startPoint.Y - (double)endPoint.Y) / ((double)startPoint.X - (double)endPoint.X);

            // find point on the line
            base.setTempPoint();

            //create other 2 points
            int size = 50;
            double invertSlope = 1 / (-slope);

            double dx, dy, dist;
            dx = tempPoint.X - startPoint.X;
            dy = tempPoint.Y - startPoint.Y;
            dist = Math.Sqrt(dx * dx + dy * dy);
            dx /= dist;
            dy /= dist;
            if (startPoint.X < endPoint.X && startPoint.Y > endPoint.Y)
            {
                trianglePoint1.X = (int)(double)(tempPoint.X + (size / 2) * dy);
                trianglePoint1.Y = (int)(double)(tempPoint.Y - (size / 2) * dx);
                trianglePoint2.X = (int)(double)(tempPoint.X - (size / 2) * dy);
                trianglePoint2.Y = (int)(double)(tempPoint.Y - (size / 2) * dy);
            }
            else if (startPoint.X > endPoint.X && startPoint.Y < endPoint.Y)
            {
                trianglePoint1.X = (int)(double)(tempPoint.X + (size / 2) * dy);
                trianglePoint1.Y = (int)(double)(tempPoint.Y - (size / 2) * dx);
                trianglePoint2.X = (int)(double)(tempPoint.X - (size / 2) * dy);
                trianglePoint2.Y = (int)(double)(tempPoint.Y - (size / 2) * dy);
            }
            else
            {
                trianglePoint1.X = (int)(double)(tempPoint.X + (size / 2) * dy);
                trianglePoint1.Y = (int)(double)(tempPoint.Y - (size / 2) * dx);
                trianglePoint2.X = (int)(double)(tempPoint.X - (size / 2) * dy);
                trianglePoint2.Y = (int)(double)(tempPoint.Y + (size / 2) * dy);
            }
        }
    }
}
