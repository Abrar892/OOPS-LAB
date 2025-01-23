using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pizza.cs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the minimum number of orders: ");
            int minOrders = int.Parse(Console.ReadLine());
            Console.Write("Enter the minimum order price: ");
            int minPrice = int.Parse(Console.ReadLine());
            pizza_points(minOrders, minPrice);
        }
        static void pizza_points(int minOrders, int minPrice)
        {
            string filePath = "D:\\study\\2024-CS-59\\2nd semester\\Week 1\\OOPS LAB\\Customers.txt";
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found.");
                return;
            }
            string[] customerData = File.ReadAllLines(filePath);
            bool foundEligibleCustomer = false;
            foreach (string customer in customerData)
            {
                string[] parts = customer.Split(' ');
                string name = parts[0];
                int orderCount = int.Parse(parts[1]);
                string[] pricesString = parts[2].Trim('[', ']').Split(',');
                int qualifyingOrders = 0;
                foreach (string priceStr in pricesString)
                {
                    int price = int.Parse(priceStr);
                    if (price >= minPrice)
                    {
                        qualifyingOrders++;
                    }
                }
                if (qualifyingOrders >= minOrders)
                {
                    Console.WriteLine(name);
                    foundEligibleCustomer = true;
                }
            }
            if (!foundEligibleCustomer)
            {
                Console.WriteLine("\"\"");
            }
        }

    }
}

