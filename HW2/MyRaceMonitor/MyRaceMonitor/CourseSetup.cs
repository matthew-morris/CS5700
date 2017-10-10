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
    public partial class CourseSetup : Form
    {
        public Course myC;

        public CourseSetup(Course c)
        {
            InitializeComponent();
            myC = c;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            myC.Name = textBox1.Text;
            try
            {
                myC.TotalDistance = Convert.ToDouble(textBox2.Text);
                this.Hide();
            }
            catch
            {
                label3.Text = "Invalid Distance";
            }
        }
    }
}
