using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NDesk.Options;

namespace nget.Argument_Handler.Help
{
    class HelpCommandArgumentHandler : AArgumentHandler
    {
        public void ParseArguments(IEnumerable<string> args)
        {}

        public override void ExecuteCommand()
        {
            Console.WriteLine("Usage :\n--'nget get -url <url to download> [-file <destination file>]'");
            Console.WriteLine("\tDownload the content of the provided URL to the specified file,\n\tor to the standard output");
            Console.WriteLine("\n--'nget test -url <url to test> [-times <number of tests>] [-avg]'");
            Console.WriteLine("\tTest the download time of the specified URL.\n\tThe test is performed by default 1 time.\n\tIf avg is used, then " +
                              "only the average value is displayed");
            Console.WriteLine("\n--'nget help'");
            Console.WriteLine("\tShow this help");
        }

        public override void CheckArguments()
        {}

        public override OptionSet getOptions()
        {
            return new OptionSet();
        }
    }
}
