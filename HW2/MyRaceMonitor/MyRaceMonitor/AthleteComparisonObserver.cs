using AppLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyRaceMonitor
{
    public partial class AthleteComparisonObserver : Form, Observer
    {
        public List<Athlete> myAthletes;

        public AthleteComparisonObserver()
        {
            InitializeComponent();
            myAthletes = new List<Athlete>();
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
                //this.BeginInvoke(new Action(() => listView1.Items.Add("Athlete " + a.BibNumber)));
                listView1.Items.Add("Athlete " + a.BibNumber);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count >= 3 )
            {
                listView1.SelectedItems[0].Selected = false;
            }
        }
    }
}
