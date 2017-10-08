using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using PersonMatcher;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTestIdentifiers
    {
        [TestMethod]
        public void TestMethodSimpleData()
        {
            Person p1 = new Person() {SocialSecurityNumber = "7-1", StateFileNumber = "7", NewbornScreeningNumber = "11" };
            Person p2 = new Person() { SocialSecurityNumber = "7-1", StateFileNumber = "7", NewbornScreeningNumber = "11" };

            Algorithm_Identifiers myTest = new Algorithm_Identifiers();

            bool expected = true;
            bool actual = myTest.MatchTest(p1, p2);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethodNullData()
        {
            Person p1 = new Person() { SocialSecurityNumber = null, StateFileNumber = "7", NewbornScreeningNumber = "11" };
            Person p2 = new Person() { SocialSecurityNumber = "7-1", StateFileNumber = "7", NewbornScreeningNumber = "11" };

            Algorithm_Identifiers myTest = new Algorithm_Identifiers();

            bool expected = false;
            bool actual = myTest.MatchTest(p1, p2);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethodAllNull()
        {
            Person p1 = new Person() { SocialSecurityNumber = null, StateFileNumber = null, NewbornScreeningNumber = null };
            Person p2 = new Person() { SocialSecurityNumber = null, StateFileNumber = null, NewbornScreeningNumber = null };

            Algorithm_Identifiers myTest = new Algorithm_Identifiers();

            bool expected = false;
            bool actual = myTest.MatchTest(p1, p2);

            Assert.AreEqual(expected, actual);
        }
    }
}
