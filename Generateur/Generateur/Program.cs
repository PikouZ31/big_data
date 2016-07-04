using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace ConsoleApplication13
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BDD bdd = new BDD("127.0.0.1", "root", "", "client");
            bdd.ConnexionOpen();
            Console.WriteLine(bdd.GetName());
            Console.ReadLine();
        }

        

        static void genererreference()
        {
            int i;
            char c;
            Random rnd1 = new Random();
            for(int t=0;t<20;t++)
            {
                i = rnd1.Next(65, 90);
                c = Convert.ToChar(i);
                Console.Write(c);
            }
        }


        static readonly Random rnd = new Random();
        public static DateTime GetRandomDate(DateTime from, DateTime to)
        {
            var range = to - from;

            var randTimeSpan = new TimeSpan((long)(rnd.NextDouble() * range.Ticks));

            return from + randTimeSpan;
        }
    }
}
