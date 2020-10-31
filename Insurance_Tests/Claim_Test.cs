using System;
using Insurance_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Insurance_Tests
{
    [TestClass]
    public class Claim_Test
    {
        [TestMethod]
        public void CreateClaimItem_ShouldInitialize()
        {
            //Arrange
            Claim newClaim = new Claim();

            //Act
            newClaim.ClaimID = "1";
            newClaim.TypeOfClaim = ClaimType.Car;
            newClaim.ClaimDescription = "Car Damage";
            newClaim.ClaimAmount = 400.00m;
            newClaim.DateOfIncident = new DateTime(2018, 04, 25);
            newClaim.DateOfClaim = new DateTime(2018, 04, 27);


            //Assert
            Assert.AreEqual(newClaim.ClaimID, "1");
            Assert.AreEqual(newClaim.TypeOfClaim, ClaimType.Car);
            Assert.AreEqual(newClaim.ClaimDescription, "Car Damage");
            Assert.AreEqual(newClaim.ClaimAmount, 400.00m);
            Assert.AreEqual(newClaim.DateOfIncident, new DateTime(2018, 04, 25));
            Assert.AreEqual(newClaim.DateOfClaim, new DateTime(2018, 04, 27));
        }
    }
}
