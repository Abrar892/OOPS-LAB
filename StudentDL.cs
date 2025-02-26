using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class StudentDL
{
    public static List<StudentBL> Students = new List<StudentBL>();

    public static void AddStudent(StudentBL student)
    {
        Students.Add(student);
    }

    public static bool IsStudentExists(string name)
    {
        return Students.Any(s => s.Name == name);
    }
}
}