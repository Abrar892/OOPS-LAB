using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace App1.cs
{
    public class Manager
    {
        private const string EntityFilePath = "D:\\study\\2024-CS-59\\2nd semester\\Week 1\\OOPS LAB\\entityData.txt";
        private List<string> rooms = new List<string>();

        public Manager()
        {
            LoadEntityData();
        }

        public void AddRoom(string roomNumber, string roomType, float price)
        {
            if (!rooms.Contains(roomNumber))
            {
                rooms.Add($"{roomNumber},{roomType},{price}");
                Console.WriteLine("Room added successfully!");
            }
            else
            {
                Console.WriteLine("Room number already exists!");
            }
            SaveEntityData();
        }

        public void RemoveRoom(string roomNumber)
        {
            if (rooms.RemoveAll(room => room.StartsWith(roomNumber + ",")) > 0)
            {
                Console.WriteLine("Room removed successfully!");
            }
            else
            {
                Console.WriteLine("Room not found!");
            }
            SaveEntityData();
        }

        public void UpdateRoom(string roomNumber, string newType, float newPrice)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if (rooms[i].StartsWith(roomNumber + ","))
                {
                    rooms[i] = $"{roomNumber},{newType},{newPrice}";
                    Console.WriteLine("Room updated successfully!");
                    SaveEntityData();
                    return;
                }
            }
            Console.WriteLine("Room not found!");
        }

        public void ViewAllRooms()
        {
            if (rooms.Count == 0)
            {
                Console.WriteLine("No rooms available.");
                return;
            }

            Console.WriteLine("Rooms:");
            foreach (var room in rooms)
            {
                Console.WriteLine(room);
            }
        }

        private void LoadEntityData()
        {
            if (File.Exists(EntityFilePath))
            {
                rooms = new List<string>(File.ReadAllLines(EntityFilePath));
            }
        }

        private void SaveEntityData()
        {
            File.WriteAllLines(EntityFilePath, rooms);
        }
    }
}
