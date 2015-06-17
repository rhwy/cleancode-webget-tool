using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ngetv2
{
    interface IArgument
    {

        string[] Argument { get; set; }
        WebConnection Connection { get; set; }


        void execute();
        
    }
}
