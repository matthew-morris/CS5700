using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using PersonMatcher;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodSimpleData()
        {
            Person p1 = new Person() { FirstName = "Matt", MiddleName = "Michael", LastName = "Morris" };
            Person p2 = new Person() { FirstName = "Matthew", MiddleName = "Michael", LastName = "Morris" };

            Algorithm_NameTest myTest = new Algorithm_NameTest();

            bool expected = false;
            bool actual = myTest.MatchTest(p1, p2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethodNullData()
        {
            Person p1 = new Person() { FirstName = "Matt", MiddleName = "Michael", LastName = "Morris" };
            Person p2 = new Person() { FirstName = null, MiddleName = "Michael", LastName = "Morris" };

            Algorithm_NameTest myTest = new Algorithm_NameTest();

            bool expected = false;
            bool actual = myTest.MatchTest(p1, p2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethodAllNullData()
        {
            Person p1 = new Person() { FirstName = null, MiddleName = null, LastName = null, Gender = "Male" };
            Person p2 = new Person() { FirstName = null, MiddleName = null, LastName = null, Gender = "Male" };

            Algorithm_NameTest myTest = new Algorithm_NameTest();

            bool expected = false;
            bool actual = myTest.MatchTest(p1, p2);

            Assert.AreEqual(expected, actual);
        }
    }
}
