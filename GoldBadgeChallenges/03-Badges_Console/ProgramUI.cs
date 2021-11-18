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

        private void BadgesMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.ForegroundColor = ConsoleColor.White;
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
                        CreateBadge();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        ListAllBadges();
                        break;
                    case "4":
                        Console.WriteLine("Bye");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number...");
                        break;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("_________________________________________________");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();

            }
        }
        //starter badges
        private void StarterBadges()
        {
            List<string> starterDoors = new List<string>() { "A1", "A7" }; // this is collection initializer syntax instead of add() method 
            Badge starterBadge = new Badge(12345, starterDoors);
            _badgesRepo.AddBadgeToDictionary(starterBadge);

            List<string> secondDoor = new List<string>() { "B4", "U-Exit", "C2", "GR8-Doors" };
            Badge secondStarter = new Badge(6789, secondDoor);
            _badgesRepo.AddBadgeToDictionary(secondStarter);
        }
        //1. Create a new badge
        private void CreateBadge() //1
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
                if (yesNo == "y") { allDoorsAdded = false; }
                else if (yesNo == "n") { allDoorsAdded = true; }
            }
            badge.DoorNames = newDoors; //make new badge list of doors new list of strings 
            _badgesRepo.AddBadgeToDictionary(badge); //should I rename badge to newBadge for this method???????????????????????????
        }

        //2. Edit a badge
        private void EditBadge()
        {
            ListAllBadges();
            Console.WriteLine("What is the badge you want to update? Please enter Badge #");
            int input = int.Parse(Console.ReadLine());
            Badge badgeToUpdate = _badgesRepo.GetBadgeByID(input);
            if (badgeToUpdate != null)
            {
                //continue to edit
                string doorsToPrint = ListDoorsToString(badgeToUpdate.DoorNames);
                Console.WriteLine($"Badge #{badgeToUpdate.BadgeID} has access to {doorsToPrint}");
                Console.WriteLine("What would you like to do?\n" +
                //1 to remove door
                    "1. Remove a Door\n" +
                //2 to add door
                    "2. Add a Door\n");

                string doorInput = Console.ReadLine();
                if (doorInput == "1")
                {
                    //REMOVE DOOR
                    Console.WriteLine("Which door do you want me to remove?");
                    string byeDoor = Console.ReadLine();
                    if (badgeToUpdate.DoorNames.Contains(byeDoor))
                        badgeToUpdate.DoorNames.Remove(byeDoor);
                    else
                        Console.WriteLine("Sorry bud you chose the wrong door...");
                }
                else if (doorInput == "2")
                {
                    // ADD DOOR
                    Console.WriteLine("What is the name of this door?");
                    string newDoor = Console.ReadLine();
                    badgeToUpdate.DoorNames.Add(newDoor);
                }
                else
                {
                    Console.WriteLine("Invalid input...");
                }

            }
            else
            {
                //GetBadgeID returned null so input is not valid
                Console.WriteLine("Invalid input...");
            }
            Console.Clear();
            ListAllBadges();


        }

        //3. List all Badges
        private void ListAllBadges()
        {
            Dictionary<int, Badge> currentBadges = _badgesRepo.DisplayAllBadges();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Key\n" +
                "Badge#\t\tDoor Access");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (KeyValuePair<int, Badge> keyValuePair in currentBadges) // dictionary is a collection of key-value pairs, loop through them here
            {
                int badgeID = keyValuePair.Key;
                Badge badge = keyValuePair.Value;
                List<string> doors = badge.DoorNames;
                string doorsToPrint = ListDoorsToString(doors);
                Console.WriteLine($"{badgeID}\t\t{doorsToPrint}\n");
            }
        }

        private static string ListDoorsToString(List<string> doors)
        {
            string doorsToPrint = "";
            foreach (string door in doors)
            {
                doorsToPrint += $"{door}, ";
            }

            return doorsToPrint;
        }
    }
}
