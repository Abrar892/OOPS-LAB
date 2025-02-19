using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Member
    {
        public string name;
        public string ID;
        public List<Book> boughtbooks = new List<Book>();
        public int booksbought;
        public float moneyInBank;
        public float amountspent;
        public Member(string name, string iD, float moneyInBank, float amountspent, int booksbought, List<Book> boughtbooks = null)
        {
            this.name = name;
            ID = iD;
            this.boughtbooks = boughtbooks;
            this.booksbought = booksbought;
            this.moneyInBank = moneyInBank;
            this.amountspent = amountspent;
        }
        public void showInfo()
        {
            Console.WriteLine("Name: {0}", this.name);
            Console.WriteLine("ID: {0}", this.ID);
            Console.WriteLine("Books bought: ");
            foreach (var i in this.boughtbooks)
            {
                Console.Write(i);
            }
            Console.WriteLine("Money in bank: {0}", this.moneyInBank);
            Console.WriteLine("Amount spent: {0}", this.amountspent);
        }
        public void setname(string name)
        {
            this.name = name;
        }
        public void setID(string ID)
        {
            this.ID = ID;
        }
        public void setnoOFbooksbought(int booksbought)
        {
            this.booksbought = booksbought;
        }
        public void setboughtbooks(List<Book> boughtbooks)
        {
            this.boughtbooks = boughtbooks;
        }
        public void setBankBalance(float price)
        {
            this.moneyInBank -= price;
        }
        public void setSpentamount(float price)
        {
            this.amountspent += price;
        }
        public bool namecheck(string name)
        {
            if (this.name == name)
            {
                return true;
            }
            else { return false; }
        }
        public bool idcheck(string id)
        {
            if (this.ID == id)
            {
                return true;
            }
            else { return false; }
        }
    }
}
