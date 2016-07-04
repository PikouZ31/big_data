using ConsoleApplication13;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generateur
{
    class Commande
    {
       private BDD bdd;

        public Commande(string server, string userid, string password, string database)
        {
            bdd = new BDD(server, userid, password, database);
            bdd.ConnexionOpen();
        }


        public void GenererSatisfaction()
        {
            Random rnd1 = new Random();
            Random rnd2 = new Random();
            Random rnd3 = new Random();
            Random rnd4 = new Random();

            int packaging = rnd1.Next(0, 10);
            int produit = rnd2.Next(0, 10);
            int delais = rnd3.Next(0, 10);
            int sav = rnd4.Next(0, 10);


            MySqlCommand cmd = bdd.connexion.CreateCommand();

            // Requête SQL
            cmd.CommandText = "INSERT INTO Satisfaction (Packaging,Produit,Delais_livraison,SAV) VALUES (@Packaging,@Produit,@Delais_livraison,@SAV)";
            // utilisation de l'objet contact passé en paramètre
            cmd.Parameters.AddWithValue("@Packaging", packaging);
            cmd.Parameters.AddWithValue("@Produit", produit);
            cmd.Parameters.AddWithValue("@Delais_livraison", delais);
            cmd.Parameters.AddWithValue("@SAV", sav);

            for (int i=0;i<20;i++)
            {

                packaging = rnd1.Next(0, 10);
                produit = rnd2.Next(0, 10);
                delais = rnd3.Next(0, 10);
                sav = rnd4.Next(0, 10);
                // Exécution de la commande SQL
                cmd.ExecuteNonQuery();
            }
            

            bdd.ConnexionClose();
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
