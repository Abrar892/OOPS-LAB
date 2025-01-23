using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace t2.cs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float length;
            float area;
            Console.Write("Enter length: ");
            length = float.Parse(Console.ReadLine());
            area= length * length;
            Console.Write("THE AREA IS: ");
            Console.Write(area);
        }
    }
}
