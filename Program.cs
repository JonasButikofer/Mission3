// there is a menu that based on your input runs different parts of the program
// 1 could be add fooditem, 2 is delete item, 3 is print all items, 4 is exit
// The FoodItem class needs 4 attributes for each instance:
//      Name, category, quantity, expo date
// List<FoodItem> -- this creates a list of the type (a list of an array, I think)
using System;
using System.Security.Cryptography.X509Certificates;
using Mission2;
using System.Collections.Generic;
using System.Linq;


namespace Mission2
{
    class Program
    {

        static List<FoodItem> fooditems = new List<FoodItem>();
        static void Main()
        {
            int input = 0;

            Console.WriteLine("Welcome to the Hilton Food Bank!" +
            "\n\nPlease select an option:\n" +
            "1: Add an inventory item \n" +
            "2: Delete an inventory item \n" +
            "3: Print all current inventory items \n" +
            "4: Exit the program");

            string inputString = Console.ReadLine();
            if (int.TryParse(inputString, out input))

                switch (input)
                {
                    case 1:
                        AddItem();
                        break;
                    case 2:
                        DeleteItem();
                        break;
                    case 3:
                        PrintItems();
                        break;
                    case 4:
                        Console.WriteLine("Exiting Program");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter a valid command: ");
                        Main();
                        break;
                }
        }
        public static void AddItem()
        {
            string itemName = "";
            string itemCategory = "";
            int itemQuantity = 0;
            DateTime exDate = DateTime.MinValue;

            Console.WriteLine("What is the name of the item you want to add? ");
            itemName = Console.ReadLine();

            Console.WriteLine("What category does this fall into? ");
            itemCategory = Console.ReadLine();

            Console.WriteLine("How many are there of this item? Answer with a digit. ");
            
            // the While loop is for error control
            while (true)
            {
                string quantityInput = Console.ReadLine();
                if (int.TryParse(quantityInput, out itemQuantity) && itemQuantity >= 0)
                {
                    break; 
                }
                else
                {
                    Console.WriteLine("Please enter a valid positive number for quantity.");
                }
            }

            //Console.WriteLine("When does the item(s) expire? YYYY-MM-DD ");
            //exDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter the expiration date (Format: YYYY-MM-DD):");


            // I stole the QA from Chat because that was tedious
            while (true)
            {
                string input = Console.ReadLine();

                // Check if the input matches the format YYYY-MM-DD and contains only digits and dashes
                if (input.Length == 10 && input[4] == '-' && input[7] == '-' &&
                    int.TryParse(input.Substring(0, 4), out int year) &&
                    int.TryParse(input.Substring(5, 2), out int month) &&
                    int.TryParse(input.Substring(8, 2), out int day) &&
                    month >= 1 && month <= 12 && day >= 1 && day <= 31)
                {
                    if (DateTime.TryParse(input, out exDate))
                    {
                        break; 
                    }
                    else
                    {
                        Console.WriteLine("Error: Invalid date format. Please enter the date in YYYY-MM-DD format.");
                    }
                }
                else
                {
                    Console.WriteLine("Error: Invalid format. Please enter the date in YYYY-MM-DD format.");
                }
            }

            FoodItem newItem = new FoodItem(itemName, itemCategory, itemQuantity, exDate);

            fooditems.Add(newItem);

            Console.WriteLine($"Thanks for adding '{itemName}' to the inventory!");

            // I had Chat teach me how to accept any key stroke before continuing so the transition is a bit cleaner
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();  
            Main();
        }

        public static void DeleteItem()
        {
            Console.WriteLine("What item do you want to delete? ");
            if (fooditems.Count == 0)
            {
                Console.WriteLine("The inventory is empty");
            }
            else
            {
                // I have code that shows all of the differnt items with just the name which in reality would be an issue but helps here
                foreach (var item in fooditems)
                {
                    
                    Console.WriteLine($"Name: {item.ItemName}");
                }
                string input = Console.ReadLine();

                // I basically had it figured out but I stole Chat's code for this section because it was easier
                var itemToRemove = fooditems.FirstOrDefault(item => item.ItemName.Equals(input, StringComparison.OrdinalIgnoreCase));

                if (itemToRemove != null)
                {

                    fooditems.Remove(itemToRemove);
                    Console.WriteLine($"Item '{input}' has been deleted from the inventory.");
                }
                else
                {
                    Console.WriteLine($"Item '{input}' was not found in the inventory.");
                }
            }

            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();  
            Main();
        }
    
        


        public static void PrintItems()
        {
            Console.WriteLine("The current inventory: ");

            if (fooditems.Count == 0)
            {
                Console.WriteLine("The inventory is empty");
            }
            else
            {
                foreach (var item in fooditems)
                {
                    // Print details of each item
                    Console.WriteLine($"Name: {item.ItemName}, Category: {item.ItemCategory}, Quantity: {item.ItemQuantity}, Expiration Date: {item.ItemDate.ToShortDateString()}");
                }
            }

            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();  
            Main();
        }
    }
}
