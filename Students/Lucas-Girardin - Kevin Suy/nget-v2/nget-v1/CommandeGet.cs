using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace nget_v1
{
    public class CommandeGet : Commande
    {
        WebClient wc = null;

        override
        public void execute()
        {
            if (args.Keys.Contains("-url"))
            {
                if (args.Keys.Contains("-save"))
                {
                    save(args["-url"], args["-save"]);
                }
                else
                {
                    download(args["-url"]);
                }
            }
        }

        //Affiche le fichier passé en paramètre sur la console 
        public void download(String url)
        {
            Console.WriteLine("Download");
            wc = new WebClient();
            Console.WriteLine(wc.DownloadString(url));
        }

        //Enregistre le fichier passé en paramètre dans un fichier passé en second paramètre
        public void save(String url, String path)
        {
            Console.WriteLine("Save");
            wc = new WebClient();
            wc.DownloadFile(url, path);
        }
    }
}
