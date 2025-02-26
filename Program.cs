using System;
namespace project
 {
public class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            ConsoleUtility.Header("UAMS");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Add Degree Program");
            Console.WriteLine("3. Generate Merit");
            Console.WriteLine("4. View Registered Students");
            Console.WriteLine("5. View Students of a Specific Program");
            Console.WriteLine("6. Register Subjects for a Specific Student");
            Console.WriteLine("7. Calculate Fees for all Registered Students");
            Console.WriteLine("8. Exit");
            Console.Write("Enter Option: ");
            int option = int.Parse(Console.ReadLine());

            if (option == 1)
            {
                StudentBL student = StudentUI.TakeStudentInput();
                StudentDL.AddStudent(student);
            }
            else if (option == 2)
            {
                DegreeProgramBL program = DegreeProgramUI.TakeDegreeProgramInput();
                DegreeProgramDL.AddDegreeProgram(program);
            }
            else if (option == 3)
            {
                // Generate Merit Logic
            }
            else if (option == 4)
            {
                StudentUI.ViewStudents();
            }
            else if (option == 5)
            {
                // View Students of a Specific Program Logic
            }
            else if (option == 6)
            {
                // Register Subjects for a Specific Student Logic
            }
            else if (option == 7)
            {
                // Calculate Fees for all Registered Students Logic
            }
            else if (option == 8)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Invalid Option!");
            }

            ConsoleUtility.PressAnyKey();
        }
    }
}
}