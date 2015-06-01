using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean_code_v1
{
    public class Options
    {
        private String filename = null;
        private String url = null;
        private int testLoops = 0;
        private bool testAverage = false;

        public String Filename
        {
            get { return filename; }
            set { filename = value; }
        }

        public String Url
        {
            get { return url; }
            set { url = value; }
        }
        
        public int TestLoops
        {
            get { return testLoops; }
            set { testLoops = value; }
        }
        
        public bool TestAverage
        {
            get { return testAverage; }
            set { testAverage = value; }
        }
        
        public Options(string[] args)
        {            
            for(int i = 0; i < args.Length; i++) {
                String value = (args[i + 1] == null ? null : args[i + 1]);
                switch (args[i])
                {
                    case "-url" :
                        url = value;
                        break;
                    case "-save" :
                        filename = value;
                        break;
                    case "-times" :
                        int.TryParse(args[4], out testLoops);
                        break;
                    case "-avg":
                        testAverage = true;
                        break;
                }
            }
        }
    }
}
                
			

