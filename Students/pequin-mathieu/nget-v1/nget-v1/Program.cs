using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace nget
{
    class Program
    {
        static void Main(string[] args)
        {

            if(args.Length < 3)
            {
                Console.WriteLine("Paramètres insuffisants");
            }
            else
            {
                if(args[0].Equals("get") || args[0].Equals("test"))
                {
                    if (args[1].Equals("-url"))
                    {
                        if (Uri.IsWellFormedUriString(args[2], UriKind.Absolute))
                        {
                            string urlContent = "";

                            if (args[0].Equals("test") && args.Length >= 5)
                                {
                                    if (args[3].Equals("-times"))
                                    {
                                        var times = new double[int.Parse(args[4])];
                                        for (int i = 0; i < int.Parse(args[4]);i++)
                                        {
                                            var watch = System.Diagnostics.Stopwatch.StartNew();
                                            doGetURLResource(args[2]);
                                            watch.Stop();
                                            times[i] = watch.ElapsedMilliseconds;
                                            Console.WriteLine(String.Format("Executed request in {0}",watch.ElapsedMilliseconds));
                                        
                                        }
                                    }
                                    
                                }
                            
                            else{
                                urlContent = doGetURLResource(args[2]);
                                Console.WriteLine(urlContent);

                            }
                            
                            
                            if (args.Length == 5 && args[3].Equals("-save"))
                            {
                                Console.WriteLine(String.Format("Enregistrement du contenu dans le fichier {0}", args[4]));
                                saveUrlContent(urlContent, args[4]);
                         
                            }

                        }
                    }
                }
            }


            Console.ReadLine();
        }

        public static string doGetURLResource(string UrlString)
        {
            Console.WriteLine("L'URL saisie est valide");
            Console.WriteLine("Récupération du contenu...");
            using(System.Net.WebClient client = new System.Net.WebClient())
            {
                return client.DownloadString(UrlString);
            }
            
        }

        public static async void saveUrlContent(string content, string SavePath)
        {
            using(System.IO.FileStream outputfile = new System.IO.FileStream(SavePath, System.IO.FileMode.Create))
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(outputfile, Encoding.UTF8))
                {
                    await file.WriteAsync(content.ToString());
                }
            }


        }



    }



}
