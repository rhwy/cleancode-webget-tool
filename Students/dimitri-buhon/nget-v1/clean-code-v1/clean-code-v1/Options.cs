using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean_code_v1
{
    public class Options
    {
        private String commandType;
        private String destinationFilename;
        private String url;
        private int nbLoops = 0;
        private bool isAverage = false;
        
        public Options(string[] args)
        {
            if (args.Length < 2) return;

            commandType = args[0];  
            for(int i = 1; i < args.Length; i++) {
                switch (args[i])
                {
                    case "-url" :
                        url = (args.Length > i) ? args[i + 1] : null;
                        break;
                    case "-save" :
                        destinationFilename = (args.Length > i) ? args[i + 1] : null;
                        break;
                    case "-times" :
                        String str_nbLoops = (args.Length > i) ? args[i + 1] : null;
                        if (str_nbLoops != null)
                            int.TryParse(str_nbLoops, out nbLoops);
                        break;
                    case "-avg":
                        isAverage = true;
                        break;
                }
            }
        }

        // Getters and Setters
        public String CommandType
        {
            get { return commandType; }
            set { commandType = value; }
        }

        public String DestinationFilename
        {
            get { return destinationFilename; }
            set { destinationFilename = value; }
        }

        public String Url
        {
            get { return url; }
            set { url = value; }
        }

        public int NbLoops
        {
            get { return nbLoops; }
            set { nbLoops = value; }
        }

        public bool IsAverage
        {
            get { return isAverage; }
            set { isAverage = value; }
        }
    }
}
                
			

