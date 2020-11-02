using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_Repository
{
    public class ClaimRepository
    {
        private Queue<Claim> _claim = new Queue<Claim>();

        //Create
        public bool AddItemToTheClaims(Claim item)
        {
            int currentClaimCount = _claim.Count;

            _claim.Enqueue(item);

            bool ItemWasAdded = (_claim.Count > currentClaimCount) ? true : false;

            return ItemWasAdded;
        }

        //Read
        public Queue<Claim> GetTheClaims()
        {
            return _claim;
        }

        public Claim GetTheClaimItemByID(string claimID)
        {
            foreach(Claim item in _claim)
            {
                if(item.ClaimID == claimID)
                {
                    return item;
                }
            }

            return null;
        }

        //Update
        public bool UpdateExitingClaimItem(string claimID, Claim claimItem)
        {
            Claim currentClaimItem = GetTheClaimItemByID(claimID);

            if(currentClaimItem != null)
            {
                currentClaimItem.TypeOfClaim = claimItem.TypeOfClaim;
                currentClaimItem.ClaimDescription = claimItem.ClaimDescription;
                currentClaimItem.ClaimAmount = claimItem.ClaimAmount;
                currentClaimItem.DateOfIncident = claimItem.DateOfIncident;
                currentClaimItem.DateOfClaim = claimItem.DateOfClaim;
                currentClaimItem.IsValid = claimItem.IsValid;

                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool DeleteClaimItem()
        {
            if (_claim.Count > 0)
            {
                _claim.Dequeue();
                return true;

            }
            else
            {
                return false;
            }
        }
    }
}
