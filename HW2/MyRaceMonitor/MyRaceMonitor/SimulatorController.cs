
using System.Threading;
using RaceData;
using AppLayer;
using System.Collections.Generic;

namespace MyRaceMonitor
{
    public class SimulatorController
    {
        private SimulatedDataSource _simulatedData;
        public void Run(string inputFile, Race race, List<Observer> os)
        {
            IAthleteUpdateHandler handler = new DataProcessor(race, os);
            _simulatedData = new SimulatedDataSource()
            {
                InputFilename = inputFile,
                Handler = handler
            };

            _simulatedData.Start();
            
            Thread.Sleep(180000);

            _simulatedData.Stop();
        }
    }
}
