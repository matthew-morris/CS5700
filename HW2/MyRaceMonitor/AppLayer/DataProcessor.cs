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
            AthleteRaceStatus update;
            string[] updateList = updateMessage.ToString().Split(',');

            if (updateMessage.GetType().ToString() == "RaceData.Messages.RegistrationUpdate")
            {
                update = new RegistrationUpdate(updateList[0], updateList[1], updateList[2], updateList[3], updateList[4], updateList[5], updateList[6]);
                update.Print();
            }
            else if (updateMessage.GetType().ToString() == "RaceData.Messages.DidNotStartUpdate")
            {
                update = new DidNotStartUpdate(updateList[0], updateList[1], updateList[2]);
                update.Print();
            }
            else if (updateMessage.GetType().ToString() == "RaceData.Messages.StartedUpdate")
            {
                update = new StartedUpdate(updateList[0], updateList[1], updateList[2], updateList[3]);
                update.Print();
            }
            else if (updateMessage.GetType().ToString() == "RaceData.Messages.LocationUpdate")
            {
                update = new LocationUpdate(updateList[0], updateList[1], updateList[2], updateList[3]);
                update.Print();
            }
            else if (updateMessage.GetType().ToString() == "RaceData.Messages.DidNotFinishUpdate")
            {
                update = new DidNotFinishUpdate(updateList[0], updateList[1], updateList[2]);
                update.Print();
            }
            else if (updateMessage.GetType().ToString() == "RaceData.Messages.FinishedUpdate")
            {
                update = new FinishedUpdate(updateList[0], updateList[1], updateList[2], updateList[3]);
                update.Print();
            }
        }
    }
}
