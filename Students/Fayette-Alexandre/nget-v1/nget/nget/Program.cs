using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nget.Argument_Handler.Test;

namespace nget
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 0)
            {
                IArgumentHandler handler;

                switch (args[0])
                {
                    case "get":
                        handler = new GetCommandArgumentHandler();
                        break;
                    case "test":
                        handler = new TestCommandArgumentHandler();
                        break;
                    default:
                        Console.WriteLine("Veuillez fournir des arguments appropriés");
                        return;
                }
                handler.ParseArguments(args.Skip(1));
                handler.ExecuteCommand();

            }
        }
    }
}
