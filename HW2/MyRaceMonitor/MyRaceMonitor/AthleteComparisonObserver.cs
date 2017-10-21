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
                this.BeginInvoke(new Action(() => listView1.Items.Add("Athlete " + a.BibNumber)));
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> mystrings = new List<string>();
            mystrings.Add("");
            mystrings.Add("");
            if (listView1.SelectedItems.Count >= 3 )
            {
                listView1.SelectedItems[0].Selected = false;
            }
            else {
                int x = 0;
                foreach ( ListViewItem thing in listView1.Items)
                {
                    if(thing.Selected == true)
                    {
                        mystrings[x] = thing.ToString().Substring(23);
                        if (mystrings[x].Last() == '}')
                        {
                            mystrings[x] = mystrings[x].Substring(0, mystrings[x].Length - 1);
                        }
                        x++;
                    }
                }
            }
            int distance1 = 0, distance2 = 0;
            foreach (Athlete thing in myAthletes)
            {
                if (mystrings[0] != "" && thing.BibNumber == Convert.ToInt32(mystrings[0]))
                {
                    textBox1.Text = "Athlete: " + thing.FirstName + " Number: " + thing.BibNumber + " Location: " + Convert.ToInt32(thing.Location);
                    distance1 = Convert.ToInt32(thing.Location);
                }
                else if (mystrings[1] != "" && thing.BibNumber == Convert.ToInt32(mystrings[1]))
                {
                    textBox2.Text = "Athlete: " + thing.FirstName + " Number: " + thing.BibNumber + " Location: " + Convert.ToInt32(thing.Location);
                    distance2 = Convert.ToInt32(thing.Location);
                }
            }
            label2.Text = "Distance between athletes: " + (distance1 - distance2);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void AthleteComparisonObserver_Load(object sender, EventArgs e)
        {

        }
    }
}
