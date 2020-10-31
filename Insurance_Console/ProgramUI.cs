using Insurance_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_Console
{
    public class ProgramUI
    {
        private readonly ClaimRepository _repo = new ClaimRepository();
        public void Run()
        {
            SeedClaimsWithClaimItem();
            Menu();
        }

        public void SeedClaimsWithClaimItem()
        {
            Claim newClaim1 = new Claim("1", ClaimType.Car, "Car accident on 465.", 400.00m, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27));
            Claim newClaim2 = new Claim("2", ClaimType.Home, "House fire in kitchen.", 4000.00m, new DateTime(2018, 4, 11), new DateTime(2018, 4, 12));
            Claim newClaim3 = new Claim("3", ClaimType.Theft, "Stolen pancakes", 4.00m, new DateTime(2018, 4, 27), new DateTime(2018, 6, 1));
            
            _repo.AddItemToTheClaims(newClaim1);
            _repo.AddItemToTheClaims(newClaim2);
            _repo.AddItemToTheClaims(newClaim3);
        }

        public void Menu()
        {
            Console.Clear();

            bool continueToRun = true;

            while (continueToRun)
            {
                Console.Clear();

                Console.WriteLine("Select the follow options:\n" +
                    "1. See all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ShowAllClaims();
                        break;
                    case "2":
                        NextClaim();
                        break;
                    case "3":
                        AddNewClaimItem();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Wrong option.\n");
                        Console.WriteLine("Press any key to continue to menu.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public void ShowAllClaims()
        {
            Console.Clear();

            Queue<Claim> claimList = _repo.GetTheClaims();

            if (claimList.Count > 0)
            {
                Console.WriteLine($"ClaimID\tType\tDescription\t\t{"Amount",-13} {"DateOfAccident",-17}{"DateOfClaim",-15} {"IsValid",-10}\n");
                foreach (Claim claimItem in claimList)
                {
                    Console.WriteLine($"{claimItem.ClaimID}\t{claimItem.TypeOfClaim}\t{claimItem.ClaimDescription,-20}\t${claimItem.ClaimAmount,-7}\t{claimItem.DateOfIncident.ToShortDateString(),-5}\t{claimItem.DateOfClaim.ToShortDateString(),-10}\t{claimItem.IsValid}\n");
                }
            }
            else
            {
                Console.WriteLine("There are no claims\n");
                Console.WriteLine("Press any key to continue to menu.");
                Console.ReadKey();
            }

            Console.WriteLine("Press any key to continue to menu.");
            Console.ReadKey();

        }

        public void NextClaim()
        {
            Console.Clear();

            Queue<Claim> claimList = _repo.GetTheClaims();

            if(claimList.Count > 0)
            {
                Console.WriteLine("Here are the details for the next claim to be handled:\n");
                
                DisplayClaim(claimList.Peek());

                Console.WriteLine("Do you want to deal with this claim now(y/n)?");
                string input = Console.ReadLine().ToLower();

                if(input == "y")
                {
                    _repo.DeleteClaimItem();

                    Console.WriteLine("\nClaim handled successfuly. \nPress any key to continue to menu.");
                    Console.ReadLine();
                }
                else if(input == "n")
                {
                    Console.WriteLine("\nNo claim was handled. \nPress any key to continue to menu.");
                    Console.ReadLine();
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                    Console.WriteLine("Press any key to continue to menu.");
                    Console.ReadKey();
                    return;
                }
            }
            else
            {
                Console.WriteLine("There are no claims to take care. \nPress any key to continue to menu.");
                Console.ReadLine();
                return;
            }
        }

        public void AddNewClaimItem()
        {
            Console.Clear();

            Claim newClaim = new Claim();

            Console.WriteLine("Enter the claim ID: ");
            newClaim.ClaimID = Console.ReadLine();

            Console.WriteLine("Enter the claim type (Car, Home, Theft): ");
            string claimTypeInput = Console.ReadLine();
            if(claimTypeInput.ToLower() == "car")
            {
                newClaim.TypeOfClaim = ClaimType.Car;

            }
            else if (claimTypeInput.ToLower() == "home")
            {
                newClaim.TypeOfClaim = ClaimType.Home;

            }
            else if (claimTypeInput.ToLower() == "theft")
            {
                newClaim.TypeOfClaim = ClaimType.Theft;

            }
            else
            {
                Console.WriteLine("Invalid claim type.");
                Console.WriteLine("Press any key to continue to menu.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Enter a claim description: ");
            newClaim.ClaimDescription = Console.ReadLine();
            
            Console.WriteLine("Amount of Damage:");

            decimal amountInput = 0;

            if(decimal.TryParse(Console.ReadLine(), out amountInput))
            {
                newClaim.ClaimAmount = amountInput;

            }
            else
            {
                Console.WriteLine("Invalid amount input");
                Console.WriteLine("Press any key to continue to menu.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Date Of Accident (yyyy/mm/dd): ");
            DateTime dateOfIncident;

            if(DateTime.TryParse(Console.ReadLine(), out dateOfIncident))
            {
                newClaim.DateOfIncident = dateOfIncident;

            }
            else
            {
                Console.WriteLine("Invalid datetime input");
                Console.WriteLine("Press any key to continue to menu.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Date of Claim (yyyy/mm/dd): ");
            DateTime dateOfClaim;

            if (DateTime.TryParse(Console.ReadLine(), out dateOfClaim))
            {
                newClaim.DateOfClaim = dateOfClaim;

            }
            else
            {
                Console.WriteLine("Invalid datetime input");
                Console.WriteLine("Press any key to continue to menu.");
                Console.ReadKey();
                return;
            }


            int totalDays = Convert.ToInt32((newClaim.DateOfClaim - newClaim.DateOfIncident).TotalDays);
            
            if (totalDays > 30)
            {
                newClaim.IsValid = false;
                Console.WriteLine("This claim is not valid.");
            }
            else
            {
                newClaim.IsValid = true;
                Console.WriteLine("This claim is valid.");
            }

            bool itemWasAdded = _repo.AddItemToTheClaims(newClaim);

            if(itemWasAdded)
            {
                Console.WriteLine("New claim is added.");
                Console.WriteLine("Press any key to continue to menu.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Error! the new claim is not added.");
                Console.WriteLine("Press any key to continue to menu.");
                Console.ReadKey();
            }

        }

        private void DisplayClaim(Claim claimItem)
        {
            Console.WriteLine($"ClaimID: {claimItem.ClaimID}\n");
            Console.WriteLine($"Type: {claimItem.TypeOfClaim}\n");
            Console.WriteLine($"Description: {claimItem.ClaimDescription}\n");
            Console.WriteLine($"Amount: ${claimItem.ClaimAmount}\n");
            Console.WriteLine($"DateOfAccident: {claimItem.DateOfIncident.ToShortDateString()}\n");
            Console.WriteLine($"DateOfClaim: {claimItem.DateOfClaim}\n");
            Console.WriteLine($"IsValid: {claimItem.IsValid}\n");
        }
    }
}
