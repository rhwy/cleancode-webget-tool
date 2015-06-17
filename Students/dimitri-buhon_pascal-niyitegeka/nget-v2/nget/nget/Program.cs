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
       private static Dictionary<string, ACommand> commandDictionary;

        static void Main(string[] args)
        {
            init(args);

            ACommand command;
            if (commandDictionary.TryGetValue(args[0], out command))
            {
                if (command.verifyArguments())
                    command.executeCommand();
                else
                    Console.WriteLine("[Error] Missing arguments.");
            }
            else 
                Console.WriteLine("[Error] Invalid command type.");

            Console.WriteLine("\n...");
            Console.ReadLine();
        }

        private static void init(string[] args)
        {
            Options options = new Options(args);

            commandDictionary = new Dictionary<string, ACommand>{
            {"get", new CommandGet(options)},
            {"test", new CommandTest(options)}};
        }
    }     
}
