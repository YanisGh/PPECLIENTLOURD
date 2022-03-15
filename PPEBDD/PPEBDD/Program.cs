using System;
using System.Collections.Generic;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace PPEBDD
{
    class Program
    {
        static void Main(string[] args)
        {
            int ChoixUtilisateur;
            do
            {
                ChoixUtilisateur = Interface.AfficherMenuPrincipal();
                Interface.TraiterChoix(ChoixUtilisateur, dbCon, reader);
            } while (ChoixUtilisateur != 3);
        }
    }
}
