using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
   public class SubjectBL
{
    public string Code { get; set; }
    public string Type { get; set; }
    public int CreditHours { get; set; }
    public int Fees { get; set; }

    public SubjectBL(string code, string type, int creditHours, int fees)
    {
        Code = code;
        Type = type;
        CreditHours = creditHours;
        Fees = fees;
    }
} 
}