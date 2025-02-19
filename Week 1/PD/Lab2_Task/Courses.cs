using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Lab2_Task;
using MySqlX.XDevAPI;

namespace Lab2_Task
{
    public class Courses
    {
        public string Course_ID { get; set; }
        public string Course_Name { get; set; }
        public string New_Course { get; set; }
        public Courses(string couserid, string name = null, string newcourse = null)
        {
            Course_ID = couserid;
            Course_Name = name;
            New_Course = newcourse;


        }
        public void AddCourse()
        {
            string query = $"INSERT INTO Course VALUES ('{Course_ID}', '{Course_Name}')";
            DatabaseHelper.Instance.Update(query);
        }
        public void EditCourse()
        {
            string query = "UPDATE Course SET Course_Name = '" + New_Course + "' WHERE Course_Name = '" + Course_Name + "';";

            DatabaseHelper.Instance.Update(query);
        }
        public void DeleteCourse()
        {
            string query = $"DELETE FROM Course WHERE Course_ID = '{Course_ID}'";
            DatabaseHelper.Instance.Update(query);
        }
        public void ShowAllCourse()
        {
            string query = "SELECT * FROM Course";
            var reader = DatabaseHelper.Instance.getData(query);

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    Console.WriteLine($"{reader["Course_ID"]} - {reader["Course_Name"]}");
                }
            }
            else
            {
                Console.WriteLine("No courses found.");
            }
        }

    }
}
