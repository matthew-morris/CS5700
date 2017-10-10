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
    public partial class RaceSetup : Form
    {
        public Course myC;
        public Race myR;

        public RaceSetup(Course c)
        {
            InitializeComponent();
            comboBox1.Items.Add("Century Simulation-01");
            comboBox1.Items.Add("Short Race Simulation-01");
            myC = c;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text != "")
            {
                try
                {
                    DateTime temp = Convert.ToDateTime(textBox1.Text);
                    myC.addRace(new Race(myC.Races.Count, comboBox1.Text, temp));
                    this.Hide();
                }
                catch
                {
                    label4.Text = "Invalid Date Entry";
                }
            }
            else
            {
                label4.Text = "Please select a race";
            }
        }
    }
}
