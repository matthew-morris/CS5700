using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RaceData;
using RaceData.Messages;

namespace AppLayer
{
    public class DataProcessor : IAthleteUpdateHandler
    {
        public void ProcessUpdate(AthleteUpdate updateMessage)
        {
            AthleteRaceStatus temp = new AthleteRaceStatus(updateMessage.UpdateType, updateMessage.BibNumber, updateMessage.Timestamp);
           // temp.printAthleteRaceStatus();

            Console.WriteLine(updateMessage.ToString());
        }
    }
}
