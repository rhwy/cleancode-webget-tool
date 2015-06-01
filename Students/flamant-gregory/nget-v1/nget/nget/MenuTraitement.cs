using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace nget
{
    //Traitement du choix/arguments de l'utilisateur
    class MenuTraitement
    {
        //Arguments de l'utilisateur
        string argument;
        string[] arguments;

        public MenuTraitement(string[] args)
        {
            this.argument = string.Join(" ", args);
            this.arguments = args;
            matchRegle();
        }

        private void matchRegle()
        {
            Regles regles = new Regles();
            MatchCollection matche;
            int ind = 0;     

            foreach (Regex regle in regles.LstRegles)
            {
                matche = regle.Matches(this.argument);
                Console.WriteLine("\nTest de la règle : " + ind);
                if (matche.Count > 0)
                {
                    doTraitement(ind);
                    break;
                }
                Console.WriteLine("Règle ne match pas.\n" + ind);
                ind++;
            }
        }

        private void doTraitement(int traitement)
        {
            try
            {
                switch (traitement)
                {
                    case 0:
                        try
                        {
                            using (System.Net.WebClient client = new WebClient())
                            {
                                char[] separator = { '\"' };
                                this.arguments[2] = this.arguments[2].Split(separator).ToString();
                                string fileContent = client.DownloadString(this.arguments[2]);
                                Console.WriteLine(fileContent);
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Impossible d'accéder au site...");
                        }

                        break;
                    case 1:

                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Une erreur est survenue...");
            }
            
        }
    }
}
