using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace nget.Process
{
    class Sets
    {
        //
        public static readonly Dictionary<String, Regex> REGEXP = new Dictionary<string, Regex>()
        {
            // Récupération du fichier
            { "GET"  , new Regex( "^(?i)get( )+(-url (http(s?):.*))( )+(-save( )+(.+))?$" ) } ,

            // Tester le temps de chargement  
            { "TEST" , new Regex( "^(?i)test( )+(-url (http(s?):.*))( )+(-times( )+([0-9])+( )+(-avg)?)?$" ) } 
        };
    }
}
