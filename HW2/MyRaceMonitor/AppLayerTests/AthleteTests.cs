using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RaceData;
using MyRaceMonitor;

namespace AppLayer.Tests
{
    [TestClass()]
    public class AthleteTests
    {
        [TestMethod()]
        public void NULLNotifyObserversTest()
        {
            RegistrationUpdate regUpdate = new RegistrationUpdate("Registered", "3", "10/13/2017 10:00:00 PM", "Matt", "Morris", "M", "24");
            Athlete athlete1 = new Athlete(regUpdate.Status, regUpdate.BibNumber, regUpdate.Timestamp.ToString(), regUpdate.LastName, regUpdate.Gender, regUpdate.Age);

            //try to notify observers when there are none
            try
            {
                athlete1.NotifyObservers();
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void RegisterObserverTest()
        {
            RegistrationUpdate regUpdate = new RegistrationUpdate("Registered", "3", "10/13/2017 10:00:00 PM", "Matt", "Morris", "M", "24");
            Athlete athlete1 = new Athlete(regUpdate.Status, regUpdate.BibNumber, regUpdate.Timestamp.ToString(), regUpdate.LastName, regUpdate.Gender, regUpdate.Age);

            //try to register the same observer twice
            try
            {
                athlete1.RegisterObserver(new ConsoleObserver());
                athlete1.RegisterObserver(new ConsoleObserver());
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void NULLRemoveObserverTest()
        {
            RegistrationUpdate regUpdate = new RegistrationUpdate("Registered", "3", "10/13/2017 10:00:00 PM", "Matt", "Morris", "M", "24");
            Athlete athlete1 = new Athlete(regUpdate.Status, regUpdate.BibNumber, regUpdate.Timestamp.ToString(), regUpdate.LastName, regUpdate.Gender, regUpdate.Age);

            // try to remove an observer if there are none
            try
            {
                athlete1.RemoveObserver(new ConsoleObserver());
            }
            catch {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void RemoveObserverTest()
        {
            RegistrationUpdate regUpdate = new RegistrationUpdate("Registered", "3", "10/13/2017 10:00:00 PM", "Matt", "Morris", "M", "24");
            Athlete athlete1 = new Athlete(regUpdate.Status, regUpdate.BibNumber, regUpdate.Timestamp.ToString(), regUpdate.LastName, regUpdate.Gender, regUpdate.Age);

            ConsoleObserver consoleobserver = new ConsoleObserver();
            _1DLineObserver onedobserver = new _1DLineObserver();
            AthleteComparisonObserver athletecompobserver = new AthleteComparisonObserver();
            ListObserver listobserver = new ListObserver();

            athlete1.RegisterObserver(consoleobserver);
            athlete1.RegisterObserver(onedobserver);
            athlete1.RegisterObserver(athletecompobserver);
            athlete1.RegisterObserver(listobserver);

            // test to see if observers are successfully removed
            try
            {
                athlete1.RemoveObserver(consoleobserver);
                athlete1.RemoveObserver(onedobserver);
                athlete1.RemoveObserver(athletecompobserver);
                athlete1.RemoveObserver(listobserver);
            }
            catch
            {
                Assert.Fail();
            }
        }
    }
}