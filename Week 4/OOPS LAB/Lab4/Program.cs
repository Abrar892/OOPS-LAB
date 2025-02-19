using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

namespace Lab4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Declaration
            string mainOPtion = "";
            string mainInterOPtion = "";
            string memberOption = "";
            Book[] book = new Book[100];
            List<Member> members = new List<Member>();
            int bookCount = 0;
            int memberCount = 0;
            int indexofbook;
            string title = "", isbn = "", publisher = "";
            string[] author = new string[4];
            int numofauthors = 0, stock = 0;
            float price = 0f;
            string name="";
            string ID = "";
            float moneyInBank = 0f;
            float amountspent = 0f;
            int booksbought = 0;
            int indexofmember;
            List<Book> boughtbooks = new List<Book>();
            while (true)
            {
                Console.Clear();
                mainInterOPtion = mainInterface();
                while (mainInterOPtion == "1")
                {
                    Console.Clear();
                    mainOPtion = mainMenu();
                    if (mainOPtion == "1")
                    {
                        addBook(ref title, author, ref numofauthors, ref isbn, ref publisher, ref price, ref stock);
                        book[bookCount] = new Book(title, author, isbn, publisher, price, stock);
                        numofauthors = 0;
                        bookCount++;

                    }
                    else if (mainOPtion == "2")
                    {
                        string searchtitle = "";
                        Console.WriteLine("Enter title to search: ");
                        searchtitle = Console.ReadLine();
                        indexofbook = searchbytitle(searchtitle, bookCount, book);
                        if (indexofbook == -1)
                        {
                            Console.WriteLine("Book with title {0} does not exists ", searchtitle);
                        }
                        else
                        {
                            book[indexofbook].displayInfo();
                            Console.ReadKey();
                        }

                    }
                    else if (mainOPtion == "3")
                    {
                        string searchisbn = "";
                        Console.WriteLine("Enter ISBN to search: ");
                        searchisbn = Console.ReadLine();
                        indexofbook = searchbyisbn(isbn, bookCount, book);
                        if (indexofbook == -1)
                        {
                            Console.WriteLine("Book with title {0} does not exists ", searchisbn);
                        }
                        else
                        {
                            book[indexofbook].displayInfo();
                            Console.ReadKey();

                        }

                    }
                    else if (mainOPtion == "4")
                    {
                        string searchtitle = "";
                        Console.WriteLine("Enter title of the book to change stock: ");
                        searchtitle = Console.ReadLine();
                        indexofbook = searchbytitle(searchtitle, bookCount, book);
                        if (indexofbook == -1)
                        {
                            Console.WriteLine("Book with title {0} does not exists ", searchtitle);
                        }
                        else
                        {
                            changeStock(indexofbook, book);
                        }
                    }
                    else if (mainOPtion == "5")
                    { break; }


                }
                while (mainInterOPtion == "2")
                {
                Console.Clear();
                    memberOption = mainMemberMenu();
                    if (memberOption == "1")
                    {
                        AddMember(ref name, ref ID, ref moneyInBank, ref amountspent);
                        members.Add(new Member(name, ID, moneyInBank, amountspent, booksbought, boughtbooks));
                        memberCount++;
                    }
                    else if (memberOption == "2")
                    {
                        string nameforSearch;
                        Console.Write("Enter the name you want to search:");
                        nameforSearch = Console.ReadLine();
                        indexofmember = searchbyname(nameforSearch, members);
                        if(indexofmember==-1)
                        {
                            Console.WriteLine("Member with name {0} does not exists ", nameforSearch);
                        }
                        else
                        {
                            members[indexofmember].showInfo();
                            Console.ReadKey();

                        }
                    }
                    else if (memberOption == "3")
                    {
                        string IDforSearch;
                        Console.Write("Enter the ID you want to search:");
                        IDforSearch = Console.ReadLine();
                        indexofmember = searchbyID(IDforSearch, members);
                        if (indexofmember == -1)
                        {
                            Console.WriteLine("Member with name {0} does not exists ", IDforSearch);
                        }
                        else
                        {
                            members[indexofmember].showInfo();
                            Console.ReadKey();

                        }
                    }
                    else if(memberOption=="4")
                    {
                        string nameforSearch;
                        string newname = "", newid = "";
                        Console.Write("Enter the name of member you want to update:");
                        nameforSearch = Console.ReadLine();
                        indexofmember = searchbyname(nameforSearch, members);
                        if (indexofmember == -1)
                        {
                            Console.WriteLine("Member with name {0} does not exists ", nameforSearch);
                        }
                        else
                        {
                            members[indexofmember].setname(newname);
                            members[indexofmember].setID(newid);
                        }
                    }

                }
                if (mainInterOPtion=="3")
                {
                    break;
                }
            }
        }
        static string mainMenu()
        {
            string menu = "";
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Search book by title");
            Console.WriteLine("3. Search book by ISBN");
            Console.WriteLine("4. Update stock");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            menu = Console.ReadLine();
            return menu;

        }
        static string mainInterface()
        {
            string menu = "";
            Console.WriteLine("1. Books");
            Console.WriteLine("2. Member");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your preference to work on: ");
            menu = Console.ReadLine();
            return menu;
        }

        static void addBook(ref string title, string[] author, ref int numofauthors, ref string isbn, ref string publisher, ref float price, ref int stock)
        {
            Console.Write("Enter title of book:");
            title = Console.ReadLine();
            while (numofauthors > 4 || numofauthors < 1)
            {
                Console.Write("Enter number of authors(1-4):");
                numofauthors = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Enter names of authors:");
            for (int i = 0; i < numofauthors; i++)
            {
                Console.Write("{0}. : ", i + 1);
                author[i] = Console.ReadLine();

            }
            Console.Write("Enter ISBN of book: ");
            isbn = Console.ReadLine();
            Console.Write("Enter publisher of book: ");
            publisher = Console.ReadLine();
            Console.Write("Enter price of {0} :", title);
            price = float.Parse(Console.ReadLine());
            Console.Write("Enter stock of {0} :", title);
            stock = int.Parse(Console.ReadLine());
        }
        static int searchbytitle(string title, int bookCount, Book[] book)
        {
            for (int i = 0; i < bookCount; i++)
            {
                if (book[i].titleCheck(title))
                { return i; }
            }
            return -1;
        }
        static int searchbyisbn(string isbn, int bookCount, Book[] book)
        {
            for (int i = 0; i < bookCount; i++)
            {
                if (book[i].isbncheck(isbn))
                { return i; }
            }
            return -1;
        }
        static void changeStock(int indexofbook, Book[] book)
        {
            int stock = 0;
            Console.WriteLine("Current stock for {0} is {1}", book[indexofbook].title, book[indexofbook].stock);
            Console.Write("Enter new stock for {0} ", book[indexofbook].title);
            stock=int.Parse(Console.ReadLine());
            book[indexofbook].setStock(stock);
        }
        static string mainMemberMenu()
        {
            string menu = "";
            Console.WriteLine("1. Add Member");
            Console.WriteLine("2. Search Member by name");
            Console.WriteLine("3. Search Member by ID");
            Console.WriteLine("4. Update Member info");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            menu = Console.ReadLine();
            return menu;

        }
        static void AddMember(ref string name,ref string ID,ref float moneyInBank,ref float amountspent)
        {
            Console.Write("Enter name:");
            name= Console.ReadLine();
            Console.Write("Enter ID:");
            ID = Console.ReadLine();
            Console.Write("Enter  current Bank balance:");
            moneyInBank = float.Parse(Console.ReadLine());
            Console.Write("Enter amount spent:");
            moneyInBank = float.Parse(Console.ReadLine());
            
        }
        static int searchbyname(string name,List<Member> members)
        {
            for (int i = 0; i < members.Count; i++) 
            {
                if (members[i].namecheck(name)) { return i; }
            }
            return -1;
        }
        static int searchbyID(string ID, List<Member> members)
        {
            for (int i = 0; i < members.Count; i++)
            {
                if (members[i].idcheck(ID)) { return i; }
            }
            return -1;
        }
    }
}
