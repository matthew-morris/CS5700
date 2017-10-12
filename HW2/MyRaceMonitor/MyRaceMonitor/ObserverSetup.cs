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
    public partial class ObserverSetup : Form
    {
        public Course myCourse;
        public SimulatorController controller;
        public List<Observer> observersToAdd;

        public ObserverSetup(Course c, SimulatorController contr)
        {
            InitializeComponent();
            myCourse = c;
            controller = contr;
            checkedListBox1.Items.Add("Report to console");
            checkedListBox1.Items.Add("Report athletes in list");
            checkedListBox1.Items.Add("Report athletes on a 1D line");
            observersToAdd = new List<Observer>();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> checkedItems = new List<string>();
            foreach (object Item in checkedListBox1.CheckedItems)
            {
                checkedItems.Add(Item.ToString());
            }
            foreach(string Item in checkedItems)
            {
                if (Item == "Report to console")
                {
                    observersToAdd.Add(new ConsoleObserver());
                }
                else if (Item == "Report athletes in list")
                {
                    ListObserver myLO = new ListObserver();
                    observersToAdd.Add(myLO);
                    Thread myThread = new Thread(() => Application.Run(myLO));
                    myThread.Start();
                }
                else if (Item == "Report athletes on a 1D line")
                {
                    _1DLineObserver my1D = new _1DLineObserver();
                    observersToAdd.Add(my1D);
                   
                    Thread myThread = new Thread(() => Application.Run(my1D));
                    myThread.Start();
                }
            }
            controller.Run($"../../../SimulationData/{myCourse.Races.ElementAt(0).Title}.csv", myCourse.Races[0], observersToAdd);
        }

        private void ObserverSetup_Load(object sender, EventArgs e)
        {

        }
    }
}
