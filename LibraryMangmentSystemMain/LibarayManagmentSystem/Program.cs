using System;
using System.IO;
using BookObject;
using System.Collections;
using System.Collections.Generic;
using View;
namespace LibarayManagmentSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {



            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            bool terminate = false;
            while (!terminate)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Library Management System");
                Console.WriteLine("1. Add a Book");
                Console.WriteLine("2. Display All Books");
                Console.WriteLine("3. Search for a Book");
                Console.WriteLine("4. Borrow a Book");
                Console.WriteLine("5. Return a Book");
                Console.WriteLine("0. Exit the Program");
                Console.WriteLine("Enter your choice:");
                int i = 0;
                i = Convert.ToInt32(Console.ReadLine());
                switch (i)
                {
                    case 1:
                        bookView objct1 = new bookView();
                        objct1.getInput();
                        break;
                    case 2:
                        bookView objct2 = new bookView();
                        objct2.displayBook();
                        break;
                    case 3:
                        bookView objct3 = new bookView();
                        objct3.searchBook();
                        break;
                    case 4:
                        bookView objct4 = new bookView();
                        objct4.burrowBook();
                        break;
                    case 5:
                        bookView objct5 = new bookView();
                        objct5.returnBook();
                        break;
                    case 0:
                        terminate = true;
                        break;


                }
            }


        }
    }
}