using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using PersonMatcher;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTestMother
    {
        [TestMethod]
        public void TestMethodSimpleData()
        {
            Person p1 = new Person() { MotherFirstName = "Cheryl", MotherMiddleName = "Angela", MotherLastName = "Morris", BirthDay = 26, BirthMonth = 4, BirthYear = 1993 };
            Person p2 = new Person() { MotherFirstName = "Cheryl", MotherMiddleName = "Angela", MotherLastName = "Morris", BirthDay = 26, BirthMonth = 4, BirthYear = 1993 };

            Algorithm_MotherTest myTest = new Algorithm_MotherTest();

            bool expected = true;
            bool actual = myTest.MatchTest(p1, p2);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethodNullData()
        {
            Person p1 = new Person() { MotherFirstName = "Cheryl", MotherMiddleName = "Angela", MotherLastName = "Morris", BirthDay = 26, BirthMonth = 4, BirthYear = 1993 };
            Person p2 = new Person() { MotherFirstName = "Cheryl", MotherMiddleName = null, MotherLastName = "Morris", BirthDay = 26, BirthMonth = 4, BirthYear = 1993 };

            Algorithm_MotherTest myTest = new Algorithm_MotherTest();

            bool expected = false;
            bool actual = myTest.MatchTest(p1, p2);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethodAllNull()
        {
            Person p1 = new Person() { MotherFirstName = null, MotherMiddleName = null, MotherLastName = null};
            Person p2 = new Person() { MotherFirstName = "Cheryl", MotherMiddleName = "Angela", MotherLastName = "Morris", BirthDay = 26, BirthMonth = 4, BirthYear = 1993 };

            Algorithm_MotherTest myTest = new Algorithm_MotherTest();

            bool expected = false;
            bool actual = myTest.MatchTest(p1, p2);

            Assert.AreEqual(expected, actual);
        }
    }
}
