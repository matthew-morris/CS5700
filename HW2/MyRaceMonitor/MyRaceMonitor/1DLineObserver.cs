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

namespace MyRaceMonitor
{
    public partial class _1DLineObserver : Form, Observer
    {
        public List<Athlete> myAthletes;
        private Graphics g;
        private struct drawAthlete
        {
            public int bib;
            public Pen p;
            public Rectangle rec;
        }
        private List<drawAthlete> drawAthletes;
        private Random rnd = new Random();

        public _1DLineObserver()
        {
            InitializeComponent();
            myAthletes = new List<Athlete>();
            drawAthletes = new List<drawAthlete>();
        }

        private void _1DLineObserver_Load(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            g.Clear(Color.White);
        }

        public void Update(Athlete a)
        {
            bool add = true;
            foreach (Athlete thing in myAthletes)
            {
                if (thing.BibNumber == a.BibNumber)
                {
                    add = false;
                    if (!add)
                    {
                        break;
                    }
                }
                else
                {
                    add = true;
                }
            }
            if (add)
            {
                myAthletes.Add(a);
                drawAthlete temp = new drawAthlete();
                Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                temp.p = new Pen(randomColor, 2);
                temp.bib = a.BibNumber;
                temp.rec = new Rectangle(myAthletes.Count * 20 + myAthletes.Count * 20, 10, 20, 20);
                drawAthletes.Add(temp);
            }

            draw();
        }

        private void draw()
        {
            g = this.CreateGraphics();
            g.Clear(Color.White);
            foreach(drawAthlete thing in drawAthletes)
            {
                g.FillEllipse(new SolidBrush(thing.p.Color), thing.rec);
                g.DrawString(Convert.ToString(thing.bib), new Font(FontFamily.GenericSansSerif, 12.0F, FontStyle.Bold), new SolidBrush(Color.Black), new Point(thing.rec.X, thing.rec.Y + 30));
            }
            g.DrawLine(new Pen(Color.Black), new Point(20, 100), new Point(20, 200));
            g.DrawLine(new Pen(Color.Black), new Point(500, 100), new Point(500, 200));
            g.DrawLine(new Pen(Color.Black), new Point(20, 150), new Point(500, 150));

            foreach (Athlete thing in myAthletes)
            {
                drawAthlete temp = new drawAthlete();
                for ( int x = 0; x < drawAthletes.Count; x++)
                {
                    if (thing.BibNumber == drawAthletes[x].bib)
                    {
                        temp = drawAthletes[x];
                        break;
                    }
                }
                g.FillEllipse(new SolidBrush(temp.p.Color), new Rectangle(scaleNumber(Convert.ToInt32(thing.Location), 500, 16400), 150-20, 40, 40));
            }
        }

        private int scaleNumber(int x, int scaledMax, int max)
        {
            double scale = Convert.ToDouble(scaledMax) / (max);
            return Convert.ToInt32(0 + ((x) * scale));
        }
    }
}
