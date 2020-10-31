using System;
using System.Collections;
using System.Collections.Generic;
using Insurance_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Insurance_Tests
{
    [TestClass]
    public class ClaimRepository_Test
    {
        [TestMethod]
        public void AddClaimItem_ShouldReturnCorrect()
        {
            //Arrange
            Claim newClaim = new Claim("1", ClaimType.Car, "Car accident on 465.", 400.00m, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27));
            ClaimRepository _repo = new ClaimRepository();

            //Act
            bool ItemWasAdded = _repo.AddItemToTheClaims(newClaim);
            int numberOfClaims = _repo.GetTheClaims().Count;

            //Assert
            Assert.IsTrue(ItemWasAdded);
            Assert.AreEqual(numberOfClaims, 1);
        }

        [TestMethod]
        public void GetClaimQueue_ShouldReturnClaimQueue()
        {
            //Arrange
            Claim newClaim = new Claim("1", ClaimType.Car, "Car accident on 465.", 400.00m, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27));
            ClaimRepository _repo = new ClaimRepository();

            //Act
            _repo.AddItemToTheClaims(newClaim);
            Queue<Claim> newClaimQueue = _repo.GetTheClaims();

            bool newClaimQueueContainNewClaim = newClaimQueue.Contains(newClaim);

            //Assert
            Assert.IsTrue(newClaimQueueContainNewClaim);
        }

        [TestMethod]
        public void GetClaimItemByID_ShouldReturnCorrectClaimItem()
        {
            //Arrange
            Claim newClaim = new Claim("1", ClaimType.Car, "Car accident on 465.", 400.00m, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27));
            ClaimRepository _repo = new ClaimRepository();
            _repo.AddItemToTheClaims(newClaim);

            //Act
            Claim currentClaim = _repo.GetTheClaimItemByID("1");

            //Assert
            Assert.AreEqual(currentClaim.ClaimDescription, "Car accident on 465.");
        }

        [TestMethod]
        public void UpdateClaimItem_ShouldReturnCorrect()
        {
            //Arrange
            Claim currentClaim = new Claim("1", ClaimType.Car, "Car accident on 465.", 400.00m, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27));
            Claim newClaim = new Claim("1", ClaimType.Car, "Car accident on 1234.", 400.00m, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27));
            ClaimRepository _repo = new ClaimRepository();
            _repo.AddItemToTheClaims(currentClaim);

            //Act
            bool claimItemWasUpdated = _repo.UpdateExitingClaimItem("1", newClaim);

            //Assert
            Assert.IsTrue(claimItemWasUpdated);
            Assert.AreEqual(currentClaim.ClaimDescription, "Car accident on 1234.");
        }

        [TestMethod]
        public void DeleteClaimItem_ShouldReturnCorrect()
        {
            //Arrange
            Claim newClaim = new Claim("1", ClaimType.Car, "Car accident on 465.", 400.00m, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27));
            ClaimRepository _repo = new ClaimRepository();

            _repo.AddItemToTheClaims(newClaim);

            //Act
            bool claimItemWasRemoved = _repo.DeleteClaimItem();
            int currentClaimCount = _repo.GetTheClaims().Count;

            //Assert
            Assert.IsTrue(claimItemWasRemoved);
            Assert.AreEqual(currentClaimCount, 0);
            
        }
    }
}
