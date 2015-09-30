using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace nget
{
    class Program
    {
        static void Main(string[] args)
        {
            bool bonArg = false;
            try
            {
                if (args.Length == 3)
                {
                    if (args[0] == "get" && args.Length == 3)
                    {

                        using (var client = new WebClient())
                        {
                            string result = client.DownloadString(args[2]);
                            Console.WriteLine(result);
                            bonArg = true;

                        }
                    }
                }
                else if (args.Length == 5)
                {
                    if (args[0] == "get" && args[3] == "-save")
                    {
                        using (var client = new WebClient())
                        {
                            string result = client.DownloadString(args[2]);
                            File.WriteAllText(args[4], result);
                            bonArg = true;

                        }
                    }
                
                
                    if (args[0] == "get" && args[3] == "-times")
                    {


                        for (int i = 0; i < Convert.ToInt32(args[4]); i++)
                        {
                            Stopwatch stopWatch = new Stopwatch();
                            stopWatch.Start();
                            using (var client = new WebClient())
                            {
                                string result = client.DownloadString(args[2]);
                            }

                            stopWatch.Stop();
                            TimeSpan ts = stopWatch.Elapsed;

                            Console.WriteLine("Chargement numero " + (i + 1) + " : " + ts.Milliseconds + "ms");
                            bonArg = true;
                        }
                    }
                }
                else if (args.Length == 6)
                {
                    Stopwatch stopWatch = new Stopwatch();
                    ArrayList tps = new ArrayList();

                    for (int i = 0; i < Convert.ToInt32(args[4]); i++)
                    {
                        stopWatch.Start();
                        using (var client = new WebClient())
                        {
                            string result = client.DownloadString(args[2]);
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
                    dbResult = dbResult / Convert.ToInt32(args[4]);
                    Console.WriteLine("time : " + dbResult + "ms");
                    bonArg = true;
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
    }
}
