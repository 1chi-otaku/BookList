using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Book a = new Book("A great book, desu!","Someone","Shounen",100);
                Book b = new Book("A black swan", "...", "Non Fiction", 101);
                BookList list = new BookList(a,b);
                list += new Book("Book of sadness", "...", "Romance", 102);
                list.PrintList();
                Console.WriteLine();
                list.DeleteBook(101);
                list.PrintList();
                Console.WriteLine();
                list.AddBook(new Book("A white swan", "...", "Fiction", 101));
                list.AddBook(new Book("A white swan 2", "...", "Fiction", 103));
                list.PrintList();


                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(list[i].name);
                }



            }
            catch(Exception ex) { 
                Console.WriteLine(ex.Message);
            }
           

     
          
          
        }
    }
}
