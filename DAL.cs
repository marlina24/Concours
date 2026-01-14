using System;
using System.IO;

namespace Concours
{
    [Flags]
    internal enum Statuts
    {
        Aucun = 0,
        Etranger = 1,
        Boursier = 2,
        Admis = 4
    }

    internal class DAL
    {
        public static (string nom, double moyenne, Statuts statuts)[]? Etudiants;
        public const int NbAdmis = 50;

        // Charge le fichier des étudiants dans le tableau de tuples
        public static void ChargerDonnées()
        {
            string[] lignes = File.ReadAllLines("Etudiants.csv");

            Etudiants = new (string, double, Statuts)[lignes.Length - 1];

            for (int l = 1; l < lignes.Length; l++)
            {
                string[] infos = lignes[l].Split(';');
                Etudiants[l - 1].nom = infos[0] + " " + infos[1];
                Etudiants[l - 1].moyenne = double.Parse(infos[4]);

                Statuts st = Statuts.Aucun;
                if (infos[2] == "O") st = Statuts.Etranger;
                if (infos[3] == "O") st |= Statuts.Boursier;
                if (l <= NbAdmis) st |= Statuts.Admis;

                Etudiants[l - 1].statuts = st;
            }
        }

        /// <summary>
        /// Remplace un ou plusieurs étudiants admis par les premiers non admis
        /// </summary>
        public static string[] RemplacerEtudiantsAdmis(params string[] noms)
        {
            string[] remplaçants = new string[noms.Length];
            int cptRemp = 0;

            if (Etudiants == null) return remplaçants;

            for (int n = 0; n < noms.Length; n++)
            {
                for (int i = 0; i < NbAdmis; i++)
                {
                    if (Etudiants[i].nom == noms[n])
                    {
                        Etudiants[i].statuts ^= Statuts.Admis;
                        Etudiants[NbAdmis + cptRemp].statuts |= Statuts.Admis;
                        remplaçants[n] = Etudiants[NbAdmis + cptRemp].nom;
                        cptRemp++;
                        break;
                    }
                }
            }
            return remplaçants;
        }
    }
}
