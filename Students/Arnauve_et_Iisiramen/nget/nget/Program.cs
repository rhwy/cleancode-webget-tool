using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nget
{
    class Program
    {
        static void Main(string[] args)
        {
            IExecuteCommand ec = new IExecuteCommand();
            IParseCommand command;
            Console.WriteLine(args[0]);
            switch (args[0])
            {
                case "get":
                    command = new GetCommand(ec);
                    command.execute(args);
                    break;
                case "test":
                    command = new GetCommand(ec);
                    command.execute(args);
                    break;
            }
        }
    }
}
