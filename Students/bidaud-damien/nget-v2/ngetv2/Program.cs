using System;
using System.Collections.Generic;
using System.Net;
using System.IO;

namespace ngetv2
{
    class Program
    {

        private static Dictionary<string, IArgument> etapes = new Dictionary<string, IArgument>(){{"get", new get()},{"test", new test()}}; 

        public static void Main(string[] args)
        {

            if (args.Length == 0)
            {
                Console.WriteLine("Aucun argument mis en parametre");
            }
            else
            {
                IArgument argumentManager = etapes[args[0]];


            }
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }

        public static int loadTime(string url)
        {
            try
            {
                WebClient client = new WebClient();
                Int32 start = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                client.DownloadString(url);
                Int32 end = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                return end - start;
            }
            catch (WebException)
            {
                return 0;
            }
        }
    }
}
