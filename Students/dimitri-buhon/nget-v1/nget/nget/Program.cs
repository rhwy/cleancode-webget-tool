using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nget
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch;
            TimeSpan ts;

            Options options = new Options(args);

            // Get commands
            if (options.CommandType == "get")
            {
                // prog.exe get -url "myUrl"
                if (options.Url != null && options.DestinationFilename == null)
                {
                    String webContent = NgetTools.getInstance.getWebContent(options.Url);
                    Console.WriteLine(webContent);
                }
                // prog.exe get -url "myUrl" -save "path/to/file"
                else if (options.Url != null && options.DestinationFilename != null)
                {
                    String webContent = NgetTools.getInstance.getWebContent(options.Url);
                    bool isSaved = NgetTools.getInstance.save(webContent, options.DestinationFilename);
                    Console.WriteLine(isSaved ? "Sauvegarde effectuée" : "Erreur dans la sauvegarde");
                }
            }
            // Test commands
            else if (options.CommandType == "test"){
                // prog.exe test -url "myUrl" -times 5
                if (options.Url != null && options.NbLoops > 0 && !options.IsAverage)
                {
                    for (int i = 0; i < options.NbLoops; i++)
                    {
                        Console.Write("Loop " + (i + 1) + " :");
                        stopwatch = new Stopwatch();
                        stopwatch.Start();

                        NgetTools.getInstance.getWebContent(options.Url);

                        stopwatch.Stop();
                        ts = stopwatch.Elapsed;
                        Console.Write(ts.Milliseconds + "ms\n");
                    }
                }
                // prog.exe test -url "myUrl" -times 5 -avg
                else if (options.Url != null && options.NbLoops > 0 && options.IsAverage)
                {
                    double sum = 0;
                    for (int i = 0; i < options.NbLoops; i++)
                    {
                        stopwatch = new Stopwatch();
                        stopwatch.Start();

                        NgetTools.getInstance.getWebContent(options.Url);

                        stopwatch.Stop();
                        ts = stopwatch.Elapsed;
                        sum += ts.Milliseconds;
                    }
                    Console.WriteLine("Time for " + options.NbLoops + " loop(s) : " + (sum / options.NbLoops) + "ms");
                }
            }        
            Console.Write("\nType something ...");
            Console.ReadLine();
        }
    }     
}
