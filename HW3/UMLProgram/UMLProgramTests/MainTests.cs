using Microsoft.VisualStudio.TestTools.UnitTesting;
using UMLProgram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppLayer;

namespace UMLProgram.Tests
{
    [TestClass()]
    public class MainTests
    {
        [TestMethod()]
        public void deleteObjectTest()
        {
            List<AppLayer.Object> myObjects = new List<AppLayer.Object>();
            ClassDiagram myObject = new ClassDiagram(0, 0, 100, 100);

            myObjects.Add(myObject);

            DeleteObjectCommand myCommand = new DeleteObjectCommand(myObject, ref myObjects);
            myCommand.execute();

            if (myObjects.Count != 0)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void deleteObjectUndoTest()
        {
            List<AppLayer.Object> myObjects = new List<AppLayer.Object>();
            ClassDiagram myObject = new ClassDiagram(0, 0, 100, 100);

            myObjects.Add(myObject);

            DeleteObjectCommand myCommand = new DeleteObjectCommand(myObject, ref myObjects);
            myCommand.execute();

            myCommand.undo();

            if (myObjects.Count != 1)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void createObjectTest()
        {
            List<AppLayer.Object> myObjects = new List<AppLayer.Object>();
            ClassDiagram myObject = new ClassDiagram(0, 0, 100, 100);

            CreateObjectCommand myCommand = new CreateObjectCommand(myObject, ref myObjects);
            myCommand.execute();

            if (myObjects.Count != 1)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void createObjectUndoTest()
        {
            List<AppLayer.Object> myObjects = new List<AppLayer.Object>();
            ClassDiagram myObject = new ClassDiagram(0, 0, 100, 100);

            CreateObjectCommand myCommand = new CreateObjectCommand(myObject, ref myObjects);
            myCommand.execute();

            myCommand.undo();

            if (myObjects.Count != 0)
            {
                Assert.Fail();
            }
        }
    }
}