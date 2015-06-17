using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace nget_v2
{
    class Program
    {
        static bool bonArg; //= false;
        static void Main(string[] args)
        {
            bonArg = false;
          
            try
            {
                if (args.Length == 3)
                {
                    if (args[0] == "get" && args.Length == 3)
                    {
                        GetContent(args);
                    }
                }
                else if (args.Length == 5)
                {
                    if (args[0] == "get" && args[3] == "-save")
                    {
                        GetAndSaveContent(args);
                    }
                    if (args[0] == "get" && args[3] == "-times")
                    {
                        GetTimeLoad(args);  
                    }
                }
                else if (args.Length == 6)
                {
                    GetTimeAvgLoad(args);
                }
                if (bonArg == false)
                {
                    Console.WriteLine("Bad arg");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.ReadLine();

        }
        private static void GetTimeAvgLoad(string[] _args)
        {
            Stopwatch stopWatch = new Stopwatch();
            ArrayList tps = new ArrayList();

            for (int i = 0; i < Convert.ToInt32(_args[4]); i++)
            {
                stopWatch.Start();
                using (var client = new WebClient())
                {
                    string result = client.DownloadString(_args[2]);
                }

                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                tps.Add(Convert.ToInt32(ts.Milliseconds));
            }
            double dbResult = 0.0;
            for (int i = 0; i < tps.Count; i++)
            {
                dbResult += Convert.ToDouble(tps[i]);
            }
            dbResult = dbResult / Convert.ToInt32(_args[4]);
            Console.WriteLine("time : " + dbResult + "ms");
            bonArg = true;
        }

        private static void GetTimeLoad(string []_args)
        {
            for (int i = 0; i < Convert.ToInt32(_args[4]); i++)
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                using (var client = new WebClient())
                {
                    string result = client.DownloadString(_args[2]);
                }

                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;

                Console.WriteLine("Chargement numero " + (i + 1) + " : " + ts.Milliseconds + "ms");
                bonArg = true;
            }
        }

        private static void GetAndSaveContent(string[] _args)
        {
            using (var client = new WebClient())
            {
                string result = client.DownloadString(_args[2]);
                File.WriteAllText(_args[4], result);
                bonArg = true;

            }
        }

        private static void GetContent(string[] _args)
        {
            using (var client = new WebClient())
            {
                string result = client.DownloadString(_args[2]);
                Console.WriteLine(result);
                bonArg = true;

            }
        }

    }
}
