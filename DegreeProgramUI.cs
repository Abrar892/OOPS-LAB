using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class DegreeProgramUI
{
    public static DegreeProgramBL TakeDegreeProgramInput()
    {
        Console.Write("Enter Degree Name: ");
        string title = Console.ReadLine();
        Console.Write("Enter Degree Duration: ");
        string duration = Console.ReadLine();
        Console.Write("Enter Seats for Degree: ");
        int seats = int.Parse(Console.ReadLine());

        DegreeProgramBL program = new DegreeProgramBL(title, duration, seats);

        Console.Write("Enter How many Subjects to Enter: ");
        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            SubjectBL subject = SubjectUI.TakeSubjectInput();
            program.AddSubject(subject);
        }

        return program;
    }

    public static void ViewDegreePrograms()
    {
        for (int i=0; i< DegreeProgramDL.DegreePrograms.Count,i++)
        {
            DegreeProgramBL program = DegreeProgramDL.DegreePrograms[i];
            Console.WriteLine($"Title: {program.Title}, Duration: {program.Duration}, Seats: {program.Seats}");
            SubjectUI.ViewSubjects();
        }
    }
}
}