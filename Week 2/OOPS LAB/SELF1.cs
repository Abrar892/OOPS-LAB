using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projects
{

    internal class Program
    {
        public static void Main(string[] args)
        {
            Transaction t1 = new Transaction(1332, "MOBILE", 100F, "2004-12-23");
            Transaction t2 = new Transaction(t1);
            t1.ProductName = "ASAD";
            t1.amount = 65F;
            t2.ProductName = "ABRAR";
            t2.amount = 80F;
            Console.WriteLine("original");
            t1.display();
            Console.WriteLine("copy");
            t2.display();


        }
        public class Transaction
        {
            public int id;
            public string ProductName;
            public float amount;
            public string DATETIME;
            
            public Transaction(int iddd, string Product, float amou,string date)
            {
                id=iddd;
                ProductName=Product;
                amou = amount;
                DATETIME=date;

            }
            public Transaction(Transaction copuy)
            {
                id = copuy.id;
                ProductName = copuy.ProductName;
                amount = copuy.amount;
                DATETIME = copuy.DATETIME;
            }
            public void display()
            {
                Console.WriteLine(id);
                Console.WriteLine(ProductName);
                Console.WriteLine(amount);
                Console.WriteLine(DATETIME);

            }
        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}
