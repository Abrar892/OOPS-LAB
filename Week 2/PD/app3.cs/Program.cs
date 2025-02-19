using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.AccessControl;

namespace App1.cs
{
    internal class Program
    {
        const int MaxUsers = 60;
        static int usersCount = 0;
        static int feedbackCount = 0;
        static int roomsCount = 0;

        static List<User> users = new List<User>();
        static List<Room1> rooms = new List<Room1>();
        static List<string> feedbacks = new List<string>();

        const string FilePath = "D:\\study\\2024-CS-59\\2nd semester\\Week 2\\OOPS LAB\\usersData.txt";

        static void Main(string[] args)
        {
            LoadUserData();
            LoadRoomData();
            const string managerUsername = "Abrar";
            const string managerPassword = "1234567";

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

                        if (signUp(name, password, role))
                        {
                            Console.WriteLine("   Signed Up Successfully");
                        }
                        else
                        {
                            Console.WriteLine("   Incorrect input...");
                        }

                        Console.Write("    Press any key to continue....");
                        clearscreen();
                        menuOption = mainMenu();
                    }
                    else if (menuOption == "1")
                    {
                        header();
                        string name, password;
                        Console.Write("    Enter your name: ");
                        name = Console.ReadLine();
                        Console.Write("    Enter your password: ");
                        password = Console.ReadLine();

                        string role = login(name, password);

                        if (role == "Manager" && name == managerUsername && password == managerPassword)
                        {
                            Console.WriteLine("   Press Any Key to Continue to Manager Interface..");
                            Console.WriteLine("   LOGIN SUCCESSFULLY!");
                            Console.ReadKey();
                            ManagerInterface();
                        }
                        else if (role == "Guest")
                        {
                            Console.WriteLine("   Press Any Key to Continue to Guest Interface..");
                            Console.WriteLine("   WELCOME TO HOTEL MATE");
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
            SaveRoomData();
            header();
            Console.Write("   Please enter any key to exit the app....");
            Console.ReadKey();
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
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Username == name && users[i].Password == password)
                {
                    return users[i].Role;
                }
            }
            return "";
        }

        static bool signUp(string name, string password, string role)
        {
            if (!isValidUsername(name))
            {
                Console.WriteLine("Invalid username!");
                return false;
            }
            if (!isValidPassword(password))
            {
                Console.WriteLine("Invalid password!");
                return false;
            }
            if (!isValidRole(role))
            {
                Console.WriteLine("Invalid role!");
                return false;
            }

            if (users.Any(u => u.Username == name))
            {
                Console.WriteLine("User already exists!");
                return false;
            }

            if (users.Count < MaxUsers)
            {
                users.Add(new User(name, password, role));
                return true;
            }

            Console.WriteLine("User limit reached.");
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
                        if (parts.Length == 3)
                        {
                            users.Add(new User(parts[0], parts[1], parts[2]));
                        }
                    }
                }
            }
        }


        static void SaveUserData()
        {
            using (StreamWriter writer = new StreamWriter(FilePath))
            {
                for (int i = 0; i < users.Count; i++)
                {
                    writer.WriteLine(users[i].Username + "," + users[i].Password + "," + users[i].Role);
                }
            }
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
      static void ManagerInterface()
        {
            header();
            string managerOption = ManagerMenu();
            while (managerOption != "7")
            {
                if (checkMmenu(managerOption))
                {
                    if (managerOption == "1")
                    {
                        all();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("   Press any key to continue to Manager Menu....");
                        clearscreen();
                        managerOption = ManagerMenu();
                    }
                    else if (managerOption == "2")
                    {

                        header();
                        Console.Write("   Enter Room Number: ");
                        string roomNumber = Console.ReadLine();
                        Console.Write("   Enter Room Type: ");
                        string roomType = Console.ReadLine();
                        Console.Write("   Enter Room Price: ");
                        float price = float.Parse(Console.ReadLine());
                        if (checkadd(roomNumber, price, roomType))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("  Room added successfully!...");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("  No space available or Room Number already exists...");
                        }
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("  Please enter any key to return to Manager Menu.....");
                        clearscreen();
                        managerOption = ManagerMenu();
                    }
                    else if (managerOption == "3")
                    {
                        header();
                        string eraseroom;
                        Console.Write("   Enter Room Number to remove: ");
                        eraseroom = Console.ReadLine();
                        if (checkremove(eraseroom))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("  Room removed successfully!");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("  Room not found!");
                        }
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("  Please enter any key to return to Manager Menu.....");
                        clearscreen();
                        managerOption = ManagerMenu();
                    }
                    else if (managerOption == "4")
                    {
                        string roomNumber;
                        Console.Write("   Enter Room Number: ");
                        roomNumber = Console.ReadLine();
                        string newType;
                        float newPrice;
                        Console.Write($"   Enter new Type of Room Number {roomNumber}: ");
                        newType = Console.ReadLine();
                        Console.Write($"   Enter new Type of Room Number {roomNumber}: ");
                        newPrice = float.Parse(Console.ReadLine());
                        if (updateRooms(newType, newPrice, roomNumber))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("   Successfully Updated the Room Details....");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("   Invalid Room Number....");
                        }
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("   Press any key to continue to Manager Menu....");
                        clearscreen();
                        managerOption = ManagerMenu();
                    }
                    else if (managerOption == "5")
                    {
                        updateHotel();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("   Press any key to continue to Manager Menu....");
                        clearscreen();
                        managerOption = ManagerMenu();
                    }
                    else if (managerOption == "6")
                    {
                        reviewFeedback();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("   Press any key to continue to Manager Menu....");
                        clearscreen();
                        managerOption = ManagerMenu();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("   Please enter option between 1-7..... ");
                    header();
                    managerOption = ManagerMenu();
                }
            }
            header();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  Please enter any key to return to Main Menu.....");
            clearscreen();
            mainMenu();
        }
       static bool checkMmenu(string option1)
        {
            bool valid = false;
            if (option1 == "1" || option1=="2" || option1=="3" || option1=="4" || option1=="5" || option1=="6" || option1 == "7")
            {
                valid = true;
            }
            return valid;
        }
        static bool checkadd(string newroomNumber, float newprice, string newroomtype)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if (rooms[i].RoomNumber == newroomNumber)
                {
                    return false;
                }
            }
            if (rooms.Count < MaxUsers)
            {
                rooms.Add(new Room1(newroomNumber, newroomtype, newprice));
                return true;
            }
            return false;
        }

        static bool checkremove(string eraseroom)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if (rooms[i].RoomNumber == eraseroom)
                {
                    rooms.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        static bool updateRooms(string newType, float newPrice, string roomNumber)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if (rooms[i].RoomNumber == roomNumber)
                {
                    rooms[i] = new Room1(roomNumber, newType, newPrice);
                    return true;
                }
            }
            return false;
        }
        static string ManagerMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  Select one of the following options.......");
            Console.WriteLine("   1. View All Bookings");
            Console.WriteLine("   2. Add Rooms");
            Console.WriteLine("   3. Remove Room");
            Console.WriteLine("   4. Update Room Details");
            Console.WriteLine("   5. Update Hotel Details");
            Console.WriteLine("   6. Review Guest's Feedback");
            Console.WriteLine("   7. Exit to the Main Menu");
            Console.WriteLine("");
            string option1;
            Console.WriteLine("   =========================================");
            Console.Write("    Enter your option: ");
            option1 = Console.ReadLine();
            return option1;
        }
        static void updateHotel()
        {
            header();
            Console.WriteLine("      ------------Update Events-----------");
            Console.Write("       Enter the number of events to update: ");
            int eventCount = int.Parse(Console.ReadLine()); // Assuming user inputs a number.

            if (eventCount > 0 && eventCount <= 20)
            {
                for (int i = 0; i < eventCount; i++)
                {
                    Console.Write("   Enter event name: ");
                    string eventName = Console.ReadLine();
                    Console.Write("   Enter event Day: ");
                    string eventDay = Console.ReadLine();

                    Room1.AddEvent(eventName, eventDay);  // Adding event using Room1 class method
                }
                Console.WriteLine("   Hotel events details updated successfully!");
            }
            else
            {
                Console.WriteLine("  Please enter a valid number of events...");
            }
        }

        static void all()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("   =========================================");
            Console.WriteLine("          All Current Bookings");
            Console.WriteLine("   =========================================");
            Console.WriteLine("");
            Console.WriteLine("   Room No\tGuest Name\tNumber of Nights\tTotal Amount");
            bool bookingsfound = false;
            for (int i = 0; i < rooms.Count; i++)
            {
                Console.WriteLine($"{rooms[i].RoomNumber}\t{rooms[i].RoomType}\t{rooms[i].Price}");
              bookingsfound = true;
            }
            if (!bookingsfound)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("  ----------------No Bookings--------------");
            }
            Console.WriteLine("");
            Console.WriteLine("   =========================================");
        }
        static void reviewFeedback()
        {
            header();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   Guest Feedback");
            Console.WriteLine("   ------------------------------------------");
            if (feedbacks.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No feedback available.");
            }
            else
            {
                for (int i = 0; i < feedbacks.Count; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"     {feedbacks[i]}");
                }
            }
            Console.WriteLine("   ------------------------------------------");
        }
        static void LoadRoomData()
        {
            const string roomFilePath = "D:\\study\\2024-CS-59\\2nd semester\\Week 2\\OOPS LAB\\roomsData.txt";
            if (File.Exists(roomFilePath))
            {
                using (StreamReader reader = new StreamReader(roomFilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 3)
                        {
                            rooms.Add(new Room1(parts[0], parts[1], float.Parse(parts[2])));
                        }
                    }
                }
            }
        }
        static void SaveRoomData()
        {
            const string roomFilePath = "D:\\study\\2024-CS-59\\2nd semester\\Week 2\\OOPS LAB\\roomsData.txt";
            using (StreamWriter writer = new StreamWriter(roomFilePath))
            {
                for (int i = 0; i < rooms.Count; i++)
                {
                    writer.WriteLine($"{rooms[i].RoomNumber},{rooms[i].RoomType},{rooms[i].Price}");
                }
            }
        }
    }
}