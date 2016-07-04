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

            MySqlCommand cmd = bdd.connexion.CreateCommand();

            // Requête SQL
            cmd.CommandText = "INSERT INTO Satisfaction (Packaging,Produit,Delais_livraison,SAV) VALUES (@Packaging,@Produit,@Delais_livraison,@SAV)";
            // utilisation de l'objet contact passé en paramètre
            cmd.Parameters.AddWithValue("@Packaging", rnd1.Next(0, 10));
            cmd.Parameters.AddWithValue("@Produit", rnd1.Next(0, 10));
            cmd.Parameters.AddWithValue("@Delais_livraison", rnd1.Next(0, 10));
            cmd.Parameters.AddWithValue("@SAV", rnd1.Next(0, 10));

            cmd.ExecuteNonQuery();
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
