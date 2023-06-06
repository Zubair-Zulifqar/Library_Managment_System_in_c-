using System;
using BookObject;
using BL;
using System.Collections;
using System.Collections.Generic;
namespace View
{
    public class bookView
    {
        public static void Main(string[] args)
        {

        }
        public void getInput()
        {
            Console.WriteLine("Enter the book's title:");
            string title = Console.ReadLine();

            Console.WriteLine("Enter the book's author:");
            string author = Console.ReadLine();

            Console.WriteLine("Enter the book's genre:");
            string genre = Console.ReadLine();

            Console.WriteLine("Enter the book's publication year:");
            string publicationYear = Console.ReadLine();

            Book bBO = new Book() { Title = title, Author = author, Genre = genre, PublicationYear =(String)publicationYear };
            BussinessClass bl = new BussinessClass();
            bl.addBook(bBO);
        }

        public void displayBook()
        {
            BussinessClass bl = new BussinessClass();
            Console.WriteLine("BOOKS CURRENTLY AVAILABLE");
            List<Book> lst = bl.getBooks();
            for (int o = 0; o < lst.Count; o++)
            {
                Book bo = lst[o];
                bo.printDetails();
                Console.WriteLine();
            }

        }

        public void searchBook()
        {
            Console.WriteLine("Title");
            string title= Console.ReadLine();
            Console.WriteLine("Enter Book Author");
            string author = Console.ReadLine();
            Console.WriteLine("Genre");
            string genere = Console.ReadLine();
            Book bo = new Book() { Title = title, Author = author, Genre = genere };
            BussinessClass bl = new BussinessClass();

            List<Book> lst = bl.findBook(bo);
            if (lst.Count == 0)
                Console.WriteLine("BOOK NOT FOUND with Title = {0}\tAuthor = {1}\tGenre = {2}", title, author, genere);
            else
            {
                for (int i = 0; i < lst.Count; i++)
                    Console.WriteLine("BOOK FOUND having Title = {0}\tBook Author = {1}\tBook Genre = {2}", lst[i].Title, lst[i].Author, lst[i].Genre);
            }
        }

        public void burrowBook()
        {
            Console.WriteLine("Enter id");
            int iD;
            iD = Convert.ToInt32(Console.ReadLine());
            BussinessClass bl = new BussinessClass();
            bl.burowBook(iD);

        }

        public void returnBook()
        {
            Console.WriteLine("Enter Book Identifier(id)");
            int iD;
            iD = Convert.ToInt32(Console.ReadLine());
            BussinessClass bl = new BussinessClass();
            bl.retunBook(iD);

        }



    }
}