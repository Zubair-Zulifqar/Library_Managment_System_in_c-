using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookObject;
using DAL;
using BorowerObject;

namespace BL
{
    public class BussinessClass
    {
        public static void Main(string[] args)
        {

        }
        public void addBook(Book bo)
        {
            DataAL dal = new DataAL();
            dal.saveRecord(bo);
        }
        public List<Book> getBooks()
        {
            DataAL dal = new DataAL();
            List<Book> lstBookObj = dal.getRecord();
            return lstBookObj;
        }
        public List<Book> findBook(Book bo)
        {
            DataAL dal = new DataAL();
            List<Book> temp = new List<Book>();
          
            List<Book> data = dal.getRecord();
            if (data.Count == 0)
            {
                return temp;
            }
            for (int t = 0; t < data.Count; t++)
            {
                Book b = data[t];
                if (b.Title == bo.Title && b.Author == bo.Author && b.Genre == bo.Genre)
                {
                    temp.Add(b);
                }
            }
            return temp;
        }
        public void burowBook(int iD)
        {
            Book book = null;
            DataAL dal = new DataAL();
            bool found = false;
            List<Book> data = dal.getRecord();
            if (data.Count == 0)
            {
                Console.WriteLine("\nno book\n");
                return;
            }
            for (int t = 0; t < data.Count; t++)
            {
                
                if (data[t].Id == iD)
                {
                  
                    book = data[t];
                    if (data[t].status == 1)
                    {
                        found = true;
                        data[t].status = 0;
                    }
                }
            }
            if (found)
            {
                dal.updateBookRecord(data);
                Console.WriteLine("Book {0} Burrowed Successfully", book.Title);
                Console.Write("Please enter Borrower Roll No = ");
                string rolNo = Console.ReadLine();
                Console.Write("Please enter Borrower Library Card Numer = ");
                string borrowerLibCrdNo = Console.ReadLine();
                BorowerObjectClass brwr = new BorowerObjectClass  { rollNo = rolNo, libraryCardNumber = borrowerLibCrdNo, bookId = iD };
                dal.saveBurrowerRecord(brwr);
            }
            else
                Console.WriteLine("SORRY BOOK not found with ID {0}", iD);

        }

        public void retunBook(int id)
        {
            Book book = null;
            DataAL dal = new DataAL();
            bool found = false;
            List<Book> data = dal.getRecord();
            if (data.Count == 0)
            {
                Console.WriteLine("You cant return book as u have not borrowed it previously");
                return;
            }
            for (int t = 0; t < data.Count; t++)
            {
                //Book b = ;
                if (data[t].Id == id)
                {
                    //found = true;
                    book = data[t];
                    if (data[t].status == 0)
                    {
                        data[t].status = 1;
                        found = true;
                    }
                    break;
                }
            }

            if (found)
            {

                Console.WriteLine("Book {0} Returned Successfully", book.Title);
                Console.Write("Please enter Borrower Roll No = ");
                string No = Console.ReadLine();
                Console.Write("Please enter Borrower Library Card Numer = ");
                string CrdNo = Console.ReadLine();
               BorowerObjectClass brwr = new BorowerObjectClass { rollNo = No, libraryCardNumber = CrdNo, bookId = id };
                dal.removeBurrowerRecord(brwr, id);
                dal.updateBookRecord(data);


            }
            else
            {
                Console.WriteLine("BOOK AVAILABLE");
            }


        }


    }
}