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

                if (options.DestinationFilename != null)
                {
                    bool isSaved = NgetTools.getInstance.save(webContent, options.DestinationFilename);
                    Console.WriteLine(isSaved ? "Content saved" : "Error during save");
                }
                else
                    Console.WriteLine(webContent);
            }

            // Test commands
            else if (options.CommandType == "test" && options.NbLoops > 0)
            {
                if (!options.IsAverage)
                    TestTools.getInstance.test_time_access(options);
                else
                    TestTools.getInstance.test_time_access_average(options);
            }
            Console.Write("\nType something to exit...");
            Console.ReadLine();
        }
    }     
}
