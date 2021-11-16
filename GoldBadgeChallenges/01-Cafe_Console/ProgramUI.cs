using _01_Cafe_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_Console
{
    class ProgramUI
    {
        private MenuRepository _menuRepo = new MenuRepository();
        public void Run()
        {
            Cafe();
        }
        private void Cafe()
        {
            bool keepRunning = true;
            while (keepRunning)
            {

                Console.WriteLine("Welcome to the Komodo Cafe Menu Editor! \n" +
                    "What would you like to do? \n" +
                    "1. Look at the menu \n" +
                    "2. Add a new item to the menu \n" +
                    "3. Delete an item from the menu \n" +
                    "4. Exit Menu Editor \n");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1": //Look at the menu
                        DisplayMenu();
                        break;
                    case "2": //Add a new item to the menu
                        CreateNewItem();
                        break;
                    case "3": //Delete an item from the menu
                        DeleteMenuItem();
                        break;
                    case "4": //Exit Menu Editor
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Enter a valid number...");
                        break;

                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();

            }
        }

        //(READ) 1. Look at Menu
        private void DisplayMenu()
        {
            Console.Clear();

            List<Menu> listOfitems = _menuRepo.GetAllItems();

            foreach (Menu menu in listOfitems)
            {
                string itemPrint = $"#{menu.MealNumber} {menu.MealName}      ${menu.MealPrice}\n" +
                    $"{menu.MealDescription}\n" +
                    $"Ingredients:";

                foreach (string ingredient in menu.MealIngredients) // this loop will add each ingredient string in the list to new line
                {
                    itemPrint += "\n" + ingredient; // shorthand of: itemPrint = itemPrint + "\n" + ingredient;
                }
                Console.WriteLine(itemPrint);
                Console.WriteLine("___________________________________________");
            }
        }

        //(CREATE) 2. Add a new item to the menu 
        private void CreateNewItem()
        {
            Console.Clear();

            Menu newMenu = new Menu();

            //Meal Number
            Console.WriteLine("Enter the meal number");

            newMenu.MealNumber = int.Parse(Console.ReadLine());

            //Meal Name
            Console.WriteLine("Enter the name of the meal");
            newMenu.MealName = Console.ReadLine();

            //Meal Description
            Console.WriteLine("Enter the description of the meal");
            newMenu.MealDescription = Console.ReadLine();

            //Meal Ingredients
            List<string> newListOfIngredients = new List<string>();
            bool allIngredientsAdded = false;
            while (allIngredientsAdded == false)
            {
                Console.WriteLine("Enter an ingredient of the meal");
                string newIngredient = Console.ReadLine();
                newListOfIngredients.Add(newIngredient);
                Console.WriteLine("Do you want to add more ingredients? y/n");
                string yesNo = Console.ReadLine();
                if (yesNo == "n") { allIngredientsAdded = true; }
                else if (yesNo == "y") { allIngredientsAdded = false; }
            }
            newMenu.MealIngredients = newListOfIngredients;

            //Meal Price
            Console.WriteLine("Enter the price of the meal");
            newMenu.MealPrice = decimal.Parse(Console.ReadLine());

            _menuRepo.AddItem(newMenu);

        }

        //(DELETE) 3. Delete an item from the menu
        private void DeleteMenuItem()
        {
            DisplayMenu();
            Console.WriteLine("Please enter the name of the item you want to delete");
            string input = Console.ReadLine();
            bool wasDeleted = _menuRepo.RemoveItem(input);
            if (wasDeleted)
            {
                Console.WriteLine("Item was successfully deleted...");
                Console.WriteLine("Good riddance!");
            }
            else
            {
                Console.WriteLine("Item could not be deleted...");
                Console.WriteLine("Maybe you typed the wrong name.");
            }
        }
        


    }
}
