using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SignUpSignInApp
{
    // MUser class with three attributes
    class MUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        // Parameterized constructor to initialize the user
        public MUser(string username, string password, string role)
        {
            Username = username;
            Password = password;
            Role = role;
        }

        // Display user information (for debugging or admin purposes)
        public void Display()
        {
            Console.WriteLine($"Username: {Username}, Role: {Role}");
        }

        // Static method to load users from the file
        public static List<MUser> LoadUsers(string filePath)
        {
            List<MUser> users = new List<MUser>();
            if (!File.Exists(filePath))
            {
                // If file does not exist, return an empty list.
                return users;
            }

            try
            {
                // Each line should have the format: username password role
                foreach (string line in File.ReadAllLines(filePath))
                {
                    // Skip empty lines
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    string[] parts = line.Split(' ');
                    if (parts.Length >= 3)
                    {
                        string username = parts[0];
                        string password = parts[1];
                        // In case role contains spaces, join the remaining parts.
                        string role = string.Join(" ", parts.Skip(2));
                        users.Add(new MUser(username, password, role));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading file: " + ex.Message);
            }
            return users;
        }
    }

    class Program
    {
        // Path to the users file
        static string usersFile = "users.txt";

        // Sign up method: takes user input and appends a new user record to the file
        static void SignUp()
        {
            Console.Write("Enter new Username: ");
            string username = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            Console.Write("Enter Role: ");
            string role = Console.ReadLine();

            // Format the record as: username password role
            string record = $"{username} {password} {role}";
            try
            {
                File.AppendAllText(usersFile, record + Environment.NewLine);
                Console.WriteLine("User registered successfully.\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving user: " + ex.Message + "\n");
            }
        }

        // Sign in method: loads users from file and checks if credentials match
        static void SignIn()
        {
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            List<MUser> users = MUser.LoadUsers(usersFile);

            // Find a user matching the given username and password
            MUser foundUser = users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (foundUser != null)
            {
                Console.WriteLine("Login successful!");
                Console.WriteLine($"Welcome, {foundUser.Username}. Your role is {foundUser.Role}.\n");
            }
            else
            {
                Console.WriteLine("Invalid username or password.\n");
            }
        }

        // Main method with a menu-driven loop using if/else statements
        static void Main(string[] args)
        {
            int choice = -1;
            while (choice != 0)
            {
                Console.WriteLine("==== Sign Up / Sign In Application ====");
                Console.WriteLine("1. Sign Up");
                Console.WriteLine("2. Sign In");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.\n");
                    continue;
                }
                Console.WriteLine();

                if (choice == 1)
                {
                    SignUp();
                }
                else if (choice == 2)
                {
                    SignIn();
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
