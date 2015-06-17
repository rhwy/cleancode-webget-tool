using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nget
{
    interface IParseCommand
    {
        void execute(string[] command);
        void parse(string[] command);
    }
}
