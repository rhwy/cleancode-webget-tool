using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nget
{
    class CommandTest : ACommand
    {
        public CommandTest(Options options)
            : base(options)
        {
        }

        public override bool verifyArguments()
        {
            if (options.url == null || options.nbLoops <= 0)
                return false;
            return true;
        }

        public override void executeCommand()
        {
            if (verifyArguments())
            {
                if (!options.isAverage)
                    TestTools.test_time_access(options);
                else
                    TestTools.test_time_access_average(options);
            }
        }
    }
}
