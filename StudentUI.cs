using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class StudentUI
{
    public static StudentBL TakeStudentInput()
    {
        Console.Write("Enter Student Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Student Age: ");
        int age = int.Parse(Console.ReadLine());
        Console.Write("Enter Student FSC Marks: ");
        float fscMarks = float.Parse(Console.ReadLine());
        Console.Write("Enter Student Ecat Marks: ");
        float ecatMarks = float.Parse(Console.ReadLine());

        StudentBL student = new StudentBL(name, age, fscMarks, ecatMarks);

        Console.Write("Enter How many Preferences to Enter: ");
        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            Console.Write("Enter Degree Program Name: ");
            string programName = Console.ReadLine();
            DegreeProgramBL program = DegreeProgramDL.DegreePrograms.FirstOrDefault(p => p.Title == programName);
            if (program != null)
            {
                student.AddPreference(program);
            }
        }

        return student;
    }

    public static void ViewStudents()
    {
        for (int i=0;i< StudentDL.Students.Count; i++)
        {
            StudentBL student = StudentDL.Students[i];
            Console.WriteLine($"Name: {student.Name}, Age: {student.Age}, FSC Marks: {student.FSCMarks}, Ecat Marks: {student.EcatMarks}");
        }
    }
}
}