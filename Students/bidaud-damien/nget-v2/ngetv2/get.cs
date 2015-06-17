using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ngetv2
{
    class get : IArgument
    {
        public string[] Argument
        {
            get;
            set;
        }

        public void execute()
        {
            string url = Argument[2];
            WebClient client = new WebClient();
            try
            {
                string data = client.DownloadString(url);
                if (Argument.Length == 3)
                {
                    //on affiche
                    Console.WriteLine(data);
                }
                else if (Argument.Length > 3)
                {
                    if (Argument[3] == "-save")
                    {
                        try
                        {
                            //on sauvegarde
                            File.WriteAllText(Argument[4], data);
                            Console.WriteLine("Fichier sauvegarder!");
                        }
                        catch (UnauthorizedAccessException)
                        {
                            Console.WriteLine("Vous ne posséder pas les droits pour sauvegarder un ficher {0}", Argument[4]);
                        }
                    }
                }
            }
            catch (WebException)
            {
                Console.WriteLine("L'adresse n'est pas correct");
            }
        }
    }
}
