using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppLayer;

namespace MyRaceMonitor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        [STAThread]

        static void Main()
        {
            SimulatorController controller = new SimulatorController();
            Course myCourse = new Course();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CourseSetup(myCourse));
            Application.Run(new RaceSetup(myCourse));
            Application.Run(new ObserverSetup(myCourse, controller));

            return;
        }
    }
}
