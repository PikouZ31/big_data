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
        private BDD bddValeur;

        public Commande(string server, string userid, string password, string database)
        {
            bdd = new BDD(server, userid, password, database);
            bdd.ConnexionOpen();
            bddValeur = new BDD("127.0.0.1", "root", "", "valeur");
            bddValeur.ConnexionOpen();
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

            Random rnd1 = new Random();

            MySqlCommand cmdINSERT = bdd.connexion.CreateCommand();
            MySqlCommand cmdSELECTSatisfaction = bdd.connexion.CreateCommand();
            MySqlCommand cmdSELECTClient = bdd.connexion.CreateCommand();
            MySqlCommand cmdSELECTDatelivraison = bdd.connexion.CreateCommand();

            // Requête SQL
            cmdINSERT.CommandText = "INSERT INTO Satifait (Date_satisfaction,ID_Client,ID_Satisfaction) VALUES (@Date_satisfaction,@ID_Client,@ID_Satisfaction)";
            cmdSELECTSatisfaction.CommandText = "SELECT max(ID_Satisfaction) FROM Satisfaction";
            cmdSELECTClient.CommandText = "SELECT max(ID_Client) FROM Clients";
            cmdSELECTDatelivraison.CommandText = "SELECT Date_livraison_relle FROM Commande WHERE ID = 'max(ID)'";

            MySqlDataReader reader = cmdSELECTSatisfaction.ExecuteReader();
            MySqlDataReader reader1 = cmdSELECTClient.ExecuteReader();
            MySqlDataReader reader2 = cmdSELECTDatelivraison.ExecuteReader();

            DateTime date = Convert.ToDateTime(reader2[0]);

            cmdINSERT.Parameters.AddWithValue("@ID_Client", reader1[0]);
            cmdINSERT.Parameters.AddWithValue("@ID_Satisfaction", reader[0]);
            cmdINSERT.Parameters.AddWithValue("@Date_satisfaction", GetRandomDate(date, date.AddDays(rnd1.Next(1, 30))));


        }

        public void GenererClient()
        {


            //select max(ID_Etat)FROM etat
            Random rnd1 = new Random();

            MySqlCommand cmdINSERT = bdd.connexion.CreateCommand();
            MySqlCommand cmdSELECT = bddValeur.connexion.CreateCommand();


            // Requête SQL
            cmdINSERT.CommandText = "INSERT INTO client (Nom,Ville,Pays,CodePostal,B2B,AppelOffre) VALUES (@Nom,@Ville,@Pays,@CodePostal,@B2B,@AppelOffre)";
            cmdSELECT.CommandText = "SELECT NOM FROM nom WHERE ID = '" + rnd1.Next(1,100) + "'";


            MySqlDataReader reader = cmdSELECT.ExecuteReader();

            // utilisation de l'objet contact passé en paramètre
            cmdINSERT.Parameters.AddWithValue("@Nom", reader[0]);
            cmdINSERT.Parameters.AddWithValue("@Ville", rnd1.Next(0, 10));
            cmdINSERT.Parameters.AddWithValue("@Pays", rnd1.Next(0, 10));
            cmdINSERT.Parameters.AddWithValue("@CodePostal", rnd1.Next(0, 10));



            switch (rnd1.Next(1, 2))
            {
                case 1:
                    cmdINSERT.Parameters.AddWithValue("@B2B", "FALSE");
                    cmdINSERT.Parameters.AddWithValue("@AppelOffre", "FALSE");
                    break;
                case 2:
                    cmdINSERT.Parameters.AddWithValue("@B2B", "TRUE");
                    switch (rnd1.Next(1, 2))
                    {
                        case 1:
                            cmdINSERT.Parameters.AddWithValue("@AppelOffre", "FALSE");
                            break;
                        case 2:
                            cmdINSERT.Parameters.AddWithValue("@AppelOffre", "TRUE");
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
            cmdINSERT.ExecuteNonQuery();
        }

        public void GenererProduit()
        {

        }

        public void GenererEtat()
        {
            Random rnd1 = new Random();

            MySqlCommand cmd = bdd.connexion.CreateCommand();

            // Requête SQL
            cmd.CommandText = "INSERT INTO Etat (etat) VALUES (@Etat)";

            switch (rnd1.Next(1, 3))
            {
                case 1:
                    cmd.Parameters.AddWithValue("@Etat", "Encour");
                    break;
                case 2:
                    cmd.Parameters.AddWithValue("@Etat", "Terminer");
                    break;
                case 3:
                    cmd.Parameters.AddWithValue("@Etat", "Annuler");
                    break;
                default:
                    break;
            }
            cmd.ExecuteNonQuery();
        }

        public void GenererCommande()
        {

        }

        public void GenererContient()
        {

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
