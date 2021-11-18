using _02_Claims_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _02_Claims_Tests
{
    [TestClass]
    public class ClaimsTests
    {
        [TestMethod]
        public void AddNewClaim_ShouldGetNotNull()
        {
            //Arrange
            ClaimsRepository claimsRepository = new ClaimsRepository();
            Claim claim1 = new Claim(1, Claim.Type.Car, "Car accident on 465.", 400.00m, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27));
            //Act
            claimsRepository.AddNewClaim(claim1);
            Claim claimFromQueue = claimsRepository.GetClaimByID(1);
            //Assert
            Assert.IsNotNull(claimFromQueue);
        }
        [TestMethod]
        public void TakeCareOfClaim_ShouldDequueAndReturTrue()
        {
            ClaimsRepository claimsRepository = new ClaimsRepository();
            Claim claim1 = new Claim(1, Claim.Type.Car, "Car accident on 465.", 400.00m, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27));
            
            claimsRepository.AddNewClaim(claim1);
            bool takenCare = claimsRepository.TakeCareOfClaim(claim1.ClaimID);

            Assert.IsTrue(takenCare);
        }
    }
}
