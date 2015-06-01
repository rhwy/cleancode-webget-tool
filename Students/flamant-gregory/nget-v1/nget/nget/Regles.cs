using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace nget
{
    class Regles
    {
        //Impossible d'utiliser var ça ne fonctionne pas...
        List<Regex> lstRegles = new List<Regex>();

        public Regles()
        {
            //Règle une
            string pattern = @"get\\s-url\\s""[A-z|0-9|\\:|\\/]*""";
            lstRegles.Add(new Regex(pattern, RegexOptions.IgnoreCase));
        }

        public List<Regex> LstRegles
        {
            get { return lstRegles; }
        }
    }
}
