using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class StudentBL
{
    public string Name { get; set; }
    public int Age { get; set; }
    public float FSCMarks { get; set; }
    public float EcatMarks { get; set; }
    public float Merit { get; set; }
    public List<DegreeProgramBL> Preferences { get; set; }
    public List<SubjectBL> RegisteredSubjects { get; set; }

    public StudentBL(string name, int age, float fscMarks, float ecatMarks)
    {
        Name = name;
        Age = age;
        FSCMarks = fscMarks;
        EcatMarks = ecatMarks;
        Preferences = new List<DegreeProgramBL>();
        RegisteredSubjects = new List<SubjectBL>();
    }

    public void AddPreference(DegreeProgramBL program)
    {
        Preferences.Add(program);
    }

    public void RegisterSubject(SubjectBL subject)
    {
        RegisteredSubjects.Add(subject);
    }

    public int CalculateTotalCreditHours()
    {
        return RegisteredSubjects.Sum(s => s.CreditHours);
    }
}
}