using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
namespace Phase1Project2
{
    class Program
    {
        public void InsertRecord()
        {
            FileInfo file = new FileInfo("Record.txt");
            if (!file.Exists)
            {
                file.Create();
            }
            
            //FileStream fs = new FileStream("Record.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter("Record.txt",true);
            string choice = "yes";
            string name,class_name;
            while (choice.Equals("yes"))
            {
                Console.Write("\nEnter name of the student ");
                name = Console.ReadLine();
                Console.Write("\nEnter class name of the student ");
                class_name = Console.ReadLine();
                sw.Write(name + "    " + class_name + "\r\n");
                Console.Write("\nWant to write more records (yes/no) ");
                choice = Console.ReadLine();
            }
            sw.Close();
        }
        void PrintAllRecords()
        {
            StreamReader sr = new StreamReader("Record.txt");
            string rec = sr.ReadToEnd();
            string[] records=rec.Split(new string[]{"\r\n"}, StringSplitOptions.None);
            /*foreach (string record in records)
            {
                if (record.Trim()!= "")
                    Console.WriteLine(record);
            } */
            //Console.Write(rec);
            sr.Close();
            sortList(records);
        }

        void sortList(string[] records)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            //Console.Write(records.Length);
            foreach (string r in records)
            {
                if (r.Trim() != "")
                {
                    string[] fields = r.Split(new string[] { "    " }, StringSplitOptions.None);
                    dict.Add(fields[0], fields[1]);
                }
            }
            /*foreach (var r in dict)
            {
                Console.Write("\n{0}", r);
                //Console.Write("\n{0]", fields.Length);
            }*/

            foreach (KeyValuePair<string, string> student in dict.OrderBy(key => key.Key))
            {
                Console.WriteLine("\n{0} {1}", student.Key, student.Value);
            }
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            //p.InsertRecord();
            p.PrintAllRecords();
            Console.Read();
        }
    }
}
