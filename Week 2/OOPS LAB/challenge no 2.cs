using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductManagementSystem
{
    // Product class with properties and behavior
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Category { get; set; }
        public string BrandName { get; set; }
        public string Country { get; set; }

        // Parameterized constructor to initialize a product
        public Product(int id, string name, float price, string category, string brandName, string country)
        {
            Id = id;
            Name = name;
            Price = price;
            Category = category;
            BrandName = brandName;
            Country = country;
        }

        // Method to display product details
        public void Display()
        {
            Console.WriteLine($"ID: {Id}, Name: {Name}, Price: {Price}, Category: {Category}, Brand: {BrandName}, Country: {Country}");
        }
    }

    class Program
    {
        // List to store product objects
        static List<Product> products = new List<Product>();

        // Function to add a new product
        static void AddProduct()
        {
            try
            {
                Console.Write("Enter Product ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter Product Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Product Price: ");
                float price = float.Parse(Console.ReadLine());

                Console.Write("Enter Product Category: ");
                string category = Console.ReadLine();

                Console.Write("Enter Brand Name: ");
                string brandName = Console.ReadLine();

                Console.Write("Enter Country: ");
                string country = Console.ReadLine();

                // Create a new product using the parameterized constructor and add it to the list
                Product product = new Product(id, name, price, category, brandName, country);
                products.Add(product);
                Console.WriteLine("Product added successfully.\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding product: " + ex.Message + "\n");
            }
        }

        // Function to display all products
        static void ShowProducts()
        {
            if (products.Count == 0)
            {
                Console.WriteLine("No products available.\n");
                return;
            }

            Console.WriteLine("Product Details:");
            foreach (var product in products)
            {
                product.Display();
            }
            Console.WriteLine();
        }

        // Function to calculate the total store worth (sum of all product prices)
        static void TotalStoreWorth()
        {
            if (products.Count == 0)
            {
                Console.WriteLine("No products available to calculate the total store worth.\n");
                return;
            }

            float totalWorth = products.Sum(p => p.Price);
            Console.WriteLine($"Total Store Worth: {totalWorth}\n");
        }

        // Main method with a menu-driven loop using if/else statements
        static void Main(string[] args)
        {
            int choice = -1;
            while (choice != 0)
            {
                Console.WriteLine("==== Product Management System ====");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Show Products");
                Console.WriteLine("3. Total Store Worth");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                // Read and parse the user's choice
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.\n");
                    continue;
                }
                Console.WriteLine();

                // Menu selection using if/else statements
                if (choice == 1)
                {
                    AddProduct();
                }
                else if (choice == 2)
                {
                    ShowProducts();
                }
                else if (choice == 3)
                {
                    TotalStoreWorth();
                }
                else if (choice == 0)
                {
                    Console.WriteLine("Exiting program.");
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.\n");
                }
            }
        }
    }
}
