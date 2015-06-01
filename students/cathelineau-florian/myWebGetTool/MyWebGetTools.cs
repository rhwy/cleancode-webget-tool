using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace myWebGetTool
{
    class MyWebGetTools
    {
        private string[] arguments { get; set; }
        public string commandType { get; set; }
        public string errorMessage { get; set; }
        public string[] optionsAvailable { get; set; }
        public Dictionary<string, string> options { get; set; }
        //public File file { get; set; }

        public MyWebGetTools(string[] args)
        {
            this.arguments = args;
            this.options = new Dictionary<string, string>();
            foreach (string a in args)
                Console.WriteLine(a);

        }

        public void run()
        {
            if (this.verifyArguments() == true)
            {
                Console.WriteLine(this.getUrlContent(this.options["url"]));
            }
        }

        public StreamReader getUrlContent(string url)
        {
            try
            {
                WebRequest req = WebRequest.Create(url);
                Stream objStream = req.GetResponse().GetResponseStream();
                StreamReader sr = new StreamReader(objStream);
                objStream.Dispose();
                sr.Dispose();
                return sr;

                
            }
            catch (Exception ex)
            { 
                throw ex;
            }
        }
        
        public Boolean verifyArguments()
        {

            //test
            //Console.WriteLine(arguments[0]);

            // 1st Arg : commandType (Get or Test)
            if (arguments[0] == "test" || arguments[0] == "get")
            {
                this.commandType = arguments[0];
            }
            else
            {
                errorMessage = "Argument 1 invalid";
                printError();
                return false;
            }

            Console.WriteLine("PREMIER TEST PASSE");

            //2nd and 3rd args must be urls
            if (arguments[1] == "-url")// && arguments[2].Substring(0, 7) == "http://")
            {
                this.options.Add("url", arguments[2]);
            }
            else
                return false;

            Console.WriteLine("DEUXIEME TEST PASSE");
            /*
            for (int i = 3; i < arguments.Length; i++)
            {
                if ((i + 1) < arguments.Length && isKeyValid(arguments[i]) == true)
                {
                    this.options.Add(arguments[i], arguments[i + 1]);
                }
            }
            */
            return true;
        }

        private Boolean isKeyValid(String key)
        {
            foreach(String opt in this.optionsAvailable){
                if(opt == key){
                    return true;
                }
            }
            return false;
        }

        public void printError()
        {
            Console.WriteLine("Error : " + this.errorMessage);
            this.errorMessage = "";
        }

        public void writeFile(Stream s)
        { 

        }
    }
}
