using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using BookObject;
using BorowerObject;
namespace DAL
{
    public class DataAL
    {
        public static void Main(string[] args)
        {

        }
        public void saveRecord(Book b)
        {

            StreamWriter sw = null;
            StreamReader sr = null;
            try
            {
      


                b.status = 1;
                string pathFile = Path.Combine(Environment.CurrentDirectory, "MyLibraymanagmentsystem.txt");
                if (!File.Exists(pathFile))
                {
                    sw = File.CreateText(pathFile);
                    sw.Close();
                }
                sw = null;
               
                   b.Id = ++(Book.id);
               
                sw = new StreamWriter(pathFile, append: true);
                string json = JsonConvert.SerializeObject(b);
                sw.WriteLine(json);


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                sw.Close();
            }
        }
        public List<Book> getRecord()
        {
            List<Book> Lst = new List<Book>();
            StreamReader sw = null;
            try
            {
                string PathFile = Path.Combine(Environment.CurrentDirectory, "MyLibraymanagmentsystem.txt");
                if (!File.Exists(PathFile))
                {
                    
                    Console.WriteLine("\nNo  Book\n");
                    return Lst;
                }
                
                sw = new StreamReader(PathFile);
                string sr = sw.ReadLine();
                while (sr != null)
                {
                    Book b;
                    b = JsonConvert.DeserializeObject<Book>(sr);
                    Lst.Add(b);
                    
                    sr = sw.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                sw.Close();
            }
            return Lst;
        }


        public void updateBookRecord(List<Book> List)
        {
            StreamWriter sw = null;
            try
            {
                string pathFile = Path.Combine(Environment.CurrentDirectory, "MyLibraymanagmentsystem.txt");
               
                sw = new StreamWriter(pathFile, append: false);
                for (int i = 0; i < List.Count; i++)
                {
                    string json = JsonConvert.SerializeObject(List[i]);
                    sw.WriteLine(json);
                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                sw.Close();
            }
        }

        public void saveBurrowerRecord(BorowerObjectClass borowerObj)
        {

            StreamWriter sw = null;
            try
            {

                string newT = Path.Combine(Environment.CurrentDirectory, "Burrowers.txt");
                
                sw = new StreamWriter(newT, append: true);
                string json = JsonConvert.SerializeObject(borowerObj);
                sw.WriteLine(json);


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                sw.Close();
            }


        }

        public void removeBurrowerRecord(BorowerObjectClass borowerObj, int id)
        {
            StreamReader sr = null;
            List<BorowerObjectClass> dl = new List<BorowerObjectClass>();
            var pathFile = Path.Combine(Environment.CurrentDirectory, "Burrowers_Record.txt");
            sr = new StreamReader(pathFile);
            string str = sr.ReadLine();
            while (str != null)
            {
                BorowerObjectClass br;
                br = JsonConvert.DeserializeObject<BorowerObjectClass>(str);
                dl.Add(br);
                str = sr.ReadLine();
            }

            for (int i = 0; i < dl.Count; i++)
            {
                if ((dl[i].rollNo == borowerObj.rollNo) && (dl[i].libraryCardNumber == borowerObj.libraryCardNumber) && (dl[i].bookId == id))
                {
                    dl.RemoveAt(i);
                }
            }
            sr.Close();

            StreamWriter sw = null;
            sw = new StreamWriter(pathFile, append: false);
            for (int i = 0; i < dl.Count; i++)
            {
                string srr;
                srr = JsonConvert.SerializeObject(dl[i]);
                sw.WriteLine(srr);
            }
            sw.Close();




        }




       
    }
}