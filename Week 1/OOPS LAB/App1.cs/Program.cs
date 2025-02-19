using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.cs
{
    internal class Program
    {
        const int MaxUsers = 30; // Maximum number of users
        static int usersCount = 0; // Keeps track of the current number of users

        // Separate arrays for user data
        static string[] usernames = new string[MaxUsers];
        static string[] passwords = new string[MaxUsers];
        static string[] roles = new string[MaxUsers];

        const string FilePath = "D:\\study\\2024-CS-59\\2nd semester\\Week 1\\OOPS LAB\\usersData.txt";
        static void Main(string[] args)
        {
            LoadUserData();
            const string namemanager = "Abrar";
            const string passwordmanager = "1234567";
            header();
            string menuOption = mainMenu();
            while (menuOption != "3")
            {
                if (checkmenu(menuOption))
                {
                    if (menuOption == "2")
                    {
                        header();
                        string name, password, role;
                        Console.Write("   Enter your name: ");
                        name = Console.ReadLine();
                        Console.Write("   Enter your password: ");
                        password = Console.ReadLine();
                        Console.Write("   Enter your role (Guest or Manager): ");
                        role = Console.ReadLine();
                        bool isValid = signUp(name, password, role);
                        if (isValid)
                        {
                            Console.WriteLine("   Signed Up Successfully");
                        }
                        else
                        {
                            Console.WriteLine("   Incorrect input...");
                        }
                        Console.Write("   Press any key to continue....");
                        clearscreen();
                        menuOption = mainMenu();
                    }
                    else if (menuOption == "1")
                    {
                        header();
                        string name, password;
                        Console.Write("   Enter your name: ");
                        name = Console.ReadLine();
                        Console.Write("   Enter your password: ");
                        password = Console.ReadLine();
                        string role = login(name, password);
                        if (role == "Manager" && name == namemanager && password == passwordmanager)
                        {
                            Console.WriteLine("    Press Any Key to Continue to Manager Interface..");
                            Console.WriteLine("    LOGIN SUCCESSFULLY!");
                            Console.ReadKey();
                        }
                        else if (role == "Guest")
                        {
                            Console.WriteLine("    Press Any Key to Continue to Guest Interface..");
                            Console.WriteLine("    WELCOME TO HOTEL MATE");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("   Invalid credentials. Try again.");
                            Console.Write("   Press any key to continue...");
                            clearscreen();
                            menuOption = mainMenu();
                        }
                    }
                }
                else
                {
                    Console.Write("   Please enter option between 1-3..... ");
                    clearscreen();
                    menuOption = mainMenu();
                }
            }
            SaveUserData();
            header();
            Console.Write("  Please enter any key to exit the app....");
            Console.ReadKey();
        }
        static string mainMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   1. Login");
            Console.WriteLine("   2. Sign up");
            Console.WriteLine("   3. Exit");
            Console.WriteLine(" ");
            Console.WriteLine("   ------------------------------------------");
            Console.Write("   Enter your choice : ");
            string option = Console.ReadLine();
            return option;
        }
        static void header()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.WriteLine("   ================================================================================");
            Console.WriteLine("     ___ ___ _______ _______ _______ ___         ___ ___ _______ _______ _______   ");
            Console.WriteLine("    |   Y   |   _   |       |   _   |   |       |   Y   |   _   |       |   _   |  ");
            Console.WriteLine("    |.  1   |.  |   |.|   | |.  1___|.  |       |.      |.  1   |.|   | |.  1___|  ");
            Console.WriteLine("    |.  _   |.  |   `-|.  |-|.  __)_|.  |___    |. \\_/  |.  _   `-|.  |-|.  __)_  ");
            Console.WriteLine("    |:  |   |:  1   | |:  | |:  1   |:  1   |   |:  |   |:  |   | |:  | |:  1   |  ");
            Console.WriteLine("    |::.|:. |::.. . | |::.| |::.. . |::.. . |   |::.|:. |::.|:. | |::.| |::.. . |  ");
            Console.WriteLine("    `--- ---`-------' `---' `-------`-------'   `--- ---`--- ---' `---' `-------'  ");
            Console.WriteLine("   ================================================================================");
            Console.WriteLine();
        }
        static bool checkmenu(string option)
        {
            bool valid = false;
            if (option == "1" || option == "2" || option == "3")
            {
                valid = true;
            }
            return valid;
        }
        static bool isValidUsername(string username)
        {
            if (username.Length < 3 || username.Length > 15)
            {
                return false;
            }
            for (int i = 0; i < username.Length; i++)
            {
                if ((username[i] >= '0' && username[i] <= '9') || username[i] == ' ' || username[i] == ',')
                {
                    return false;
                }
            }
            return true;
        }
        static bool isValidPassword(string password)
        {
            return password.Length >= 6;
        }
        static bool isValidRole(string role)
        {
            return role == "Guest" || role == "Manager";
        }
        static string login(string name, string password)
        {
            if (!isValidUsername(name))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("    Invalid username! Please try again.");
                return "";
            }
            if (!isValidPassword(password))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("    Invalid password! Please try again.");
                return "";
            }
            for (int index = 0; index < usersCount; index++)
            {
                if (usernames[index] == name && passwords[index] == password)
                {
                    return roles[index];
                }
            }
            return "";
        }
        static bool signUp(string name, string password, string role)
        {
            if (!isValidUsername(name))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("    Invalid username! It must be 3-15 characters long and contain no numbers.");
                return false;
            }
            if (!isValidPassword(password))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("    Invalid password! It must be at least 6 characters long.");
                return false;
            }
            if (!isValidRole(role))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("    Invalid role! It must be either 'Guest' or 'Manager'.");
                return false;
            }
            for (int index = 0; index < usersCount; index++)
            {
                if (usernames[index] == name)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("    User already exists!");
                    return false;
                }
            }
            if (usersCount < MaxUsers)
            {
                usernames[usersCount] = name;
                passwords[usersCount] = password;
                roles[usersCount] = role;
                usersCount++;
                return true;
            }
            Console.WriteLine("   User limit reached. Cannot add more users.");
            return false;
        }
        static void clearscreen()
        {
            Console.ReadKey();
            header();
        }
        static void LoadUserData()
        {
            if (File.Exists(FilePath))
            {
                using (StreamReader reader = new StreamReader(FilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 3 && usersCount < MaxUsers)
                        {
                            usernames[usersCount] = parts[0];
                            passwords[usersCount] = parts[1];
                            roles[usersCount] = parts[2];
                            usersCount++;
                        }
                    }
                }
            }
        }
        static void SaveUserData()
        {
            using (StreamWriter writer = new StreamWriter(FilePath))
            {
                for (int i = 0; i < usersCount; i++)
                {
                    writer.WriteLine($"{usernames[i]},{passwords[i]},{roles[i]}");
                }
            }
        }
    }
}