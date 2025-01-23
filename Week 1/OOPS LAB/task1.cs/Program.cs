using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1.cs
{
    internal class Program
    {
        static int calculate(int age, int wmPrice, int tPrice)
        {
            int totalMoney = 0;
            int toyCount = 0;
            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    totalMoney += (10 * (i / 2)) - 1;

                }
                else
                {
                    toyCount++;
                }
            }
            totalMoney += toyCount * tPrice;
            int remaining = totalMoney - wmPrice;
            return remaining;
        }
        static void Main(string[] args)
        {
            int age, wmPrice, tPrice;
            Console.Write("Enter Lilly's age: ");
            age=int.Parse(Console.ReadLine());
            Console.Write("Enter the price of the washing machine: ");
            wmPrice = int.Parse(Console.ReadLine());
            Console.Write("Enter the price of each toy: ");
            tPrice = int.Parse(Console.ReadLine());
            int result = calculate(age, wmPrice, tPrice);
            if (result >= 0)
            {
                Console.WriteLine($"Yes! {result}");
            }
            else
            {
                Console.Write($"No!  {-result}");
            }
        }
    }
}

