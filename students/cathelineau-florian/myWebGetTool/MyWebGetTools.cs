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
        }

        public Stream getUrlContent(string url)
        {
            try
            {
                WebRequest req = WebRequest.Create(url);
                Stream objStream;
                objStream = req.GetResponse().GetResponseStream();
                return objStream;
            }
            catch (Exception ex)
            { 
                throw ex;
            }
        }
        
        public Boolean verifyArguments()
        {
            // 1st Arg : commandType (Get or Test)
            if (arguments[1] == "test" || arguments[1] == "get")
            {
                this.commandType = arguments[1];
            }
            else
            {
                errorMessage = "Argument 1 invalid";
                printError();
                return false;
            }

            //2nd and 3rd args must be urls
            if (arguments[2] == "-url" && arguments[3].Substring(0, 7) == "http://")
            {
                this.options.Add("url", arguments[3]);
            }

            for (int i = 4; i < arguments.Length; i++)
            {
                if ((i + 1) < arguments.Length && isKeyValid(arguments[i]) == true)
                {
                    this.options.Add(arguments[i], arguments[i + 1]);
                }
            }

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

        public void run()
        {
            if (this.verifyArguments() == true)
            {
                Console.WriteLine(this.getUrlContent(this.options["url"]));
            }
        }

        public void writeFile(Stream s)
        { 

        }
    }
}
