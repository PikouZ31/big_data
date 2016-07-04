using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using Generateur;
using System.Collections;

namespace ConsoleApplication13
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Commande BDDcommande = new Commande("127.0.0.1", "root", "", "commande");

            // - Mike - Base de données "Fabrication"
            Fabrication fabrication = new Fabrication("127.0.0.1", "root", "", "fabrication");
            fabrication.ConnexionOpen();
            //fabrication.GenererLigneProduction("A",1,180,1);
            //fabrication.GenererLigneProduction("B", 3, 300, 1);
            //fabrication.GenererLigneProduction("C", 2, 250, 1);
            

            ArrayList champsColTable1 = new ArrayList(), champsColTable2 = new ArrayList();
            champsColTable1.Add("ref");
            champsColTable1.Add("ref_produit");

            fabrication.GenererProduits("administratif", "produits", champsColTable1, "fabrication", "produit", champsColTable2);


            fabrication.ConnexionClose();
            // - Mike - END
            

            //BDDcommande.GenererSatisfaction();
            for (int i =0;i<20;i++)
            {
                BDDcommande.GenererEtat();
            }
            


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
