using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace nget
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args[0] == "get" && args[1] == "-url" && args[2] != "")
            {
                string url = args[2];
                WebClient client = new WebClient();
                try
                {
                    string downloadString = client.DownloadString(url);
                    Console.WriteLine(downloadString);

                    if (args.Length > 4 && args[3] == "-save" && args[4] != "")
                    {
                        try
                        {
                            string path = args[4];
                            System.IO.StreamWriter file = new System.IO.StreamWriter(path, true);

                            file.WriteLine(downloadString);

                            Console.WriteLine("Contenu de l'url enregistré dans {0}", path);
                        }
                        catch (IOException e)
                        {
                            Console.WriteLine(e);
                        }
                        catch (UnauthorizedAccessException e)
                        {
                            Console.WriteLine(e);
                        }
                    }
                }
                catch (WebException e)
                {
                    Console.WriteLine(e);
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e);
                }
            }
            else if (args[0] == "test" && args[1] == "-url" && args[2] != "" && args[3] == "-times" && args[4] != "")
            {
                int n;
                string url = args[2];
                bool test = Int32.TryParse(args[4], out n);

                if (args.Length < 6)
                {
                    for (int i = 0; i < n; i++)
                    {
                        Console.WriteLine("Temps de chargement de la page {0} : {1} ms", url, loadFile(url));
                    }
                }
                else if(args.Length > 5 && args[5] == "-avg")
                {
                    
                    int somme = 0;
                    for (int i = 0; i < n; i++)
                    {
                        somme += loadFile(url);
                    }
                    somme = somme / n;
                    Console.WriteLine("Temps moyen de chargement de la page {0} : {1} ms", url, somme);
                }
                
            }
        }

        private static int loadFile(string url)
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
