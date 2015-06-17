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

                string[] argument = new string[args.Length-1];
                for (int i = 1; i < args.Length; i++)
                {
                    argument[i - 1] = args[i];
                }
                argumentManager.Argument = argument;
                argumentManager.execute();

            }
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }

        
    }
}
