using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class SubjectDL
{
    public static List<SubjectBL> Subjects = new List<SubjectBL>();

    public static void AddSubject(SubjectBL subject)
    {
        Subjects.Add(subject);
    }

    public static bool IsSubjectExists(string code)
    {
        return Subjects.Any(s => s.Code == code);
    }
}
}