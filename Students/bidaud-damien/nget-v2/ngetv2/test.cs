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
            string url = Argument[1];
            int nb = int.Parse(Argument[3]);
            bool avg = false;
            int somme = 0;
            //on vérifie si on veut la moyenne
            if (Argument.Length > 4 && Argument[4] == "-avg")
            {
                avg = true;
            }
            for (int i = 0; i < nb; i++)
            {
                int time = loadTime(url);
                if (!avg)
                {
                    //on affiche chaque temps de chargement si on ne veut pas la moyenne
                    Console.WriteLine("{0} : {1}ms", i + 1, time);
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
                Console.WriteLine("La moyenne de ces {0} chargement est de: {1}ms", nb, somme / nb);
            }
        }

        public int loadTime(string url)
        {
           WebClient client = new WebClient();
           DateTime first, second;
           try
           {
               first = DateTime.Now;
               string downloadString = client.DownloadString(url);
               second = DateTime.Now;

               return second.Subtract(first).Milliseconds;

           }
           catch (WebException e)
           {
               Console.WriteLine(e);
               return 0;
           }
       
       }
    }
}
