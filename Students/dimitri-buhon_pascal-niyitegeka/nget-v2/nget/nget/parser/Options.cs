using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nget
{
    public class Options
    {
        public String destinationFilename { get; private set; }
        public String url { get; private set; }
        public bool isAverage { get; private set; }
        public int nbLoops { get; private set; }
        
        public Options(string[] args)
        {
            isAverage = false;
            nbLoops = 0;

            if (args.Length < 3)
                return;

            int tmpNbLoops = nbLoops;
            for(int i = 1; i < args.Length; i++) {
                switch (args[i])
                {
                    case "-url" :
                        url = (args.Length > i+1) ? args[i + 1] : null;
                        break;
                    case "-save" :
                        destinationFilename = (args.Length > i+1) ? args[i + 1] : null;
                        break;
                    case "-times" :
                        String str_nbLoops = (args.Length > i+1) ? args[i + 1] : null;
                        if (str_nbLoops != null)
                        {
                            int.TryParse(str_nbLoops, out tmpNbLoops);
                            nbLoops = tmpNbLoops;
                        }
                        break;
                    case "-avg":
                        isAverage = true;
                        break;
                }
            }
            nbLoops = tmpNbLoops;
        }
    }
}
                
			

