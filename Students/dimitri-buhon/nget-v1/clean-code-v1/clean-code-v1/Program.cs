using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean_code_v1
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch;
            TimeSpan ts;

            // Trois arguments
            if (args.Length == 3)
            {
                // prog.exe get -url "myUrl"
                if (args[0] == "get" && args[1] == "-url")
                {
                    String webContent = NgetTools.getInstance.getWebContent(args[2]);
                    Console.WriteLine(webContent);
                }
            }

            // Cinq arguments
            else if (args.Length == 5)
            {
                // prog.exe get -url "myUrl" -save
                if (args[0] == "get" && args[1] == "-url" && args[3] == "-save")
                {
                    String webContent = NgetTools.getInstance.getWebContent(args[2]);
                    bool isSaved = NgetTools.getInstance.save(webContent, args[4]);
                    Console.WriteLine(isSaved ? "Sauvegarde effectuée" : "Erreur dans la sauvegarde");
                }

                // prog.exe test -url "myUrl" -times 5
                else if (args[0] == "test" && args[1] == "-url" && args[3] == "-times")
                {
                    int nbLoop;
                    bool isNumeric = int.TryParse(args[4], out nbLoop);

                    if (isNumeric)
                    {
                        for (int i = 0; i < nbLoop; i++)
                        {
                            Console.Write("Loop " + (i+1) + " :");
                            stopwatch = new Stopwatch();
                            stopwatch.Start();

                            NgetTools.getInstance.getWebContent(args[2]);

                            stopwatch.Stop();
                            ts = stopwatch.Elapsed;
                            Console.Write(ts.Milliseconds + "ms\n");
                        }
                    }
                }

                // Six arguments                
                else if (args.Length == 6)
                {
                    // prog.exe test -url "myUrl" -times 5 -avg
                    if (args[0] == "test" && args[1] == "-url" && args[3] == "-times" && args[5] == "-avg")
                    {
                        double sum;
                        int nbLoop;
                        bool isNumeric = int.TryParse(args[4], out nbLoop);

                        if (isNumeric)
                        {
                            sum = 0;
                            for (int i = 0; i < nbLoop; i++)
                            {
                                stopwatch = new Stopwatch();
                                stopwatch.Start();

                                NgetTools.getInstance.getWebContent(args[2]);

                                stopwatch.Stop();
                                ts = stopwatch.Elapsed;
                                sum += ts.Milliseconds;
                            }
                            Console.WriteLine("Time for " + nbLoop + " loop(s) : " + sum / nbLoop + "ms");
                        }
                    }
                }
                Console.Write("\nType something ...");
                Console.ReadLine();
            }
        }
    }
}
