using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace project
{
    public class SubjectUI
{
    public static SubjectBL TakeSubjectInput()
    {
        Console.Write("Enter Subject Code: ");
        string code = Console.ReadLine();
        Console.Write("Enter Subject Type: ");
        string type = Console.ReadLine();
        Console.Write("Enter Subject Credit Hours: ");
        int creditHours = int.Parse(Console.ReadLine());
        Console.Write("Enter Subject Fees: ");
        int fees = int.Parse(Console.ReadLine());

        return new SubjectBL(code, type, creditHours, fees);
    }

        public static void ViewSubjects()
     {
            for (int i = 0; i < SubjectDL.Subjects.Count; i++)
          {
                SubjectBL subject = SubjectDL.Subjects[i];
                Console.WriteLine($"Code: {subject.Code}, Type: {subject.Type}, Credit Hours: {subject.CreditHours}, Fees: {subject.Fees}");
           }
     }
  }
}