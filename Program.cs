using System;
using System.Collections.Generic;
using System.Configuration;

namespace LegacyInventorySystem
{
    class Program
    {
        static List<InventoryItem> inventory = new List<InventoryItem>();

        static void Main(string[] args)
        {
            string databaseName = ConfigurationManager.AppSettings["DatabaseName"];
            Console.WriteLine($"Connected to database: {databaseName}");

            while (true)
            {
                Console.WriteLine("\n1. Add Item");
                Console.WriteLine("2. List Items");
                Console.WriteLine("3. Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddItem();
                        break;
                    case "2":
                        ListItems();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void AddItem()
        {
            Console.Write("Enter item name: ");
            string name = Console.ReadLine();
            Console.Write("Enter item quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            inventory.Add(new InventoryItem { Name = name, Quantity = quantity });
            Console.WriteLine("Item added successfully.");
        }

        static void ListItems()
        {
            foreach (var item in inventory)
            {
                Console.WriteLine($"{item.Name}: {item.Quantity}");
            }
        }
    }
}