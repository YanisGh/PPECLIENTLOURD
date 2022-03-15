using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace PPEBDD
{
    public class DBconnection
    {
        public DBconnection()
        {
            DBconnection dbCon = new DBconnection();
            dbCon.Server = "127.0.0.1";//Moche d'un point de vue sécurité
            dbCon.DatabaseName = "Sucrerie";
            dbCon.UserName = "visualstudio";
            dbCon.Password = "renard";
            if (dbCon.IsConnect())
            {
                //Parcours Classique d'un curseur, adressage des colonnes par leur position ordinale dans la requête
                string query = "select code_c, nom, adresse from client;";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                var reader = cmd.ExecuteReader();//Remplissage du curseur
                Console.WriteLine("--------------------Parcours Classique du reader------------------");
                while (reader.Read()) //On affiche le contenu de chaque ligne
                {
                    string someStringFromColumnZero = reader.GetString(0);
                    string someStringFromColumnOne = reader.GetString(1);
                    Console.WriteLine(someStringFromColumnZero + "," + someStringFromColumnOne);
                }
                reader.Close();
            }
        }

        public string Server { get; set; }
        public string DatabaseName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public MySqlConnection Connection { get; set; }

        private static DBconnection _instance = null;
        public static DBconnection Instance()
        {
            if (_instance == null)
                _instance = new DBconnection();
            return _instance;
        }

        public bool IsConnect()
        {
            if (Connection == null)
            {
                if (String.IsNullOrEmpty(DatabaseName))
                    return false;
                string connstring = string.Format("Server={0}; database={1}; UID={2}; password={3}", Server, DatabaseName, UserName, Password);
                Connection = new MySqlConnection(connstring);
                Connection.Open();
            }

            return true;
        }


        public void Close()
        {
            Connection.Close();
        }
    }
}
