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
    public class Attendance
    {
        public string StudentRegNo { get; set; }
        public string Course_ID { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Status { get; set; }

        public Attendance(string studentRegNo, string courseId, bool status)
        {
            StudentRegNo = studentRegNo;
            Course_ID = courseId;
            TimeStamp = DateTime.Now;
            Status = status;
        }

        // Take Attendance (Insert Record)
        public void RecordAttendance()
        {
            string query = $"INSERT INTO Attendance (StudentRegNo, Course_ID, TimeStamp, Status) VALUES ('{StudentRegNo}', '{Course_ID}', '{TimeStamp:yyyy-MM-dd HH:mm:ss}', {Status});";
            DatabaseHelper.Instance.Update(query);
        }


        public void EditAttendance(DateTime newTimeStamp, bool newStatus)
        {
            string query = $"UPDATE Attendance SET TimeStamp = '{newTimeStamp:yyyy-MM-dd HH:mm:ss}', Status = {newStatus} WHERE StudentRegNo = '{StudentRegNo}' AND Course_ID = '{Course_ID}' AND TimeStamp = '{TimeStamp:yyyy-MM-dd HH:mm:ss}';";
            DatabaseHelper.Instance.Update(query);
        }


        public void ViewAttendance()
        {
            string query = $"SELECT * FROM Attendance WHERE StudentRegNo = '{StudentRegNo}' AND Course_ID = '{Course_ID}';";
            var reader = DatabaseHelper.Instance.getData(query);

            if (reader.HasRows)
            {
                Console.WriteLine($"Attendance for StudentRegNo: {StudentRegNo}, Course_ID: {Course_ID}");
                while (reader.Read())
                {
                    string time = reader["TimeStamp"].ToString();
                    string status = (bool)reader["Status"] ? "Present" : "Absent";
                    Console.WriteLine($"Date: {time}, Status: {status}");
                }
            }
            else
            {
                Console.WriteLine($"No attendance records found for StudentRegNo: {StudentRegNo}, Course_ID: {Course_ID}");
            }
        }
    }
}