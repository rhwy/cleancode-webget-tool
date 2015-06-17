using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ngetv2
{
    class test : IArgument
    {

        public string[] Argument
        {
            get;
            set;
        }

        public void execute()
        {
            string url = args[2];
            int nb = int.Parse(args[4]);
            bool avg = false;
            int somme = 0;
            //on vérifie si on veut la moyenne
            if (args.Length > 5 && args[5] == "-avg")
            {
                avg = true;
            }
            for (int i = 0; i < nb; i++)
            {
                int time = loadTime(url);
                if (!avg)
                {
                    //on affiche chaque temps de chargement si on ne veut pas la moyenne
                    Console.WriteLine("{0} : {1}s", i + 1, time);
                }
                else
                {
                    //on fait la somme
                    somme += time;
                }
            }
            if (avg)
            {
                //on affiche la moyenne
                Console.WriteLine("La moyenne de ces {0} chargement est de: {1}s", nb, somme / nb);
            }
        }

        public int loadTime(string url)
        {
            try
            {
                WebClient client = new WebClient();
                Int32 start = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                client.DownloadString(url);
                Int32 end = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                return end - start;
            }
            catch (WebException)
            {
                return 0;
            }
        }
    }
}
