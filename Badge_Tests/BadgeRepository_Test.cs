using System;
using System.Collections.Generic;
using System.Linq;
using Badge_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Badge_Tests
{
    [TestClass]
    public class BadgeRepository_Test
    {
        [TestMethod]
        public void AddBadge_ShouldReturnCorrect()
        {
            //Arrange
            Badge newBadge = new Badge(12345, new List<string> { "A1", "A2" });
            BadgeRepository _repo = new BadgeRepository();

            //Act
            bool badgeWasAdded = _repo.AddNewBadge(newBadge);
            int numberOfBadges = _repo.GetTheBadges().Count;

            //Assert
            Assert.IsTrue(badgeWasAdded);
            Assert.AreEqual(numberOfBadges, 1);
        }

        [TestMethod]
        public void GetBadgeList_ShouldReturnBadgeDoorList()
        {
            //Arrange
            Badge newBadge = new Badge(12345, new List<string> { "A1", "A2" });
            BadgeRepository _repo = new BadgeRepository();
            _repo.AddNewBadge(newBadge);
            List<string> currentDoorList = new List<string>();
            List<string> testDoorList = new List<string> { "A1", "A2" };

            //Act
            Dictionary<int, List<string>> currentBadgeList = _repo.GetTheBadges();
            currentBadgeList.TryGetValue(12345, out currentDoorList);
            bool doorListAreEqual = currentDoorList.SequenceEqual(testDoorList);

            //Assert
            Assert.IsTrue(currentBadgeList.ContainsKey(12345));
            Assert.IsTrue(doorListAreEqual);

        }

        [TestMethod]
        public void GetBadgeDoorList_ShouldReturnBadgeDoorList()
        {
            //Arrange
            Badge newBadge = new Badge(12345, new List<string> { "A1", "A2" });
            BadgeRepository _repo = new BadgeRepository();
            _repo.AddNewBadge(newBadge);

            //Act
            List<string> currenDoorList = _repo.GetDoorListByBadgeID(12345);

            //Assert
            Assert.AreEqual(currenDoorList, newBadge.Doors);
        }

        [TestMethod]
        public void UpdateBadge_ShouldReturnCorrect()
        {
            //Arrange
            Badge currentBadge = new Badge(12345, new List<string> { "B1", "B2" });
            Badge newBadge = new Badge(12345, new List<string> { "A1", "A2" });

            BadgeRepository _repo = new BadgeRepository();
            _repo.AddNewBadge(currentBadge);

            //Act
            bool badgeWasUpdated = _repo.UpdateABadge(currentBadge.BadgeID, newBadge);
            
            //Assert
            Assert.IsTrue(badgeWasUpdated);
        }

        [TestMethod]
        public void DeleteBadge_ShouldReturnCorrect()
        {
            //Arrange
            Badge newBadge = new Badge(12345, new List<string> { "A1", "A2" });
            BadgeRepository _repo = new BadgeRepository();
            _repo.AddNewBadge(newBadge);

            //Act
            bool badgeWasDeleted = _repo.DeleteABadge(newBadge);
            int numberOfBadges = _repo.GetTheBadges().Count;

            //Assert
            Assert.IsTrue(badgeWasDeleted);
            Assert.AreEqual(numberOfBadges, 0);
        }
    }
}
