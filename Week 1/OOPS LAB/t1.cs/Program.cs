﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace t1.cs
{
    internal class Program
    {
        static int add(int n1, int n2)
        { return n1 + n2; }
        static void Main(string[] args)
        {
            int num1, num2;
            Console.Write("Enter 1st Number: ");
            num1 = int.Parse(Console.ReadLine());
            Console.Write("Enter 2nd Number: ");
            num2 = int.Parse(Console.ReadLine());
            int result = add(num1, num2);
            Console.WriteLine($"Sum is: {result}");
            Console.Read();

        }
    }
}
