using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_Task
{
    public class Student
    {
        public string RegistrationNumber { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Session { get; set; }
        public string Address { get; set; }

        public Student(string regNo, string name = null, string department = null, string session = null, string address = null, string newname = null)
        {
            RegistrationNumber = regNo;
            Name = name;
            Department = department;
            Session = session;
            Address = address;
        }

        public void AddStudent()
        {
            string query = $"INSERT INTO Student VALUES ('{RegistrationNumber}', '{Name}', '{Department}', {Session}, '{Address}')";
            DatabaseHelper.Instance.Update(query);
        }

        public void EditStudent()
        {
            string query = $"UPDATE Student SET Name = '{Name}', WHERE RegNo = '{RegistrationNumber}'";
            DatabaseHelper.Instance.Update(query);
        }

        public void DeleteStudent()
        {
            string query = $"DELETE FROM Student WHERE RegNo = '{RegistrationNumber}'";
            DatabaseHelper.Instance.Update(query);
        }

        public void SearchStudent()
        {
            string query = $"SELECT * FROM Student WHERE RegNo = '{RegistrationNumber}'";
            var reader = DatabaseHelper.Instance.getData(query);
            if (reader.Read())
            {
                Console.WriteLine($"{reader["RegNo"]} - {reader["Name"]} - {reader["Department"]} - {reader["Session"]} - {reader["Cgpa"]} - {reader["Address"]}");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        public void ShowStudents()
        {
            string query = "SELECT * FROM Student";
            var reader = DatabaseHelper.Instance.getData(query);
            while (reader.Read())
            {
                Console.WriteLine($"{reader["RegNo"]} - {reader["Name"]} - {reader["Department"]} - {reader["Session"]} - {reader["Cgpa"]} - {reader["Address"]}");
            }
        }
    }
}

