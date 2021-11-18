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
            //The key for the dictionary will be the BadgeID.
            //The value for the dictionary will be the List of Door Names.  
        Dictionary<int, Badge> _badges = new Dictionary<int, Badge>() { };
        public void AddBadgeToDictionary(Badge badge)
        {
            _badges.Add(badge.BadgeID, badge);//here is where key = ID 
        }
        public Dictionary<int, Badge> DisplayAllBadges()
        {
            return _badges;
        }
        public Badge GetBadgeByID(int input)
        {
            foreach (KeyValuePair<int, Badge> keyValuePair in _badges)
            {
                Badge badge = keyValuePair.Value;
                if(input == keyValuePair.Key)
                {
                    return badge;
                }

            }
            return null;
        }
    }
}
