using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ATM atm=new ATM(100);
            while (true)
            {
                Console.WriteLine("\nATM Menu:");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Check Balance");
                Console.WriteLine("4. Transaction History");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    Console.WriteLine("ENTER AMOUNT TO DEPSITE :");
                    double amount = Convert.ToDouble(Console.ReadLine());
                    atm.deposite(amount);

                }
                else if (choice == 2)
                {
                    Console.WriteLine("ENTER WITHDRAM AMOUNT :");
                    double amount = Convert.ToDouble(Console.ReadLine());
                    atm.withdraw(amount);
                }
                else if (choice == 3)
                {
                    Console.WriteLine($"Current Balance is {atm.checkbalace()}");
                }
                else if (choice == 4)
                {
                    atm.treanstionhistroy();

                }



            }


        }

        public class ATM
        {
            public List<string> transactionhistryo;
            public double income;
            public ATM(double balaceinitization)
            {

                income = balaceinitization;
                transactionhistryo = new List<string>();
            }
            public void deposite(double amount)
            {
                if (amount > 0)
                {
                    income += amount;
                    transactionhistryo.Add($"Deposite :{amount} ");
                    Console.WriteLine($"Amount Deposite :{amount}");
                }
                else { Console.WriteLine("ERROR"); }


                
            }
            public void withdraw(double amount)
            {
                if (amount < income)
                {
                    income -= amount;
                    Console.WriteLine($"WIthdraw : {amount}");
                    transactionhistryo.Add($"Withdraw Succseefully{amount} ");
                }
                else { Console.WriteLine("Error"); }

            }
            public void treanstionhistroy()
            {
                foreach (string trans in transactionhistryo)
                {
                    Console.WriteLine(trans);
                }

            }
           public double checkbalace()
            {
                return income;
            }
        }


    }
}
