using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RaceData;
using RaceData.Messages;

using AppLayer;

namespace MyRaceMonitor
{
    public class DataProcessor : IAthleteUpdateHandler
    {
        public void ProcessUpdate(AthleteUpdate updateMessage)
        {
            AppLayer.AthleteRaceStatus update;
            string[] updateList = updateMessage.ToString().Split(',');

            if (updateMessage.GetType().ToString() == "RaceData.Messages.RegistrationUpdate")
            {
                update = new AppLayer.RegistrationUpdate(updateList[0], updateList[1], updateList[2], updateList[3], updateList[4], updateList[5], updateList[6]);
                update.Print();
            }
            else if (updateMessage.GetType().ToString() == "RaceData.Messages.DidNotStartUpdate")
            {
                update = new AppLayer.DidNotStartUpdate(updateList[0], updateList[1], updateList[2]);
                update.Print();
            }
            else if (updateMessage.GetType().ToString() == "RaceData.Messages.StartedUpdate")
            {
                update = new AppLayer.StartedUpdate(updateList[0], updateList[1], updateList[2], updateList[3]);
                update.Print();
            }
            else if (updateMessage.GetType().ToString() == "RaceData.Messages.LocationUpdate")
            {
                update = new AppLayer.LocationUpdate(updateList[0], updateList[1], updateList[2], updateList[3]);
                update.Print();
            }
            else if (updateMessage.GetType().ToString() == "RaceData.Messages.DidNotFinishUpdate")
            {
                update = new AppLayer.DidNotFinishUpdate(updateList[0], updateList[1], updateList[2]);
                update.Print();
            }
            else if (updateMessage.GetType().ToString() == "RaceData.Messages.FinishedUpdate")
            {
                update = new AppLayer.FinishedUpdate(updateList[0], updateList[1], updateList[2], updateList[3]);
                update.Print();
            }
        }
    }
}
