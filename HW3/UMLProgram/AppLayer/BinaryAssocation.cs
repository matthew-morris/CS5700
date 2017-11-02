using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer
{
    public class BinaryAssocation : Relationship
    {
        public BinaryAssocation(Point _startPoint, Point _endPoint, bool _isDotted) : base(_startPoint, _endPoint, _isDotted)
        {
        }

        public override void draw(Graphics graphics)
        {
            recalculateTriangle();
            graphics.DrawLine(Pens.Black, tempPoint, endPoint);
            base.draw(graphics);
        }

        public void recalculateTriangle()
        {
            // find point on the line
            base.setTempPoint();
        }
    }
}
