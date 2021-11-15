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

                        break;
                    case "2": //Add a new item to the menu
                        CreateNewItem();
                        break;
                    case "3": //Delete an item from the menu
                        
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
        //(CREATE) 2. Add a new item to the menu 
        private void CreateNewItem()
        {
            Console.Clear();
            
            Menu newMenu = new Menu();

            //Meal Number
            Console.WriteLine("Enter the meal number");
            string numberAsString = Console.ReadLine();
            newMenu.MealNumber = int.Parse(numberAsString);

            //Meal Name
            Console.WriteLine("Enter the name of the meal");
            newMenu.MealName = Console.ReadLine();
            
            //Meal Description
            Console.WriteLine("Enter the descriptions of the meal");
            newMenu.MealDescription = Console.ReadLine();

            //Meal Ingredients
            Console.WriteLine("Enter the ingredients of the meal");
            newMenu.MealIngredients = Console.ReadLine();

            //Meal Price
            Console.WriteLine("Enter the price of the meal");
            string priceAsString = Console.ReadLine();
            newMenu.MealPrice = decimal.Parse(priceAsString);

            _menuRepo.AddItemToMenuList(newMenu);
        }

    }
}
