using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer
{
    public abstract class Object
    {
        public int x, y, width, height;
        public bool isSelected;
        public string title;
        public Rectangle[] resizeBoxes;

        public abstract void draw(Graphics graphics);
        public abstract void move(Graphics graphics, int deltaX, int deltaY);
        public abstract void resize(Graphics graphics, int mouseX, int mouseY, int deltaX, int deltaY, ref Rectangle Select);
        public abstract void testIfResizesBoxesSelected(int mouseX, int mouseY);
    }
}
