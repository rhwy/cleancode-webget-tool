using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;

namespace nget_v1
{
    public class CommandeTest : Commande
    {
        Stopwatch sw = null;
        WebClient wc = null;

        override
        public void execute()
        {
            if (args.Keys.Contains("-url"))
            {
                if (args.Keys.Contains("-times"))
                {
                    if (args.Keys.Contains("-avg"))
                    {
                        avg(args["-url"], args["-times"]);
                    }
                    else
                    {
                        time(args["-url"], args["-times"]);
                    }
                }
                
            }
        }

        //Calcule plusieur fois le temps requis pour charger un fichier en paramètre
        public void time(String url, String nb)
        {
            Console.WriteLine("Time");
            int n = 0;
            try
            {
                n = Convert.ToInt32(nb);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Erreur d'argument");
                return;
            }
            for (int i = 0; i < n; i++)
            {
                sw = new Stopwatch();
                sw.Start();
                wc = new WebClient();
                wc.DownloadString(url);
                sw.Stop();
                Console.WriteLine(sw.ElapsedMilliseconds + " ms");
            }
        }

        //Calcule la moyenne le temps requis pour charger un fichier en paramètre		
        public void avg(String url, String nb)
        {
            Console.WriteLine("avg");
            int n = 0;
            try
            {
                n = Convert.ToInt32(nb);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Erreur d'argument");
                return;
            }
            double moyenne = 0;
            for (int i = 0; i < n; i++)
            {
                sw = new Stopwatch();
                sw.Start();
                wc = new WebClient();
                wc.DownloadString(url);
                sw.Stop();
                moyenne += sw.ElapsedMilliseconds;
            }
            moyenne = moyenne / n;
            Console.WriteLine("Moyenne : " + moyenne + " ms");
        }
    }
}
