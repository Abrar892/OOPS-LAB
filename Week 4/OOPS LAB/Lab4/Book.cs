using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Book
    {
        public string title;
        public string[] author = new string[4];
        public string ISBN;
        public string publisher;
        public float price=0f;
        public int stock;

        public Book(string title, string[] author, string ISBN, string publisher, float price, int stock)
        {
            this.title = title;
            this.author = author;
            this.ISBN = ISBN;
            this.publisher = publisher;
            this.price = price;
            this.stock = stock;
        }

        public void displayInfo()
        {
            Console.WriteLine("Title: {0}", title);
            Console.Write("Authors: ");
            for (int i = 0; i < author.Length; i++) 
            {
                Console.Write("  {0}",author[i]);
            }
            Console.WriteLine();
            Console.WriteLine("Publisher: {0}",publisher);
            Console.WriteLine("Price: {0}",price);
            Console.WriteLine("Stock: {0}",stock);
        }
        public void setTitle(string title)
        {
            this.title = title;
        }
        public void setStock(int stock)
        {
            this.stock = stock;
        }
        public void setPrice(float price)
        {
            this.price = price;
        }
        
        public void setISBN(string isbn)
        {
            this.ISBN = isbn;
        }
        public void setPublisher(string publisher)
        {
            this.publisher = publisher;
        }
        public void setAuthors(string[] author)
        {
            this.author = author;
        }
        public bool titleCheck(string title)
        {
            if (this.title == title)
            {
                return true;
            }
            else 
            { 
                return false;
            }

        }
        public bool isbncheck(string isbn)
        {
            if (this.ISBN == isbn)
            {
                return true;
            }
            else 
            { 
                return false;
            }
        }



    }
}
