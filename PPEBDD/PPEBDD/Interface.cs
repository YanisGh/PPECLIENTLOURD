using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace PPEBDD
{
    class Interface
    {
        public static int AfficherMenuPrincipal()
        {
            Console.WriteLine("------------------");
            Console.WriteLine("1. Rechercher un Participant");
            Console.WriteLine("2. Ajouter un participer");
            Console.WriteLine("3. Quitter");
            Console.WriteLine("Votre Choix : - ");
            Console.WriteLine("------------------");
            try
            {
                string Choix = Console.ReadLine();
                return int.Parse(Choix);
            }
            catch
            {
                return 0;
            }
        }
        public static void TraiterChoix(int ChoixUtilisateur, DBconnection dbCon, MySqlDataReader reader)
        {
            switch (ChoixUtilisateur)
            {
                case 0:
                    Console.WriteLine("Seulement les choix entre 1 et 3 compris son possible");
                    break;

                case 1:
                    Console.WriteLine("Vous souhaitez rechercher un participant, appuyez sur une touche pour continuer");
                    Console.ReadKey();
                    Interface.RechercherParticipant();//ID NOM PRENOM VILLE DE RESIDENCE A METTRE DANS LA BDD
                    break;

                case 2:
                    Console.WriteLine("Vous souhaitez ajouter un participant, appuyez sur une touche pour continuer");
                    Console.ReadKey();
                    Interface.AjouterParticipant(dbCon, reader);
                    break;


            }
        }
        public static void AjouterParticipant(DBconnection dbCon, MySqlDataReader Reader)
        {
            
        }
    } 
}
