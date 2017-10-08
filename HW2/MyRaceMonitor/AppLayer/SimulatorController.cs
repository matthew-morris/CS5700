
using System.Threading;
using RaceData;

namespace AppLayer
{
    public class SimulatorController
    {
        private SimulatedDataSource _simulatedData;
        public void Run(string inputFile)
        {
            IAthleteUpdateHandler handler = new DataProcessor();
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
