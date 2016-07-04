using ConsoleApplication13;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generateur
{
    class Commande
    {

        public Commande(string server, string userid, string password, string database)
        {
            BDD bdd = new BDD(server, userid, password, database);
            bdd.ConnexionOpen();
        }


        public void GenererSatisfaction()
        {
            Random rnd1 = new Random();
            Random rnd2 = new Random();
            Random rnd3 = new Random();
            Random rnd4 = new Random();

            rnd1.Next(0, 10);
            rnd2.Next(0, 10);
            rnd3.Next(0, 10);
            rnd4.Next(0, 10);





        }

        public void GenererSatisfait()
        {

        }

        public void GenererClient()
        {

        }

        public void GenererProduit()
        {

        }

        public void GenererEtat()
        {

        }

        public void GenererCommande()
        {

        }

        public void GenererContient()
        {

        }
    }
}
