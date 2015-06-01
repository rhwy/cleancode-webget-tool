using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace Projet_NGET
{
    class Program
    {
        /*
         * Main de l'application
         */
        static void Main(string[] args)
        {
            if (args != null)
            {
                if (args.Length > 2) { 
                    switch (args[0])
                    {
                        case "get":
                            if (args[1].Equals("-url"))
                            {
                                AfficherPageWeb(args[2]);
                            }

                            if (args.Length > 3)
                            {
                                if (args[3].Equals("-save"))
                                {
                                    string contenuSite = ContenuPageWeb(args[2]);
                                    SauvegardeFichier(args[4], contenuSite);
                                }
                            }
                            break;
                        case "test":
                            if (args[1].Equals("-url"))
                            {
                                if (args[2] != null)
                                {
                                    if (args.Length > 3)
                                    {
                                        if (args[3].Equals("-times"))
                                        {
                                            if (args[5].Equals("-avg"))
                                            {
                                                AfficherPageWebAvecTimer(args[2], int.Parse(args[4]), 1);
                                            }
                                            else
                                            {
                                                AfficherPageWebAvecTimer(args[2], int.Parse(args[4]), 0);
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                        default:
                            Console.WriteLine("Default case");
                            break;
                    }
                }
            }

        }

        /*
         * Affichage du contenu d'une page web.
         * @param : uneURL
         */
        public static void AfficherPageWeb(string uneURL)
        {
            WebClient client = new WebClient();
            Console.WriteLine("Downloading {0}", uneURL);
            string contenuPage = client.DownloadString(uneURL);
            Console.WriteLine(contenuPage);
        }

        /*
         * Affichage du contenu d'une page web.
         * @param : uneURL
         * @param : nbChargement
         * @param : moyenne
         * @return : time
         */
        public static void AfficherPageWebAvecTimer(string uneURL, int nbChargement, int moyenne)
        {
            var tempsTotal = new List<string>();
            int timer = 0;

            for (int i = 0; i < nbChargement; i++)
            {
                DateTime start = DateTime.Now;

                WebClient client = new WebClient();
                Console.WriteLine("Downloading {0}", uneURL);
                string contenuPage = client.DownloadString(uneURL);

                DateTime end = DateTime.Now;

                TimeSpan time = (end - start);
                tempsTotal.Add(time.Milliseconds.ToString());            
         
                Console.WriteLine(time.Milliseconds.ToString() + " ms");

                timer += int.Parse(time.Milliseconds.ToString());
                Console.WriteLine(timer / nbChargement);
                if (moyenne == 1 && i == nbChargement - 1)
                {
                    System.Console.WriteLine("Moyenne : ", timer / nbChargement + " ms.");
                }
            }

   
        }

        /*
         * Retourne le contenu d'une page web en format string.
         * @param : uneURL
         * @return : contenuPage
         */
        public static string ContenuPageWeb(string uneURL)
        {
            WebClient client = new WebClient();
            string contenuPage = client.DownloadString(uneURL);
            return contenuPage;
        }

        /*
         * Sauvegarde le contenu de la page web dans un fichier.
         * @param : unPatch
         * @param : contenuSite
         */
        public static void SauvegardeFichier(string unPatch, string contenuSite)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"" + unPatch, true))
            {
                Console.WriteLine("Ecriture dans le fichier", unPatch);
                file.WriteLine(contenuSite);
                Console.WriteLine("Ecriture terminée");
            }
        }
    }
}
