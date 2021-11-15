using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_Console
{
    class ProgramUI
    {
        public void Run()
        {
            Cafe();

        }
        private void Cafe()
        {
            Console.WriteLine("Welcome to the Komodo Cafe Menu Editor! \n" +
                "What would you like to do?" +
                "1. Look at the menu" +
                "2. Add a new item to the menu" +
                "3. Delete an item from the menu" +
                "4. Exit");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    //Read method
                    break;
                case "2":
                    //Add
                    break;
                case "3":
                    //delete
                    break;
                case "4":
                    //exit
                    break;
                default:
                    Console.WriteLine("Enter a valid number");
                    break;


            }
        }
        
    }
}
