using System;

namespace ngetv2
{
    internal class test : IArgument
    {

        public string[] Argument { get; set; }

        public WebConnection Connection { get; set; }

        public void execute()
        {
            
            if (Argument.Length > 2)
            {
                string url = Argument[1];
                int nb = int.Parse(Argument[3]);
                bool avg = false;
                int somme = 0;
                if (Array.Find(Argument, findAvg) != null)
                {
                    avg = true;
                }
                for (int i = 0; i < nb; i++)
                {
                    int time = Connection.loadTime(url);
                    if (!avg)
                    {
                        Console.WriteLine("{0} : {1}ms", i + 1, time);
                    }
                    else
                    {
                        somme += time;
                    }
                }
                if (avg)
                {
                    Console.WriteLine("La moyenne de ces {0} chargement est de: {1}ms", nb, somme/nb);
                }
            }
        }

        private bool findAvg(String element)
        {
            return element == "-avg";
        }

    }

 
}
