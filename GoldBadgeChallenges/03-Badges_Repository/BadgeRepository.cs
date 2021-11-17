using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_Repository
{
    public class BadgeRepository
    {
        //A badge repository that will have methods that do the following:
            //Create a dictionary of badges.
        Dictionary<int, Badge> _badges = new Dictionary<int, Badge>() { };
        public void CreateBadges(Badge badge)
        {
            _badges.Add(badge.BadgeID, badge);
        }
        
            //The key for the dictionary will be the BadgeID.
            // int key = BadgeID
            //The value for the dictionary will be the List of Door Names.
            
    }
}
