using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class DegreeProgramDL
{
    public static List<DegreeProgramBL> DegreePrograms = new List<DegreeProgramBL>();

    public static void AddDegreeProgram(DegreeProgramBL program)
    {
        DegreePrograms.Add(program);
    }

    public static bool IsProgramExists(string title)
    {
        return DegreePrograms.Any(p => p.Title == title);
    }
}
}