using System;
using System.Collections.Generic;
using System.Linq;
using nget.Argument_Handler;
using nget.Argument_Handler.Get;
using nget.Argument_Handler.Help;
using nget.Argument_Handler.Test;

namespace nget
{
    class Program
    {
        private static readonly Dictionary<string, AArgumentHandler> Commands = new Dictionary<string, AArgumentHandler>
        {
            {"get", new GetCommandArgumentHandler()},
            {"test", new TestCommandArgumentHandler()},
            {"help", new HelpCommandArgumentHandler()}
        };

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("No provided argument");
                Console.WriteLine("Use command 'help' to show more informations");
                System.Environment.Exit(1);
            }

            AArgumentHandler handler;

            if (!Commands.TryGetValue(args[0], out handler))
            {
                Console.WriteLine("Please provide appropriate arguments");
                Console.WriteLine("Use command 'help' to show more informations");
                System.Environment.Exit(1);
            }

            try
            {
                handler.ParseArguments(args.Skip(1));
                handler.CheckArguments();
                handler.ExecuteCommand();
            }
            catch (Exception e)
            {
                System.Environment.Exit(1);
            }
        }

    }
}
