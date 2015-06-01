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
        /// <summary>
        /// Main de l'application
        /// </summary>
        /// <param name="args"></param>
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

        /// <summary>
        /// Affichage du contenu d'une page web.
        /// </summary>
        /// <param name="uneURL"></param>
        public static void AfficherPageWeb(string uneURL)
        {
            WebClient client = new WebClient();
            Console.WriteLine("Downloading {0}", uneURL);
            string contenuPage = client.DownloadString(uneURL);
            Console.WriteLine(contenuPage);
        }

        /// <summary>
        /// Affichage du contenu d'une page web.
        /// </summary>
        /// <param name="uneURL"></param>
        /// <param name="nbChargement"></param>
        /// <param name="moyenne"></param>
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

        /// <summary>
        /// Retourne le contenu d'une page web en format string.
        /// </summary>
        /// <param name="uneURL"></param>
        /// <returns name="contenuPage"></returns>
        public static string ContenuPageWeb(string uneURL)
        {
            WebClient client = new WebClient();
            string contenuPage = client.DownloadString(uneURL);
            return contenuPage;
        }

        /// <summary>
        /// Sauvegarde le contenu de la page web dans un fichier.
        /// </summary>
        /// <param name="unPatch"></param>
        /// <param name="contenuSite"></param>
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
