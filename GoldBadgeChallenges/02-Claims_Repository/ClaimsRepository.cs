using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_Repository
{
    public class ClaimsRepository
    {
        private Queue<Claim> _claims = new Queue<Claim>(); //Enqueue moves to the end Dequeue removes oldest claim from start

        //See all claims
        public Queue<Claim> DisplayCurrentClaims()
        {
            return _claims;
        }

        //Enter a new claim
        public void AddNewClaim(Claim claim)
        {
            _claims.Enqueue(claim);
        }

        //Take care of next claim ---When the agent presses 'y', the claim will be pulled off the top of the queue. If the agent presses 'n', it will go back to the main menu.
        //public bool TakeCareOfClaim(int claimID)
        //{
        //    Claim claim = GetClaimByID(claimID);
        //    if (claimID == null)
        //    {
        //        return false;
        //    }
        //    int initialClaimCount = _claims.Count;
        //    _claims.Dequeue();
        //    if (initialClaimCount > _claims.Count)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }


        //}
        ////Get claim by ID to dequeue in RemoveClaim
        //private Claim GetClaimByID(int claimID)
        //{
        //    foreach (Claim claim in _claims)
        //    {
        //        if (claim.ClaimID == claimID)
        //        {
        //            return claim;
        //        }

        //    }
        //    return null;
        //}

    }
}
