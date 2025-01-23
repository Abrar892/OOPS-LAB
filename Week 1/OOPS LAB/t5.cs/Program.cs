using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace t5.cs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1, sum=0;
            Console.Write("Enter Number: ");
            num1 = int.Parse(Console.ReadLine());
            while(num1 != -1)
            {
                sum = sum + num1;
                Console.Write("Enter Number: ");
                num1=int.Parse(Console.ReadLine());
            }
            Console.WriteLine("The total sum is {0}", sum);
            Console.Read();
        }
    }
}
