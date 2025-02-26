using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace project
{
    public class DegreeProgramBL
{
    public string Title { get; set; }
    public string Duration { get; set; }
    public int Seats { get; set; }
    public List<SubjectBL> Subjects { get; set; }

    public DegreeProgramBL(string title, string duration, int seats)
    {
        Title = title;
        Duration = duration;
        Seats = seats;
        Subjects = new List<SubjectBL>();
    }

    public void AddSubject(SubjectBL subject)
    {
        Subjects.Add(subject);
    }

    public int CalculateCreditHours()
    {
        return Subjects.Sum(s => s.CreditHours);
    }
}
}