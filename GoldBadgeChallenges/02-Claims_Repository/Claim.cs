using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_Repository
{
    public class Claim
    {
        public enum Type
        {
            Car = 1,
            Home,
            Theft,
        }
        public int  ClaimID { get; set; }
        public Type ClaimType  { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        public Claim(int claimID, Type claimType, string description, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;

            //IF the date of the claim has been more than 30 days since incident -> IsValid = false 
            //ELSE -> IsValid = true
            TimeSpan interval = dateOfClaim - dateOfIncident; 
            if(interval.TotalDays > 30)
            {
                IsValid = false;
            }
            else
            {
                IsValid = true;
            }
            IsValid = isValid;
        }
    }
}
