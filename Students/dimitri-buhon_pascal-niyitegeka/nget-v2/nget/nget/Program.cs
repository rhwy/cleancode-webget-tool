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

            if (options.Url == null)
            {
                Console.WriteLine("[Error] Url needs to be defined.");
                return;
            }

            // Get commands
            if (options.CommandType == "get")
            {
                String webContent = NgetTools.getInstance.getWebContent(options.Url);

                // Get web content
                if (options.DestinationFilename == null)
                {
                    Console.WriteLine(webContent);
                }
                // Get web content and save it in a file
                else
                {
                    bool isSaved = NgetTools.getInstance.save(webContent, options.DestinationFilename);
                    Console.WriteLine(isSaved ? "Content saved" : "Error during save");
                }
            }
            // Test commands
            else if (options.CommandType == "test" && options.NbLoops > 0)
            {
                // Test time access to an url N time
                if (!options.IsAverage)
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
                // Test time access to an url N time and get average
                else
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
            Console.Write("\nType something to exit...");
            Console.ReadLine();
        }
    }     
}
