using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nget
{
    interface IArgumentHandler
    {
        /// <summary>
        /// Parse a set of arguments, matching rules of implemented handler
        /// </summary>
        /// <param name="args"></param>
        void ParseArguments(IEnumerable<string> args);

        /// <summary>
        /// Execute the internal command, after the parsing of the arguments
        /// </summary>
        void ExecuteCommand();
    }
}
