using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AppLayer;

namespace MyRaceMonitor
{
    public partial class MainForm : Form
    {
        public List<Course> myCourses;
        private Course currentCourse;
        private CourseSetup CourseForm;
        private RaceSetup RaceForm;
        private SimulatorController controller;

        public MainForm()
        {
            InitializeComponent();
            myCourses = new List<Course>();
            currentCourse = new Course();
            currentCourse.addRace(new Race(0, "Short Race Simulation-01", DateTime.Now));
            CourseForm = new CourseSetup(currentCourse);
            RaceForm = new RaceSetup(currentCourse);
            controller = new SimulatorController();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CourseForm.Show();
            listBox1.Items.Add(currentCourse);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RaceForm.Show();
            listBox2.Items.Add(currentCourse.Races.ElementAt(0));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            controller.Run($"../../../SimulationData/{currentCourse.Races.ElementAt(0).Title}.csv", currentCourse.Races[0]);

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
