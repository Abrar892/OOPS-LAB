using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.cs
{
    public class User
    {
        public string Username;
        public string Password;
        public string Role;

        public User(string username, string password, string role)
        {
            Username = username;
            Password = password;
            Role = role;
        }

        public static bool IsValidUsername(string username)
        {
            if (username.Length < 3 || username.Length > 15)
                return false;

            foreach (char c in username)
            {
                if ((c >= '0' && c <= '9') || c == ' ' || c == ',')
                    return false;
            }
            return true;
        }

        public static bool IsValidPassword(string password)
        {
            return password.Length >= 6;
        }

        public static bool IsValidRole(string role)
        {
            return role == "Guest" || role == "Manager";
        }
    }
}