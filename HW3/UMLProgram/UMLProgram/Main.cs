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
        AppLayer.Relationship isSelectedRel;
        Rectangle isSelectedRec;
        Pen SelectedRecPen;

        public List<Command> myCommands;

        private List<AppLayer.Object> myObjects;

        public Main()
        {
            InitializeComponent();
            myObjects = new List<AppLayer.Object>();
            graphics = this.CreateGraphics();
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            SelectedRecPen = new Pen(Color.Black);
            SelectedRecPen.Width = 1.0F;
            SelectedRecPen.DashCap = System.Drawing.Drawing2D.DashCap.Round;
            SelectedRecPen.DashPattern = new float[] { 2.0F, 1.0F };
            myCommands = new List<Command>();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //myObjects.Add(new ClassDiagram(this.Width / 2, this.Height / 2, this.Width / 8, this.Height / 8));
            myCommands.Add(new CreateObjectCommand(new ClassDiagram(this.Width / 2, this.Height / 2, this.Width / 8, this.Height / 8), ref myObjects));
            myCommands[myCommands.Count - 1].execute();
            drawObjects();
            richTextBox1.Text += "Created Class Diagram\n";
        }

        private void drawObjects()
        {
            graphics.Clear(this.BackColor);

            foreach (AppLayer.Object thing in myObjects)
            {
                thing.draw(this.graphics);
            }
            graphics.DrawRectangle(SelectedRecPen, isSelectedRec);
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            var relativePoint = this.PointToClient(Cursor.Position);
            mouseX = relativePoint.X;
            mouseY = relativePoint.Y;

            // checks to see if click happened on an object
            foreach (AppLayer.Object thing in myObjects)
            {
                if (mouseX >= thing.x && mouseX <= (thing.x + thing.width))
                {
                    if (mouseY >= thing.y && mouseY <= (thing.y + thing.height))
                    {
                        isSelected = thing;
                        isSelected.isSelected = true;
                        if (isSelected is Relationship)
                        {
                            isSelectedRel = (Relationship)thing;
                            isSelectedRel.isSelected = true;
                        }
                        break;
                    }
                    else
                    {
                        if (isSelected != null)
                        {
                            isSelected.isSelected = false;
                            isSelected = null;
                        }
                    }
                }
                else
                {
                    if (isSelected != null)
                    {
                        isSelected.isSelected = false;
                        isSelected = null;
                    }
                }
            }

            // checks if click happened on resize boxes
            

            setIsSelectedRec();
            drawObjects();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            mousePressed = true;
            if (isSelected != null)
            {
                isSelected.testIfResizesBoxesSelected(e.X, e.Y);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            myCommands.Add(new CreateObjectCommand(new Generalization(new Point(this.Width / 2, this.Height / 2), new Point(this.Width * 3 / 4, this.Height * 3 / 4), false), ref myObjects));
            myCommands[myCommands.Count - 1].execute();
            drawObjects();
            richTextBox1.Text += "Created Generalization\n";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            myCommands.Add(new CreateObjectCommand(new Dependency(new Point(this.Width / 2, this.Height / 2), new Point(this.Width * 3 / 4, this.Height * 3 / 4), true), ref myObjects));
            myCommands[myCommands.Count - 1].execute();
            //myObjects.Add(new Dependency(new Point(this.Width / 2, this.Height / 2), new Point(this.Width * 3 / 4, this.Height * 3 / 4), true));
            drawObjects();
            richTextBox1.Text += "Created Dependency\n"; 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            myCommands.Add(new CreateObjectCommand(new BinaryAssocation(new Point(this.Width / 2, this.Height / 2), new Point(this.Width * 3 / 4, this.Height * 3 / 4), false), ref myObjects));
            myCommands[myCommands.Count - 1].execute();
            //myObjects.Add(new BinaryAssocation(new Point(this.Width / 2, this.Height / 2), new Point(this.Width * 3 / 4, this.Height * 3 / 4), false));
            drawObjects();
            richTextBox1.Text += "Created Binary Assocation\n";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            myCommands.Add(new CreateObjectCommand(new Aggregation(new Point(this.Width / 2, this.Height / 2), new Point(this.Width * 3 / 4, this.Height * 3 / 4), false), ref myObjects));
            myCommands[myCommands.Count - 1].execute();
            //myObjects.Add(new Aggregation(new Point(this.Width / 2, this.Height / 2), new Point(this.Width * 3 / 4, this.Height * 3 / 4), false));
            drawObjects();
            richTextBox1.Text += "Created Aggregation\n";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            myCommands.Add(new CreateObjectCommand(new Composition(new Point(this.Width / 2, this.Height / 2), new Point(this.Width * 3 / 4, this.Height * 3 / 4), false), ref myObjects));
            myCommands[myCommands.Count - 1].execute();
            //myObjects.Add(new Composition(new Point(this.Width / 2, this.Height / 2), new Point(this.Width * 3 / 4, this.Height * 3 / 4), false));
            drawObjects();
            richTextBox1.Text += "Created Composition\n";
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (mousePressed)
            {
                deltaMouseX = e.X - mouseX;
                deltaMouseY = e.Y - mouseY;
                mouseX = e.X;
                mouseY = e.Y;
                if (isSelected != null)
                {
                    if (mouseX >= isSelected.x && mouseX <= isSelected.x + isSelected.width)
                    {
                        if (mouseY >= isSelected.y && mouseY <= isSelected.y + isSelected.height)
                        {
                            isSelectedRec.X += deltaMouseX;
                            isSelectedRec.Y += deltaMouseY;

                            isSelected.move(graphics, deltaMouseX, deltaMouseY);
                        }
                    }
                    else
                    {
                        if (isSelected != null)
                        {
                            isSelected.resize(graphics, mouseX, mouseY, deltaMouseX, deltaMouseY, ref isSelectedRec);
                        }
                    }

                    drawObjects();
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            deleteObject();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            Console.WriteLine(e.KeyCode);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            mousePressed = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (myCommands.Count >= 0)
            {
                myCommands[myCommands.Count - 1].undo();
                richTextBox1.Text += "Undo Last Command\n";
                drawObjects();
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            foreach (AppLayer.Object thing in myObjects)
            {
                if (thing is ClassDiagram)
                {
                    if ( e.X >= thing.x && e.X <= thing.x+thing.width)
                    {
                        if (e.Y >= thing.y && e.Y <= thing.y + thing.height)
                        {
                            thing.title = Prompt.ShowDialog("Enter title", "Class Title");
                        }
                    }
                }
            }
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

        public void deleteObject()
        {
            if (isSelected != null)
            {
                myCommands.Add(new DeleteObjectCommand(isSelected, ref myObjects));
                myCommands[myCommands.Count - 1].execute();
                isSelectedRec.Width = 0;
                isSelectedRec.Height = 0;
            }
            drawObjects();
            richTextBox1.Text += "Deleted Object\n";
        }
    }
    // this prompt class was taken from https://stackoverflow.com/questions/5427020/prompt-dialog-in-windows-forms
    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}

