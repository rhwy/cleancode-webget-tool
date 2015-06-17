using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nget
{
    abstract class ACommand
    {
        protected Options options;

        public ACommand(Options _options)
        {
            options = _options;
        }

        public abstract bool verifyArguments();

        public abstract void executeCommand();
    }
}
