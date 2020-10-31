using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge_Repository
{
    public class Badge
    {
        public int BadgeID { get; set; }
        public List<string> Doors { get; set; }

        public Badge()
        {

        }
        public Badge(int badgeID, List<string> doors)
        {
            BadgeID = badgeID;
            Doors = doors;
        }
    }
}
