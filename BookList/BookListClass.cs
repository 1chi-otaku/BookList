using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;



namespace BookList
{
    class Book
    {
        public string name{get;set;}
        public string author { get; set; }
        public string genre { get; set; }
        public int ID { get; set; }

        public Book()
        {
            Random random= new Random();
            ID = random.Next(1,1000000);
            name = "N/A";
            author = "N/A";
            genre = "N/A";
        }
        public Book(string name, string author, string genre, int iD)
        {
            this.name = name;
            this.author = author;
            this.genre = genre;
            ID = iD;
        }
        public void Print()
        {
            Console.WriteLine("ID - " + ID);
            Console.WriteLine("Title - " + name);
            Console.WriteLine("Genre - " + genre);
            Console.WriteLine("Author - " + author);
            Console.WriteLine();
        }
    }
    class BookList
    {
        private Book[] list;

        public BookList()
        {
            list = new Book[1];
            list[0] = new Book();
        }
        public BookList(int number)
        {
            list = new Book[number];
            for (int i = 0; i < list.Length; i++)
                list[i] = new Book();
            
        }
        public BookList(params Book[] lists)
        {
            list = new Book[lists.Length];
            for (int i = 0; i < lists.Length; i++)
                list[i] = lists[i];
        }
        public Book this[int index]
        {
            get
            {
                if (index >= 0 && index < list.Length)
                    return list[index];
                else
                    throw new Exception("Incorrect index! " + index);
            }
            set
            {
                if (index >= 0 && index < list.Length)
                    list[index] = value;
                else
                    throw new Exception("Incorrect index! " + index);
            }
        }
        public void PrintList() {

            for (int i = 0; i < list.Length; i++)
            {
                Console.WriteLine("#{0}", i+1);
                list[i].Print();
            }
        }
        public void AddBook(Book newbook)
        {
            Array.Resize(ref list, list.Length + 1);
            list[list.Length-1] = newbook;
        }
        public void DeleteBook(int ID)
        {
            bool isFound = false;
            Book[] newlist = new Book[list.Length - 1];
            for (int i = 0,j = 0; j < newlist.Length; i++,j++)
            {
                if (list[i].ID == ID && isFound == false)
                {
                    isFound = true;
                    j--;
                    continue;
                }
                newlist[j] = list[i];
            }
            if(isFound == true)
            {
                list = newlist;
            }
        }
        public int Search(string subject)
        {
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i].name == subject || list[i].genre == subject || list[i].author == subject) return i + 1;
            }
            return -1;
        }
        public int IDSearch(int ID)
        {
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i].ID == ID) return i+1;
            }
            return -1;
        }
        public void ShowBook(int index)
        {
            if(index >= 1 && index < list.Length+1)
            {
                list[index-1].Print();
            }
            else
            {
                Console.WriteLine("Could not found");
            }
        }
        public void IDShowBook(int ID)
        {
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i].ID != ID)
                {
                    list[i].Print();
                    return;
                }
            }
        }
        public void EditBook(int index)
        {
            Console.WriteLine("Enter ID - ");
            list[index].ID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Title - ");
            list[index].name = Console.ReadLine();
            Console.WriteLine("Enter Author - ");
            list[index].author = Console.ReadLine();
            Console.WriteLine("Enter Genre - ");
            list[index].genre = Console.ReadLine();
        }
        public void Init()
        {
            for (int i = 0; i < list.Length; i++)
            {
                Console.WriteLine("Book #:" + i+1);
                EditBook(i);
                Console.WriteLine();
            }
        }
        public static BookList operator +(BookList op1, Book op2) //Operator +
        {
            Array.Resize(ref op1.list, op1.list.Length + 1);
            op1.list[op1.list.Length - 1] = op2;
            return op1;
        }
    }
}
