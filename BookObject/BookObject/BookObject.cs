using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace BookObject
{
    public class Book
    {
        public static int id;



        public int Id { set; get; }
        public string Title { set; get; }
        public string Author { set; get; }

        public string Genre { set; get; }

        public string PublicationYear { set; get; }

        public int status { set; get; }

        
        public void printDetails()
        {
            Console.WriteLine($"ID: {this.Id}");
            Console.WriteLine($"Title: {this.Title}");
            Console.WriteLine($"Author: {this.Author}");
            Console.WriteLine($"Genre: {this.Genre}");
            Console.WriteLine($"Publication Year: {this.PublicationYear}");
            Console.WriteLine("--------------------------------------------------");
        }
        public static void Main(string[] args)
        {

        }

        }


}
