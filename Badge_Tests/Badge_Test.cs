using System;
using System.Collections.Generic;
using System.Linq;
using Badge_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Badge_Tests
{
    [TestClass]
    public class Badge_Test
    {
        [TestMethod]
        public void CreateBadge_ShouldInitialize()
        {
            //Arrange
            Badge newBadge = new Badge(12345, new List<string> {"A1","A2" });

            //Act
            List<string> doorsList = new List<string>() { "A1", "A2" };

            bool doorListAreEqual = doorsList.SequenceEqual(newBadge.Doors);

            //Assert
            Assert.AreEqual(newBadge.BadgeID, 12345);
            Assert.IsTrue(doorListAreEqual);
        }
    }
}
