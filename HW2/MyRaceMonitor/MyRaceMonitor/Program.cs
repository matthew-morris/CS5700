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

        private static readonly string[] Races = new string[]
        {
            "1-Century Simulation-01",
            "2-Short Race Simulation-01"
        };

        [STAThread]

        static void Main()
        {
            SimulatorController controller = new SimulatorController();

            /*
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CourseSetup());
            */
          
            Course myCourse = getCourse();
            
            myCourse.addRace(getRace());

            controller.Run($"../../../SimulationData/{myCourse.Races.ElementAt(0).Title}.csv");

            return;
        }

        private static Race getRace()
        {
            string title = null;
            while (title == null)
            {
                Console.WriteLine("Race Types: ");
                foreach (string thing in Races)
                    Console.WriteLine($"\t{thing.PadRight(10)}");
                Console.Write("Specify which race you would like to choose to simulate. ");
                string response = Console.ReadLine()?.Trim();

                foreach (string thing in Races)
                {
                    if (response == thing.Substring(2) || response == thing.ElementAt(0).ToString())
                    {
                        title = thing.Substring(2);
                        break;
                    }
                    else
                    {
                        title = null;
                    }
                }
            }
            Console.WriteLine();
            DateTime startTime;
            Console.WriteLine("Specify when you would like the race to start in DateTime format. ");
            Console.WriteLine("Example: 8/15/2017 6:00:00 AM");
            Console.WriteLine("If invalid date is entered, it will default to the current date");
            try
            {
                startTime = Convert.ToDateTime(Console.ReadLine());
            }
            catch
            {
                startTime = DateTime.Now;
            }

            return new Race(0, title, startTime);
        }
        private static Course getCourse()
        {
            Console.WriteLine("Specify the course name: ");
            string courseName = Console.ReadLine();
            int totalDistance = 0;
            while ( totalDistance <= 0)
            {
                Console.WriteLine("Specify the total distance (int): ");
                try
                {
                    totalDistance = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    totalDistance = 0;
                }
            }

            return new Course(0, courseName, totalDistance);

        }
    }
}
