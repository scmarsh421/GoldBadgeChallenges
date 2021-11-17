using _02_Claims_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_Console
{
    public class ProgramUI
    {
        private ClaimsRepository _claimsRepo = new ClaimsRepository();
        public void Run()
        {
            StarterClaims();
            ClaimMenu();
        }
        private void ClaimMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Welcome Komodo Claims Department Associate!\n" +
                    "Ready to take care of some claims? \n" +
                    "1. See all claims \n" +
                    "2. Take care of next claim \n" +
                    "3. Enter a new claim \n" +
                    "4. Exit Claims App");

                string input = Console.ReadLine();
                Console.Clear();
                switch (input)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        TakeCareOfClaims();
                        break;
                    case "3":
                        EnterNewClaim();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    case "5":
                        Console.WriteLine("Now Playing Mambo No. 5...");
                        break;
                    default:
                        Console.WriteLine("Please enter a valid selection");
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void StarterClaims()
        {
            Claim claim1 = new Claim(1, Claim.Type.Car, "Car accident on 465.", 400.00m, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27));
            _claimsRepo.AddNewClaim(claim1);
            Claim claim2 = new Claim(2, Claim.Type.Home, "House fire in kitchen", 400.00m, new DateTime(2018, 04, 25), new DateTime(2019, 04, 27));
            _claimsRepo.AddNewClaim(claim2);
        }
        private void SeeAllClaims() //1
        {
            Queue<Claim> currentClaims = _claimsRepo.DisplayCurrentClaims();
            foreach (Claim claim in currentClaims)
            {
                Console.WriteLine("ID\tType\tDescription\t\tAmount\tDateOfIncident\t\tDateOfClaim\t\tIsValid\n" +
                    $"{claim.ClaimID}\t{claim.ClaimType}\t{claim.Description}\t${claim.ClaimAmount}\t{claim.DateOfIncident}\t{claim.DateOfClaim}\t{claim.IsValid}\n");
            }
        }
        private void TakeCareOfClaims() //2
        {
            // print first claim in queue to console
            Claim firstClaim = _claimsRepo.DisplayCurrentClaims().Peek();
            Console.WriteLine("ID\tType\tDescription\t\tAmount\tDateOfIncident\t\tDateOfClaim\t\tIsValid\n" +
                $"{firstClaim.ClaimID}\t{firstClaim.ClaimType}\t{firstClaim.Description}\t${firstClaim.ClaimAmount}\t{firstClaim.DateOfIncident}\t{firstClaim.DateOfClaim}\t{firstClaim.IsValid}\n");

            // prompt user - Do you want to handle Claim?
            Console.WriteLine("Do you want to handle this claim? y/n");
            string input = Console.ReadLine();

            // if yes, 
            if (input == "y")
            {
                // call repo method to actually take care of claim
                _claimsRepo.TakeCareOfClaim(firstClaim.ClaimID);
            }
            else if (input != "n")
            {
                Console.WriteLine("Please enter a valid selection. Try again.");
            }
        }
        private void EnterNewClaim() //3
        {
            // prompt user for claim deets
            // set claim id
            Console.WriteLine("Please enter the claim id: ");
            int id = int.Parse(Console.ReadLine());

            // set type
            Console.WriteLine("Please enter the type of claim (Car, Home, Theft): ");
            string typeInput = Console.ReadLine();
            Claim.Type type =
                typeInput == "Car" ? Claim.Type.Car : // if user types "Car", set type to Car
                typeInput == "car" ? Claim.Type.Car :
                typeInput == "Home" ? Claim.Type.Home :
                typeInput == "home" ? Claim.Type.Home :
                typeInput == "Theft" ? Claim.Type.Theft :
                typeInput == "theft" ? Claim.Type.Theft :
                Claim.Type.Car; // default to Car if the user enters something other than options above

            // set description
            Console.WriteLine("Please enter the description of claim: ");
            string description = Console.ReadLine();

            // set amount (parse from string into decimal)
            Console.WriteLine("Please enter the amount of claim: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            // date of incident (parse dates)
            Console.WriteLine("Please enter the date of the incident (mm/dd/yyyy): ");
            DateTime dateOfIncident = DateTime.Parse(Console.ReadLine());

            // date of claim (parse dates)
            Console.WriteLine("Please enter the date of claim (mm/dd/yyyy): ");
            DateTime dateOfClaim = DateTime.Parse(Console.ReadLine());

            // build a new instance of claim object using deets that the user entered
            Claim claim = new Claim(id, type, description, amount, dateOfIncident, dateOfClaim);
            // call repo method to add claim to queue, passing new claim object as an argument 
            _claimsRepo.AddNewClaim(claim);

        }

    }
}
