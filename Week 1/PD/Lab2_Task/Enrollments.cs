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
    public class Enrollments
    {
        public string StudentRegNo { get; set; }
        public string Course_ID { get; set; }

        public Enrollments(string studentRegNo, string courseId)
        {
            StudentRegNo = studentRegNo;
            Course_ID = courseId;
        }

        // Method to register a student for a course
        public void RegisterCourse()
        {
            string query = $"INSERT INTO Enrollments (StudentRegNo, Course_ID) VALUES ('{StudentRegNo}', '{Course_ID}')";
            DatabaseHelper.Instance.Update(query);
            Console.WriteLine("Course registered successfully.");
        }

        // Method to unregister a student from a course
        public void UnregisterCourse()
        {
            string query = $"DELETE FROM Enrollments WHERE StudentRegNo = '{StudentRegNo}' AND Course_ID = '{Course_ID}'";
            DatabaseHelper.Instance.Update(query);
            Console.WriteLine("Course unregistered successfully.");
        }

        // Method to view all registered students with their courses
        public void ViewRegisteredStudents()
        {
            string query = @"
                SELECT s.RegistrationNumber, s.Name, c.Course_ID, c.Course_Name 
                FROM Enrollments e
                INNER JOIN Student s ON e.StudentRegNo = s.RegistrationNumber
                INNER JOIN Course c ON e.Course_ID = c.Course_ID";

            var reader = DatabaseHelper.Instance.getData(query);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["RegistrationNumber"]} - {reader["Name"]} - {reader["Course_ID"]} - {reader["Course_Name"]}");
                }
            }
            else
            {
                Console.WriteLine("No registered students found.");
            }
        }
    }
}