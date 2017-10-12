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
    public partial class ListObserver : Form, Observer
    {
        public List<Athlete> myAthletes;

        public ListObserver()
        {
            InitializeComponent();
            myAthletes = new List<Athlete>();
            dataGridView1.Columns.Add("Status", "Status");

            /*
            string[] row = new string[] { "1", "0" };
            dataGridView1.Rows.Add(row);
            dataGridView1.Rows.Add(row);
            */
        }

        public void Update(Athlete a)
        {
            bool add = true;
            foreach (Athlete thing in myAthletes)
            {
                if ( thing.BibNumber == a.BibNumber)
                {
                    foreach ( DataGridViewRow row in dataGridView1.Rows )
                    {
                        string temp = Convert.ToString(row.Cells["Athlete"].Value);
                        if ( temp == Convert.ToString(thing.BibNumber))
                        {
                            row.Cells["Location"].Value = Convert.ToString(Convert.ToInt32(thing.Location));
                            row.Cells["Status"].Value = Convert.ToString(thing.Status);
                            add = false;
                            break;
                        }
                    }
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
                this.BeginInvoke(new Action(() => dataGridView1.Rows.Add(Convert.ToString(a.BibNumber), Convert.ToString(a.Location), Convert.ToString(a.Status))));
            }
        }

        public void SortAthletes()
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
