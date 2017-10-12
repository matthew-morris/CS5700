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
        private Random rnd;
        public List<Color> myColors;
        Graphics g;
        Pen p;

        public _1DLineObserver()
        {
            InitializeComponent();
        }

        private void _1DLineObserver_Load(object sender, EventArgs e)
        {
            myAthletes = new List<Athlete>();
            myColors = new List<Color>();

            g = this.CreateGraphics();
            rnd = new Random();
            p = new Pen(Brushes.Black, 2);
        }

        public void Update(Athlete a)
        {
            /*
            bool add = true;
            foreach (Athlete thing in myAthletes)
            {
                if (thing.BibNumber == a.BibNumber)
                {

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
                Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                myColors.Add(randomColor);
                this.BeginInvoke(new Action(() => g.DrawEllipse(new Pen(myColors.ElementAt(myAthletes.Count-1),2), new Rectangle(myAthletes.Count*100, 100, 100, 100))));
            }
            */
        }
    }
}
