using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nget.Process;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;
using System.Collections;

namespace nget
{
    class Program
    {
        static void Main(string[] args)
        {
            Boolean isGet  = false;
            Boolean isTest = false;

            if (args.Length < 3 || ( !( isGet = new Regex("^(?i)get$").IsMatch(args[0]) ) && !( isTest = new Regex("^(?i)test$").IsMatch(args[0]) ) ) )
            {
                Console.WriteLine("Commande incorrecte !");
                return;
            }
            
            if (!new Regex("^(?i)\\-url$").IsMatch(args[1]) || !new Regex("^(?i)(http(s?):.*)$").IsMatch(args[2]))
            {
                Console.WriteLine("Commande URL incorrecte !");
                return;
            }

            if (isTest)
            {
                if (args.Length <= 4 || !new Regex("^(?i)\\-times$").IsMatch(args[3]) || !new Regex("^([0-9])+$").IsMatch(args[4]) )
                {
                    Console.WriteLine("Commande incorrecte !");
                    return;
                }

                double total = 0.0;

                for (int i = 1, loop = Convert.ToInt32(args[4])+1; i < loop; i++)
                {
                    double thistime = display(args[2],test:true);
                    total+=thistime ;

                    Console.WriteLine("Test n°{0} : {1}ms",i,thistime);
                }

                if (args.Length >= 6 || !new Regex("^(?i)\\-avg").IsMatch(args[5]))
                    Console.WriteLine("Moyenne : {0}ms", total/Convert.ToInt32(args[4]));
            }
            else if (isGet)
            {
                if (args.Length > 4 && Uri.IsWellFormedUriString(args[4], UriKind.RelativeOrAbsolute))
                    Console.WriteLine("Time : {0} ms", display(args[2], DownLoaderLocation: args[4]));
                else
                    Console.WriteLine("Time : {0} ms", display(args[2]));
            }
        }

        public static double display(String url, String DownLoaderLocation = "", Boolean test = false )
        {
            try
            {
                DateTime startTime = DateTime.Now;

                WebClient client = new WebClient();

                String content = "";

                if (DownLoaderLocation == "")
                {
                    if (!test)
                        Console.WriteLine("Displaying : {0}\nContent : \n{1}", url, client.DownloadString(url));
                    else
                        client.DownloadString(url);
                }
                else
                {
                    Console.WriteLine("Downloading : {0}", url);
                    content = client.DownloadString(url);

                    using (StreamWriter sr = new StreamWriter(File.Open(@DownLoaderLocation, FileMode.OpenOrCreate)))
                    {
                        sr.Write(content);
                    }
                }

                return (DateTime.Now - startTime).TotalMilliseconds;
            }
            catch (WebException)
            {
                Console.WriteLine( "L'adresse de destination semble injoignable !" );
                return 0;
            }
            catch (Exception)
            {
                Console.WriteLine("Error has occurred !");
                return 0;
            }
        }

        public static void wget(String url, String location)
        {
        
        }
    } ;
} ;
