using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nget
{
    //Point d'entrée du programme
    class Program
    {
        static void Main(string[] args)
        {
            new MenuTraitement(args);
            Console.Read();
        }
    }
}
