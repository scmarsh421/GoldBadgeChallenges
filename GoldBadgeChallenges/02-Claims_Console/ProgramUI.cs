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
            CurrentClaims();
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
                switch (input)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        //Take care
                        break;
                    case "3":
                        //enter
                        break;
                    case "4":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void CurrentClaims()
        {
            Claim claim1 = new Claim(1, Claim.Type.Car, "Car accident on 465.", 400.00m, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27));
            Claim claim2 = new Claim(2, Claim.Type.Car, "Car accident on 465.", 400.00m, new DateTime(2018, 04, 25), new DateTime(2019, 04, 27));
            
            
            _claimsRepo.AddNewClaim(claim1);
            _claimsRepo.AddNewClaim(claim2);
        }
        private void SeeAllClaims() //1
        {
            Queue<Claim> currentClaims = _claimsRepo.DisplayCurrentClaims();
            foreach (Claim claim in currentClaims)
            {
                Console.WriteLine("ID\tType\tDescription\t\tAmmount\tDateOfIncident\t\tDateOfClaim\t\tIsValid\n" +
                    $"{claim.ClaimID}\t{claim.ClaimType}\t{claim.Description}\t${claim.ClaimAmount}\t{claim.DateOfIncident}\t{claim.DateOfClaim}\t{claim.IsValid}\n");
            }
        }

    }
}
