using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using NDesk.Options;

namespace nget.Argument_Handler.Get
{
    class GetCommandArgumentHandler : AArgumentHandler
    {
        private string _url;
        private string _file;

        public override OptionSet getOptions()
        {
            return new OptionSet(){
                {"-url=|url", "Displays the URL content", 
                v => _url = v},
                {"-save=|save", "Save the content in the specified file",
                v => _file = v}
            };
        }
        
        public override void ExecuteCommand()
        {
            using (var client = new WebClient())
            {
                try
                {
                    string content = client.DownloadString(_url);
                    if (_file != null)
                        File.WriteAllText(_file, content);
                    else
                        Console.WriteLine(content);
                }
                catch (IOException e)
                {
                    Console.Write("File error : ");
                    Console.WriteLine(e.Message);
                    throw;
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occured while trying to download from {0}", _url);
                    Console.WriteLine(e.Message);
                    throw;
                }
            }
        }

        public override void CheckArguments()
        {
            if (_url == null) throw new OptionException("No URL specified", "url");
        }
    }
}
