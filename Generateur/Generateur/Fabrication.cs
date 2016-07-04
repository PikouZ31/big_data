using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generateur
{
    public class Fabrication : iLis
    {

        private string server;
        private string userid;
        private string password;
        private string database;
        private MySqlConnection connexion;


        public Fabrication(string server, string userid, string password, string database)
        {
            this.server = server;
            this.userid = userid;
            this.password = password;
            this.database = database;
        }

        public void ConnexionOpen()
        {
            String myConnectionString = "server=" + this.server + ";uid=" + this.userid + ";pwd=" + this.password + ";database=" + this.database + ";";
            this.connexion = new MySql.Data.MySqlClient.MySqlConnection();

            try
            {
                connexion.ConnectionString = myConnectionString;
                connexion.Open();
                Console.WriteLine("Connexion à la base de données établie !");
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine("Impossible de se connecter à la base de données !");
            }
        }

        public void ConnexionClose()
        {
            try
            {
                this.connexion.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine("Impossible de se déconnecter de la base de données !");
                Console.ReadLine();
            }
        }


        public void GenererLigneProduction(string name, int duree, int cadence, int changementproduit)
        {
            // Requête SQL


            MySqlCommand cmdINSERT = this.connexion.CreateCommand();

            cmdINSERT.CommandText = "INSERT INTO ligne_production (nom, duree, cadence, changement_produit) VALUES (@name, @duree, @cadence, @changement_produit)";
            // utilisation de l'objet contact passé en paramètre
            cmdINSERT.Parameters.AddWithValue("@name", name);
            cmdINSERT.Parameters.AddWithValue("@duree", duree);
            cmdINSERT.Parameters.AddWithValue("@cadence", cadence);
            cmdINSERT.Parameters.AddWithValue("@changement_produit", changementproduit);

            cmdINSERT.ExecuteNonQuery();

        }
        

        public void GenererProduits(string table1, string colTable1, ArrayList champsColTable1, string table2, string colTable2, ArrayList champsColTable2)
        {
            /***************************************** DESCRIPTION DE LA METHODE *****************************************
            * Cette méthode permet de copier les données d'un ou des champs d'une base de données "A" vers un ou des champs d'une base de données "B"
            *
            * INSERT INTO table1.colTable1 (champsColTable1[]) SELECT colTable2[] FROM table2.colTable2
            * INSERT INTO administratif.produits (ref) SELECT Ref_produit FROM fabrication.produit
            *************************************************************************************************************/
            

            string champsColonneTable1 = "";
            for (int i = 0; i < champsColTable1.Count; i++)
            {
                if (i != champsColTable1.Count - 1)
                {
                    champsColonneTable1 += champsColTable1.IndexOf(i) + ",";
                }
                else {
                    champsColonneTable1 += champsColTable1.IndexOf(i);
                }
            }

            string champsColonneTable2 = "";
            for (int i = 0; i < champsColTable2.Count; i++)
            {
                if (i != champsColTable2.Count - 1)
                {
                    champsColonneTable2 += champsColTable2.IndexOf(i) + ",";
                }
                else {
                    champsColonneTable2 += champsColTable2.IndexOf(i);
                }

            }

            MySqlCommand cmdINSERT = this.connexion.CreateCommand();
            string str = String.Format("INSERT INTO {0}.{1} ({2}) SELECT {5} FROM {3}.{4}", table1, colTable1, champsColonneTable1, table2, colTable2, champsColonneTable2);
            cmdINSERT.CommandText = str.ToString();

            cmdINSERT.ExecuteNonQuery();
        }
    }
}
