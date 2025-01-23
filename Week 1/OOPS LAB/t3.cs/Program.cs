using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace t3.cs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float marks;
            Console.Write("Enter the Marks: ");
            marks= float.Parse(Console.ReadLine());
            if (marks > 50)
            {
                Console.WriteLine("You are Passed");
            }
            else
            {
                Console.WriteLine("You are Failed");
            }
            Console.Read();
        }
    }
}
