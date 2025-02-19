using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagementSystem
{
   
    class Student
    {
        public string Name { get; set; }
        public float MatricMarks { get; set; }
        public float FscMarks { get; set; }
        public float EcatMarks { get; set; }
        public float Aggregate { get; private set; }

        public Student(string name, float matricMarks, float fscMarks, float ecatMarks)
        {
            Name = name;
            MatricMarks = matricMarks;
            FscMarks = fscMarks;
            EcatMarks = ecatMarks;
            CalculateAggregate();
        }
    public void CalculateAggregate()
        {
            Aggregate = (MatricMarks * 0.1f) + (FscMarks * 0.4f) + (EcatMarks * 0.5f);
        }

        
        public void Display()
        {
            Console.WriteLine($"Name: {Name}, Aggregate: {Aggregate:F2}");
        }
    }

    class Program
    {
       

        static List<Student> students = new List<Student>();

        
        static void AddStudent()
        {
            Console.Write("Enter Student Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Matric Marks: ");
            float matric = float.Parse(Console.ReadLine());

            Console.Write("Enter FSC Marks: ");
            float fsc = float.Parse(Console.ReadLine());

            Console.Write("Enter ECAT Marks: ");
            float ecat = float.Parse(Console.ReadLine());

         
            Student student = new Student(name, matric, fsc, ecat);
            students.Add(student);
            Console.WriteLine("Student added successfully.\n");
        }


        static void ShowStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students available.\n");
                return;
            }

            Console.WriteLine("Student Details:");
            foreach (var student in students)
            {
                student.Display();
            }
            Console.WriteLine();
        }

         static void CalculateAggregateForAllStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students available to calculate aggregate.\n");
                return;
            }
            float totalAggregate = students.Sum(s => s.Aggregate);
            float overallAverage = totalAggregate / students.Count;
            Console.WriteLine($"The overall average aggregate is: {overallAverage:F2}\n");
        }
        static void TopStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students available.\n");
                return;
            }

           
            var topStudents = students.OrderByDescending(s => s.Aggregate).Take(3);
            Console.WriteLine("Top Students:");
            foreach (var student in topStudents)
            {
                student.Display();
            }
            Console.WriteLine();
        }

   
        static void Main(string[] args)
        {
            int choice = -1;
            while (choice != 0)
            {
                Console.WriteLine("==== Student Management System ====");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Show Students");
                Console.WriteLine("3. Calculate Aggregate");
                Console.WriteLine("4. Top Students");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if (choice == 1)
                {
                    AddStudent();
                }
                else if (choice == 2)
                {
                    ShowStudents();
                }
                else if (choice == 3)
                {
                    CalculateAggregateForAllStudents();
                }
                else if (choice == 4)
                {
                    TopStudents();
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
