using AppLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UMLProgram
{
    public partial class Main : Form
    {
        Graphics graphics;
        private int mouseX, mouseY, deltaMouseX, deltaMouseY;
        bool mousePressed;
        AppLayer.Object isSelected;
        Rectangle isSelectedRec;

        private List<AppLayer.Object> myObjects;

        public Main()
        {
            InitializeComponent();
            myObjects = new List<AppLayer.Object>();
            graphics = this.CreateGraphics();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            myObjects.Add(new ClassDiagram(this.Width / 2, this.Height / 2, this.Width / 8, this.Height / 8));
            drawObjects();
        }

        private void drawObjects()
        {
            graphics.Clear(this.BackColor);

            foreach (AppLayer.Object thing in myObjects)
            {
                thing.draw(this.graphics);
            }
            graphics.DrawRectangle(Pens.Black, isSelectedRec);
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            var relativePoint = this.PointToClient(Cursor.Position);
            mouseX = relativePoint.X;
            mouseY = relativePoint.Y;

            foreach (AppLayer.Object thing in myObjects)
            {
                if (mouseX >= thing.x && mouseX <= (thing.x + thing.width))
                {
                    if (mouseY >= thing.y && mouseY <= (thing.y + thing.height))
                    {
                        isSelected = thing;
                        break;
                    }
                    else
                    {
                        isSelected = null;
                    }
                }
                else
                {
                    isSelected = null;
                }
            }

            setIsSelectedRec();
            drawObjects();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            mousePressed = true;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if(mousePressed)
            {
                deltaMouseX = e.X - mouseX;
                deltaMouseY = e.Y - mouseY;
                mouseX = e.X;
                mouseY = e.Y;

                if (isSelected != null)
                {
                    isSelectedRec.X += deltaMouseX;
                    isSelectedRec.Y += deltaMouseY;
                    isSelected.x += deltaMouseX;
                    isSelected.y += deltaMouseY;
                }

                Console.WriteLine(deltaMouseX + " " + deltaMouseY);

                drawObjects();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            mousePressed = false;
        }

        public void setIsSelectedRec()
        {
            if (isSelected != null)
            {
                isSelectedRec = new Rectangle(isSelected.x - 10, isSelected.y - 10, isSelected.width + 20, isSelected.height + 20);
            }
            else
            {
                isSelectedRec.Width = 0;
                isSelectedRec.Height = 0;
                isSelectedRec.X = 0;
                isSelectedRec.Y = 0;
            }
        }
    }
}
