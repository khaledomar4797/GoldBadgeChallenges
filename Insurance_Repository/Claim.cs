using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_Repository
{
        public enum ClaimType { Car, Home, Theft };
    public class Claim
    {
        public string ClaimID { get; set; }
        public ClaimType TypeOfClaim { get; set; }
        public string ClaimDescription { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        public Claim()
        {

        }

        public Claim(string claimID, ClaimType typeOfClaim, string claimDescription, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimID = claimID;
            ClaimDescription = claimDescription;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            TypeOfClaim = typeOfClaim;
            IsValid = CalculateClaimValidation(DateOfIncident, DateOfClaim);
        }

        private bool CalculateClaimValidation(DateTime dateOfIncident, DateTime dateOfClaim)
        {
            int totalDays = Convert.ToInt32((dateOfClaim - dateOfIncident).TotalDays);
            
            if (totalDays > 30)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
