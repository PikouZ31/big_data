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
            BDD bdd = new BDD("127.0.0.1", "root", "", "client");
            bdd.ConnexionOpen();
        }


        public void GenererSatisfaction()
        {

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
