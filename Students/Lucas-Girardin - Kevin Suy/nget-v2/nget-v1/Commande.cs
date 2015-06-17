using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nget_v1
{
    public abstract class Commande
    {
        public Dictionary<string, string> args = new Dictionary<string,string>();
        public abstract void execute();
    }
}
