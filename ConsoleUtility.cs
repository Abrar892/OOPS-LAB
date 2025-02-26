using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class ConsoleUtility
{
    public static void Header(string title)
    {
        Console.Clear();
        Console.WriteLine("***************************************************************");
        Console.WriteLine($"                         {title}");
        Console.WriteLine("***************************************************************");
    }

    public static void PressAnyKey()
    {
        Console.WriteLine("Press any key to Continue...");
        Console.ReadKey();
    }
}
}