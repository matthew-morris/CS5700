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
    public partial class ListObserver : Form, Observer
    {
        public List<Athlete> myAthletes;

        public ListObserver()
        {
            InitializeComponent();
            this.Hide();
            myAthletes = new List<Athlete>();

            string[] row = new string[] { "1", "0" };
            dataGridView1.Rows.Add(row);
            dataGridView1.Rows.Add(row);
        }

        public void Update(Athlete a)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
