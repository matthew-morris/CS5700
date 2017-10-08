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
            "Century Simulation-01",
            "Short Race Simulation-01"
        };

        [STAThread]

        static void Main()
        {
            SimulatorController controller = new SimulatorController();
            string myRace = getRace();
            controller.Run($"../../../SimulationData/{myRace}.csv");
        }

        private static string getRace()
        {
            string result = null;
            while (result == null)
            {
                Console.WriteLine("Race Types: ");
                foreach (string thing in Races)
                    Console.WriteLine($"\t{thing.PadRight(10)}");
                Console.Write("Specify which race you would like to choose to simulate. ");
                string response = Console.ReadLine()?.Trim();

                foreach (string thing in Races)
                {
                    if (response == thing)
                    {
                        result = thing;
                        break;
                    }
                    else
                    {
                        result = null;
                    }
                }
            }
            Console.WriteLine();

            return result;
        }
    }
}
