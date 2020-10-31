using Badge_Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge_Console
{
    public class ProgramUI
    {
        private readonly BadgeRepository _repo = new BadgeRepository();
        public void Run()
        {
            SeedBadgeToList();
            Menu();
        }

        public void SeedBadgeToList()
        {
            Badge b1 = new Badge(12345, new List<string> { "A7" });
            Badge b2 = new Badge(22345, new List<string> { "A1", "A4", "B1", "B2" });
            Badge b3 = new Badge(32345, new List<string> { "A4", "A5" });

            _repo.AddNewBadge(b1);
            _repo.AddNewBadge(b2);
            _repo.AddNewBadge(b3);
        }

        public void Menu()
        {
            Console.Clear();

            bool continueToRun = true;

            while (continueToRun)
            {
                Console.Clear();

                Console.WriteLine("Hello Security Admin, What would you like to do?:\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all Badges\n" +
                    "4. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddBadge();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        ListAllBadges();
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
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

        private void AddBadge()
        {
            Console.Clear();

            Badge newBadge = new Badge();
            List<string> newDoors = new List<string>();

            Console.WriteLine("What is the number on the badge: ");
            int badgeIDInput = 0;

            if (int.TryParse(Console.ReadLine(), out badgeIDInput))
            {
                newBadge.BadgeID = badgeIDInput;
            }
            else
            {
                Console.WriteLine("\nInvalid input. Badge number should be numerical");
                Console.WriteLine("Press any key to continue menu.");
                Console.ReadLine();
                return;
            }

            string continueToRun = "y";

            while (continueToRun == "y")
            {
                Console.WriteLine("List a door that it needs access to: ");
                string doorInput = Console.ReadLine();
                newDoors.Add(doorInput);

                Console.WriteLine("Any other doors(y/n)?");
                continueToRun = Console.ReadLine().ToLower();
            }

            newBadge.Doors = newDoors;
            bool newBadgeAdded = _repo.AddNewBadge(newBadge);

            if (newBadgeAdded)
            {
                Console.WriteLine("New badge was added successfully.");
            }
            else
            {
                Console.WriteLine("the badge was not added successfully!");
            }

            Console.WriteLine("\nPress any key to continue menu.");
            Console.ReadKey();
        }

        private void EditBadge()
        {
            List<string> currentBadge = null;
            int badgeIDInput = 0;

            Console.Clear();

            Console.WriteLine("This is the list of all badges.");

            ListAllBadges();

            Console.WriteLine("\nWhat is the badge number to update?");

            if (int.TryParse(Console.ReadLine(), out badgeIDInput))
            {
                currentBadge = _repo.GetDoorListByBadgeID(badgeIDInput);
            }
            else
            {
                Console.WriteLine("\nInvalid input. Badge number should be numerical");
                Console.WriteLine("Press any key to continue menu.");
                Console.ReadLine();
                return;
            }

            if (currentBadge != null)
            {
                Console.WriteLine($"\n{badgeIDInput} has access to doors {String.Join(" & ", currentBadge)}");
                Console.WriteLine("What would you like to do?\n" +
                    "\t1. Remove a door\n" +
                    "\t2. Add a door");

                int nextStepToUpdateInput = 0;

                if (int.TryParse(Console.ReadLine(), out nextStepToUpdateInput))
                {
                    if (nextStepToUpdateInput == 1)
                    {
                        Console.WriteLine("Which door would you like to remove?");
                        string input = Console.ReadLine();
                        if (currentBadge.Remove(input))
                        {
                            Console.WriteLine("\nDoor removed.");
                        }
                        else
                        {
                            Console.WriteLine("\nDoor was not removed successfuly. \nThis badge don't have this door.");
                        }

                        Console.WriteLine($"{badgeIDInput} has access to doors {String.Join(" & ", currentBadge)}");
                    }
                    else if (nextStepToUpdateInput == 2)
                    {
                        Console.WriteLine("Enter a door you would like to add:");
                        string input = Console.ReadLine();
                        currentBadge.Add(input);
                        Console.WriteLine("\nDoor Added.");
                        Console.WriteLine($"{badgeIDInput} has access to doors {String.Join(" & ", currentBadge)}");
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input. Choice the correct option.");
                        Console.WriteLine("Press any key to continue menu.");
                        Console.ReadLine();
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("\nInvalid input. Badge number should be numerical");
                    Console.WriteLine("Press any key to continue menu.");
                    Console.ReadLine();
                    return;
                }
                Console.ReadKey();

            }
            else
            {
                Console.WriteLine("There is no badge with this badge id.");
                Console.ReadKey();
            }

        }

        private void ListAllBadges()
        {
            Console.Clear();

            Dictionary<int, List<string>> badgeList = _repo.GetTheBadges();

            if (badgeList.Count > 0)
            {

                Console.WriteLine("Badge#\tDoorAccess");
                foreach (KeyValuePair<int, List<string>> badge in badgeList)
                {
                    Console.WriteLine($"{badge.Key}\t{String.Join(", ", badge.Value)}");
                }
            }
            else
            {
                Console.WriteLine("The badge list is empty\n");
            }
        }

    }
}
