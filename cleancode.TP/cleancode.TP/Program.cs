using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cleancode.tp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Parser pars = new Parser();
            string urlData = "";
            if (args.Length == 0)
            {
                System.Environment.Exit(1);
            }
            if (args.Length > 4)
            {
                if (args[2] == "-times" && args[4] == "-avg")
                {
                    urlData = args[1];
                    pars.getLoadingFileTimes(urlData, Convert.ToInt32(args[3]), true);
                }
            }else if (args.Length >= 3) {
                if (args[2] == "-save")
                {
                    urlData = args[1];
                    pars.generateJsonFile(args[3],pars.getJsonByAdress(urlData));
                }
                if (args[2] == "-times")
                {
                    urlData = args[1];
                    pars.getLoadingFileTimes(urlData,Convert.ToInt32(args[3]),false);
                }
            }else if (args[0] == "-url")
            {
                urlData = args[1];
                Console.WriteLine(pars.getJsonByAdress(urlData));
            }
           
            Console.Read();
        }
    }
}
