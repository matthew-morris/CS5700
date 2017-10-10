
using System.Threading;
using RaceData;
using AppLayer;

namespace MyRaceMonitor
{
    public class SimulatorController
    {
        private SimulatedDataSource _simulatedData;
        public void Run(string inputFile, Race race)
        {
            IAthleteUpdateHandler handler = new DataProcessor(race);
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
