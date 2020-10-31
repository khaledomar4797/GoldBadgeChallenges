using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge_Repository
{
    public class BadgeRepository
    {
        private Dictionary<int, List<string>> _badgeRepo = new Dictionary<int, List<string>>();
        

        //Create
        public bool AddNewBadge(Badge badge)
        {
            int currentBadgeCount = _badgeRepo.Count;

            _badgeRepo.Add(badge.BadgeID, badge.Doors);

            bool newBadgeWasAdded = (_badgeRepo.Count > currentBadgeCount) ? true : false;

            return newBadgeWasAdded;
        }

        //Read
        public Dictionary<int, List<string>> GetTheBadges()
        {
            return _badgeRepo;
        }

        public List<string> GetDoorListByBadgeID(int badgeID)
        {
            List<string> doorList = new List<string>();

            _badgeRepo.TryGetValue(badgeID, out doorList);

            return doorList;
        }

        //Update

        public bool UpdateABadge(int badgeID, Badge newBadge)
        {
            if (_badgeRepo.ContainsKey(badgeID))
            {
                //List<string> currentDoorList = newBadge.Doors.ToList();

                _badgeRepo[badgeID] = newBadge.Doors;

                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool DeleteABadge(Badge badge)
        {
            bool badgeWasDeleted = _badgeRepo.Remove(badge.BadgeID);

            return badgeWasDeleted;
        }
    }
}
