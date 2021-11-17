using _03_Badges_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_Console
{
    class ProgramUI
    {
        //new instance of repo
        private BadgeRepository _badgesRepo = new BadgeRepository();
        public void Run()
        {
            StarterBadges();
            BadgesMenu();
        }

        //starter badges
        private void BadgesMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Hello Security Admin, What would you like to do?\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all Badges\n" +
                    "4. Exit\n");
                string input = Console.ReadLine();
                Console.Clear();
                switch (input)
                {
                    case "1":
                        AddBadge();
                        break;
                    case "2":
                        //EditBadge();
                        break;
                    case "3":
                        //ListAllBadges();
                        break;
                    case "4":
                        Console.WriteLine("Bye");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number...");
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();

            }
        }
        private void StarterBadges()
        {
           //Badge badge = new Badge(12345, List<string>  )
           //CreateBadge()
        }
        //1. Create a new badge
        private void AddBadge() //1
        {
            Badge badge = new Badge();

            Console.WriteLine("What is the number on the badge?");
            int id = int.Parse(Console.ReadLine());
            badge.BadgeID = id; //make new badge have the BadgeID of the user input id

            List<string> newDoors = new List<string>(); //similiar to adding cafe ingredients to list
            bool allDoorsAdded = false;
            while (allDoorsAdded == false)
            {
                Console.WriteLine("List a door it need access to:");
                string door = Console.ReadLine();
                newDoors.Add(door); //add door to list
                
                Console.WriteLine("Any other doors(y/n)?");
                string yesNo = Console.ReadLine();
                if(yesNo == "y") { allDoorsAdded = false;}
                else if(yesNo == "n") { allDoorsAdded = true; }
            }
            badge.DoorNames = newDoors; //make new badge list of doors new list of strings 
        }
        
        //2. Update doors on an existing badge.
        //EditBadge();
        //3. Delete all doors from an existing badge.
        //DeleteAllDoors();
        //Console.WriteLine("badgeID no longer has access to doors");
        
        //4. Show a list with all badge numbers and door access, like this:
        //ListBadge();

    }
}
