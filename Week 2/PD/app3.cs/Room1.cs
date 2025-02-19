using System;
using System.Collections.Generic;

namespace App1.cs
{
    public class Room1
    {
        public string RoomNumber { get; private set; }
        public string RoomType { get; private set; }
        public float Price { get; private set; }

        public static List<string> EventNames = new List<string>();
        public static List<string> EventDays = new List<string>();

        public Room1(string roomNumber, string roomType, float price)
        {
            RoomNumber = roomNumber;
            RoomType = roomType;
            Price = price;
        }
        public static void AddEvent(string eventName, string eventDay)
        {
            EventNames.Add(eventName);
            EventDays.Add(eventDay);
        }

        public static void UpdateEvent(int eventIndex, string eventName, string eventDay)
        {
            if (eventIndex >= 0 && eventIndex < EventNames.Count)
            {
                EventNames[eventIndex] = eventName;
                EventDays[eventIndex] = eventDay;
                Console.WriteLine("Event updated successfully.");
            }
            else
            {
                Console.WriteLine("Invalid event index.");
            }
        }
    }
}