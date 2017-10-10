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
        public Race myRace;

        public DataProcessor(Race r)
        {
            myRace = r;
        }

        public void ProcessUpdate(AthleteUpdate updateMessage)
        {
            string[] updateList = updateMessage.ToString().Split(',');

            if (updateMessage.GetType().ToString() == "RaceData.Messages.RegistrationUpdate")
            {
                AppLayer.RegistrationUpdate update = new AppLayer.RegistrationUpdate(updateList[0], updateList[1], updateList[2], updateList[3], updateList[4], updateList[5], updateList[6]);
                myRace.Athletes.Add(new Athlete(update.Status, update.BibNumber, update.FirstName, update.LastName, update.Gender, update.Age));

                foreach (Athlete thing in myRace.Athletes)
                {
                    if (thing.BibNumber == update.BibNumber)
                    {
                        thing.RegisterObserver(new ConsoleObserver());
                        thing.NotifyObservers();
                        break;
                    }
                }
            }
            else if (updateMessage.GetType().ToString() == "RaceData.Messages.DidNotStartUpdate")
            {
                AppLayer.DidNotStartUpdate update = new AppLayer.DidNotStartUpdate(updateList[0], updateList[1], updateList[2]);
                foreach (Athlete thing in myRace.Athletes)
                {
                    if (thing.BibNumber == update.BibNumber)
                    {
                        thing.Status = RaceData.AthleteRaceStatus.DidNotStart;

                        thing.NotifyObservers();
                        break;
                    }
                }
            }
            else if (updateMessage.GetType().ToString() == "RaceData.Messages.StartedUpdate")
            {
                AppLayer.StartedUpdate update = new AppLayer.StartedUpdate(updateList[0], updateList[1], updateList[2], updateList[3]);
                foreach (Athlete thing in myRace.Athletes)
                {
                    if (thing.BibNumber == update.BibNumber)
                    {
                        thing.Status = RaceData.AthleteRaceStatus.Started;
                        thing.startTime = update.OfficialStartTime;

                        thing.NotifyObservers();
                        break;
                    }
                }
            }
            else if (updateMessage.GetType().ToString() == "RaceData.Messages.LocationUpdate")
            {
                AppLayer.LocationUpdate update = new AppLayer.LocationUpdate(updateList[0], updateList[1], updateList[2], updateList[3]);
                foreach (Athlete thing in myRace.Athletes)
                {
                    if (thing.BibNumber == update.BibNumber)
                    {
                        thing.Status = RaceData.AthleteRaceStatus.OnCourse;
                        thing.Location = update.Location;

                        thing.NotifyObservers();
                        break;
                    }
                }
            }
            else if (updateMessage.GetType().ToString() == "RaceData.Messages.DidNotFinishUpdate")
            {
                AppLayer.DidNotFinishUpdate update = new AppLayer.DidNotFinishUpdate(updateList[0], updateList[1], updateList[2]);
                foreach (Athlete thing in myRace.Athletes)
                {
                    if (thing.BibNumber == update.BibNumber)
                    {
                        thing.Status = RaceData.AthleteRaceStatus.DidNotFinish;

                        thing.NotifyObservers();
                        break;
                    }
                }
            }
            else if (updateMessage.GetType().ToString() == "RaceData.Messages.FinishedUpdate")
            {
                AppLayer.FinishedUpdate update = new AppLayer.FinishedUpdate(updateList[0], updateList[1], updateList[2], updateList[3]);
                foreach (Athlete thing in myRace.Athletes)
                {
                    if (thing.BibNumber == update.BibNumber)
                    {
                        thing.Status = RaceData.AthleteRaceStatus.Finished;
                        thing.finishTime = update.OfficialEndTime;

                        thing.NotifyObservers();
                        break;
                    }
                }
            }
        }
    }
}
