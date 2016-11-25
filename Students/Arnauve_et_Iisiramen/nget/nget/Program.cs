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
            IParseCommand command;
            switch (args[0])
            {
                case "get":
                    {
                        command = new GetCommand();
                        command.execute(args);
                    }
                    break;
                case "test":
                    {
                        command = new TestCommand();
                        command.execute(args);
                    }
                    break;
            }
        }
    }
}
