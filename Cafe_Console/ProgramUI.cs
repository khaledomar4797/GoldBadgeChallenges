using Cafe_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Console
{
    public class ProgramUI
    {
        private readonly MenuRepository _repo = new MenuRepository();
        public void Run()
        {
            SeedMenuWithMenuItem();
            Menu();
        }

        private void SeedMenuWithMenuItem()
        {
            Menu newMenu = new Menu("Chicken", "Chicken Meal", new List<string> { "Chicken Leg", "Chicken Wing" }, 5.00m);

            _repo.AddItemToTheMenu(newMenu);
        }

        private void Menu()
        {
            Console.Clear();

            bool continueToRun = true;

            while (continueToRun)
            {
                Console.Clear();

                Console.WriteLine("Select the follow options:\n" +
                    "1. Show all menu items\n" +
                    "2. Get a menu item by menu number\n" +
                    "3. Add a new menu item\n" +
                    "4. Update existing menu item\n" +
                    "5. Remove menu item\n" +
                    "6. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ShowAllMenuItems();
                        break;
                    case "2":
                        GetMenuItemByMenuNumber();
                        break;
                    case "3":
                        AddNewMenuItem();
                        break;
                    case "4":
                        UpdateExistingMenuItem();
                        break;
                    case "5":
                        RemoveMenuItem();
                        break;
                    case "6":
                        continueToRun = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Wrong option.\n");
                        break;
                }
            }
        }

        private void RemoveMenuItem()
        {
            Console.Clear();

            ShowAllMenuItems();

            Console.WriteLine("\nEnter the menu number to remove: ");

            int input = 0;


            if (int.TryParse(Console.ReadLine(), out input))
            {
                Console.Clear();

                Menu menu = _repo.GetMenuItemByNumber(input);

                if (menu != null)
                {
                    bool ItemWasDeleted = _repo.DeleteExitingMenuItem(menu);
                    if (ItemWasDeleted)
                    {
                        Console.WriteLine("The menu item was deleted successfuly");
                    }
                    else
                    {
                        Console.WriteLine("The menu item was not deleted successfuly");
                        return;
                    }

                    Console.WriteLine("Press any key to continue to the menu");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("There is no menu item with this menu number");
                    Console.WriteLine("Press any key to continue to the menu");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Invalid input!");
                Console.WriteLine("Press any key to continue to the menu");
                Console.ReadKey();
            }
        }

        private void UpdateExistingMenuItem()
        {
            Console.Clear();

            ShowAllMenuItems();

            Console.WriteLine("\nEnter the menu number to update: ");

            int input = 0;

            if (int.TryParse(Console.ReadLine(), out input))
            {
                Console.Clear();

                Menu currentMenuItem = _repo.GetMenuItemByNumber(input);

                if (currentMenuItem != null)
                {
                    Menu newMenu = new Menu();

                    Console.WriteLine("Enter the new name of the menu: ");
                    newMenu.MealName = Console.ReadLine();

                    Console.WriteLine("Enter the new description of the menu: ");
                    newMenu.MealDescription = Console.ReadLine();

                    Console.WriteLine("Enter the new ingredients of the menu follow by comma: ");
                    string ingredientInput = Console.ReadLine();
                    newMenu.MealIngredients = ingredientInput.Split(new char[] { ',', ' ' }).ToList();

                    Console.WriteLine("Enter the new price of the menu: ");
                    decimal priceInput = 0;

                    if (decimal.TryParse(Console.ReadLine(), out priceInput))
                    {
                        newMenu.Price = priceInput;
                    }
                    else
                    {
                        Console.WriteLine("Price should be decimal numbers.");
                        return;
                    }

                    bool menuItemWasUpdated = _repo.UpdateExitingMenuItem(input, newMenu);
                    if (menuItemWasUpdated)
                    {
                        Console.WriteLine("The menu item was updated successfuly");
                    }
                    else
                    {
                        Console.WriteLine("The menu item was not updated successfuly");
                        return;
                    }

                    Console.WriteLine("Press any key to continue to the menu");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("There is no menu item with this menu number.");
                    Console.ReadKey();
                }

            }
            else
            {
                Console.WriteLine("Invalid input!");
                Console.WriteLine("Press any key to continue to the menu");
                Console.ReadKey();
            }
        }

        private void AddNewMenuItem()
        {
            Console.Clear();

            Menu newMenu = new Menu();
            Console.WriteLine($"This is menu number {newMenu.MealNumber}");

            Console.WriteLine("Enter the name of the menu: ");
            newMenu.MealName = Console.ReadLine();

            Console.WriteLine("Enter the description of the menu: ");
            newMenu.MealDescription = Console.ReadLine();

            Console.WriteLine("Enter the ingredients of the menu follow by comma: ");
            string input = Console.ReadLine();
            newMenu.MealIngredients = input.Split(new char[] { ',', ' ' }).ToList();

            Console.WriteLine("Enter the price of the menu: ");
            decimal priceInput = 0;

            if (decimal.TryParse(Console.ReadLine(), out priceInput))
            {
                newMenu.Price = priceInput;
            }
            else
            {
                Console.WriteLine("Price should be decimal numbers.");
                return;
            }

            bool menuItemWasAdded = _repo.AddItemToTheMenu(newMenu);

            if (menuItemWasAdded)
            {
                Console.WriteLine("Menu item was added successfully");
            }
            else
            {
                Console.WriteLine("Menu item was not added!");
            }
            Console.WriteLine("Press any key to continue to the menu");
            Console.ReadKey();
        }

        private void GetMenuItemByMenuNumber()
        {
            Console.Clear();
            Console.WriteLine("Enter the menu number: ");

            int input = 0;

            if (int.TryParse(Console.ReadLine(), out input))
            {
                Menu menu = _repo.GetMenuItemByNumber(input);

                if (menu != null)
                {
                    DisplayMenuItem(menu);
                    Console.WriteLine("Press any key to continue to the menu");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("There is no menu item with this menu number");
                    Console.WriteLine("Press any key to continue to the menu");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Invalid input!");
                Console.WriteLine("Press any key to continue to the menu");
                Console.ReadKey();
            }

        }

        private void ShowAllMenuItems()
        {
            Console.Clear();

            List<Menu> listOfMenu = _repo.GetTheMenu();

            if (listOfMenu.Count > 0)
            {
                foreach (Menu menuItem in listOfMenu)
                {
                    DisplayMenuItem(menuItem);
                }
            }
            else
            {
                Console.WriteLine("The menu is empty\n");
            }

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        private void DisplayMenuItem(Menu menuItem)
        {
            Console.WriteLine($"Menu number: \t\t{menuItem.MealNumber}");
            Console.WriteLine($"Menu name: \t\t{menuItem.MealName}");
            Console.WriteLine($"Menu description: \t{menuItem.MealDescription}");
            Console.WriteLine("Menu ingredients: ");
            foreach (string ingredient in menuItem.MealIngredients)
            {
                Console.WriteLine($"\t{ingredient}");
            }
            Console.WriteLine($"Menu price: \t\t${menuItem.Price}");
            Console.WriteLine("-------------------------------------------------");
        }
    }
}
