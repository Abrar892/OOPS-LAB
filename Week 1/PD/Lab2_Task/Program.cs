using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab2_Task
{
    public class Program
    {
        static void Main(string[] args)
        {
            Application();
        }
        public static void Application()
        {
            string menuOption = Menu();
            while (menuOption != "5")
            {
                if (menuOption == "1")
                {
                    Studentinterface();
                }
                else if (menuOption == "2")
                {
                    Courseinterface();
                }
                else if (menuOption == "3")
                {
                    Enrollementinterface();
                }
                else if (menuOption != "4")
                {
                    Attendanceinterface();
                }
                else
                {
                    Console.WriteLine("INVALID CHOICE!");
                    Console.Write("Please Select Option (1-5)");
                    clearscreen();
                    menuOption = Menu();
                }
            }
            header();
            Console.Write("Please Press Any Key to exit the App.... ");
            Console.ReadKey();
        }
        public static string Menu()
        {
            header();
            Console.WriteLine("-------------MENU-------------");
            Console.WriteLine("1. Student Management");
            Console.WriteLine("2. Course Management");
            Console.WriteLine("3. Registration Management");
            Console.WriteLine("4. Attendance Management");
            Console.WriteLine("5. Exit");
            Console.WriteLine("===============================");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();
            return choice;
        }
        public static void clearscreen()
        {
            Console.ReadKey();
            header();
        }
        public static void header()
        {
            Console.Clear();
            Console.WriteLine("=============================================");
            Console.WriteLine("*             MANAGMENT SYSYTEM             *");
            Console.WriteLine("=============================================");
            Console.WriteLine("");
        }
        public static string Coursemenu()
        {
            header();
            Console.WriteLine("--------COURSE MANAGEMENT---------");
            Console.WriteLine("   1. Add Course");
            Console.WriteLine("   2. Edit Course");
            Console.WriteLine("   3. Delete Course");
            Console.WriteLine("   4. Show All Courses");
            Console.WriteLine("   5. Back to Main Menu");
            Console.Write("   Enter your choice: ");
            string choice = Console.ReadLine();
            return choice;
        }
        public static string Studentmenu()
        {
            header();
            Console.WriteLine("---------STUDENT MANAGEMENT----------");
            Console.WriteLine("1. Add a New Student");
            Console.WriteLine("2. Edit a Student");
            Console.WriteLine("3. Delete a Student");
            Console.WriteLine("4. Search a Student");
            Console.WriteLine("5. Show all Students");
            Console.WriteLine("6. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();
            return choice;
        }
        public static string Registermenu()
        {
            header();
            Console.WriteLine("----------REGISTRATION MANAGEMENT------------");
            Console.WriteLine("   1. Register Student for a Course");
            Console.WriteLine("   2. Unregister Student from a Course");
            Console.WriteLine("   3. Show All Registrations");
            Console.WriteLine("   4. Back to Main Menu");
            Console.Write("   Enter your choice: ");
            string choice = Console.ReadLine();
            return choice;
        }
        public static string Attendancemenu()
        {
            header();
            Console.WriteLine("----------ATTENDANCE MANAGEMENT-------------");
            Console.WriteLine("   1. Record Attendance");
            Console.WriteLine("   2. Edit Attendance");
            Console.WriteLine("   3. View Attendance");
            Console.WriteLine("   4. Back to Main Menu");
            Console.Write("   Enter your choice: ");
            string choice = Console.ReadLine();
            return choice;
        }
        public static void Studentinterface()
        {
            string Course_ID, regNo, department, address;
            string session;
            string newname;
            Student student;
            header();
            string studentOption = Studentmenu();
            while (studentOption != "6")
            {
                if (checkstudent(studentOption))
                {
                    header();
                    if (studentOption == "1")
                    {
                        Console.WriteLine("Enter RegNo: ");
                        regNo = Console.ReadLine();
                        Console.WriteLine("Enter NAME : ");
                        Course_ID = Console.ReadLine();
                        Console.WriteLine("Enter Department: ");
                        department = Console.ReadLine();
                        Console.WriteLine("Enter Session: ");
                        session = Console.ReadLine();
                        Console.WriteLine("Enter Address: ");
                        address = Console.ReadLine();

                        student = new Student(regNo, Course_ID, department, session, address);
                        student.AddStudent();
                    }
                    else if (studentOption == "2")
                    {
                        Console.WriteLine("Enter Name to edit it: ");
                        Course_ID = Console.ReadLine();
                        Console.WriteLine("Enter  NEW Name: ");
                        newname = Console.ReadLine();

                        student = new Student(null, Course_ID, null, null, null, newname);
                        student.EditStudent();
                    }
                    else if (studentOption == "3")
                    {
                        Console.WriteLine("Enter RegNo: ");
                        regNo = Console.ReadLine();

                        student = new Student(regNo);
                        student.DeleteStudent();
                    }
                    else if (studentOption == "4")
                    {
                        Console.WriteLine("Enter RegNo: ");
                        regNo = Console.ReadLine();

                        student = new Student(regNo);
                        student.SearchStudent();
                    }
                    else if (studentOption == "5")
                    {
                        student = new Student(null);
                        student.ShowStudents();
                        Console.ReadKey();

                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice");
                    Console.WriteLine("Please Enter Option (1-6)");
                    clearscreen();
                    studentOption = Studentmenu();
                }
            }
            header();
            Console.Write("Please Press Any Key TO return Main Menu.... ");
            Console.ReadKey();
            Application();
        }
        public static void Courseinterface()
        {
            string Course_ID;
            string Course_Name;
            string New_course;
            header();
            string option = Coursemenu();
            while (option != "5")
            {
                if (checkcourse(option))
                {
                    header();
                    if (option == "1")
                    {
                        Console.Write("Enter Course ID: ");
                        Course_ID = Console.ReadLine();
                        Console.Write("Enter Course Name: ");
                        Course_Name = Console.ReadLine();
                        Courses cour = new Courses(Course_ID, Course_Name);
                        cour.AddCourse();
                    }
                    else if (option == "2")
                    {
                        Console.Write("Enter Course To Edit: ");
                        Course_ID = Console.ReadLine();
                        Console.Write("Enter Course New Name: ");
                        New_course = Console.ReadLine();
                        Courses cour = new Courses(null, Course_ID, New_course);
                        cour.EditCourse();
                    }
                    else if (option == "3")
                    {
                        Console.Write("Enter Course ID: ");
                        Course_ID = Console.ReadLine();
                        Courses cour = new Courses(Course_ID);
                        cour.DeleteCourse();

                    }
                    else if (option == "4")
                    {
                        Courses cour = new Courses(null);
                        cour.ShowAllCourse();
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("WRONG OPTION TRY AGAIN");
                    clearscreen();
                    option = Coursemenu();
                }
            }
            header();
            Console.Write("Please Press Any Key to return Main Menu.... ");
            Console.ReadKey();
            Application();
        }
        public static void Attendanceinterface()
        {
            header();
            string option = Attendancemenu();
            while (option != "4")
            {
                if (checkmenu(option))
                {
                    header();
                    if (option == "1")
                    {
                        Console.Write("   Enter Course ID: ");
                        string courseId = Console.ReadLine();
                        Console.Write("   Enter Student Registration Number: ");
                        string regNo = Console.ReadLine();
                        Console.Write("   Enter Attendance Status (1 for Present, 0 for Absent): ");
                        bool status = Console.ReadLine() == "1";
                        Attendance attendance = new Attendance(regNo, courseId, status);
                        attendance.RecordAttendance();
                    }
                    else if (option == "2")
                    {
                        Console.Write("   Enter Course ID: ");
                        string courseId = Console.ReadLine();
                        Console.Write("   Enter Student Registration Number: ");
                        string regNo = Console.ReadLine();
                        Console.Write("   Enter Original TimeStamp (yyyy-MM-dd HH:mm:ss): ");
                        DateTime originalTime = DateTime.Parse(Console.ReadLine());
                        Console.Write("   Enter New TimeStamp (yyyy-MM-dd HH:mm:ss): ");
                        DateTime newTime = DateTime.Parse(Console.ReadLine());
                        Console.Write("   Enter New Attendance Status (1 for Present, 0 for Absent): ");
                        bool newStatus = Console.ReadLine() == "1";
                        Attendance attendance = new Attendance(regNo, courseId, true) { TimeStamp = originalTime };
                        attendance.EditAttendance(newTime, newStatus);
                    }
                    else if (option == "3")
                    {
                        Console.Write("   Enter Course ID: ");
                        string courseId = Console.ReadLine();
                        Console.Write("   Enter Student Registration Number: ");
                        string regNo = Console.ReadLine();
                        Attendance attendance = new Attendance(regNo, courseId, true);
                        attendance.ViewAttendance();
                    }
                }
                else
                {
                    Console.WriteLine("WRONG OPTION TRY AGAIN");
                    clearscreen();
                    option = Attendancemenu();
                }
            }
            header();
            Console.Write("Please Press Any Key to return Main Menu.... ");
            Console.ReadKey();
            Application();
        }
        public static void Enrollementinterface()
        {
            header();
            string option = Registermenu();
            while (option != "4")
            {
                if (checkmenu(option))
                {
                    header();
                    if (option == "1")
                    {
                        Console.Write("   Enter Course ID: ");
                        string courseId = Console.ReadLine();
                        Console.Write("   Enter Student Registration Number: ");
                        string regNo = Console.ReadLine();
                        Enrollments enrollment = new Enrollments(regNo, courseId);
                        enrollment.RegisterCourse();
                    }
                    else if (option == "2")
                    {
                        Console.Write("   Enter Course ID: ");
                        string courseId = Console.ReadLine();
                        Console.Write("   Enter Student Registration Number: ");
                        string regNo = Console.ReadLine();
                        Enrollments enrollment = new Enrollments(regNo, courseId);
                        enrollment.UnregisterCourse();
                    }
                    else if (option == "3")
                    {
                        Enrollments enrollment = new Enrollments(null, null);
                        enrollment.ViewRegisteredStudents();
                    }
                }
                else
                {
                    Console.WriteLine("WRONG OPTION TRY AGAIN");
                    clearscreen();
                    option = Registermenu();
                }
            }
            header();
            Console.Write("Please Press Any Key to return Main Menu.... ");
            Console.ReadKey();
            Application();
        }
        public static bool checkstudent(string option)
        {
            bool valid = false;
            if (option == "1" || option == "2" || option == "3" || option =="4" || option=="5" || option=="6")
            {
                valid = true;
            }
            return valid;
        }

        public static bool checkcourse(string option)
        {
            bool valid = false;
            if (option == "1" || option == "2" || option == "3" || option=="4" || option=="5")
            {
                valid = true;
            }
            return valid;
        }
        public static bool checkmenu(string option)
        {
            bool valid = false;
            if (option == "1" || option == "2" || option == "3" || option == "4")
            {
                valid = true;
            }
            return valid;
        }
    }
}
