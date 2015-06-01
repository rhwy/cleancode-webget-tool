using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NDesk.Options;
using System.IO;

namespace nget
{
    class GetCommandArgumentHandler : IArgumentHandler
    {
        private string _url= null;
        private string _file = null;
        private List<string> _extra = new List<string>();

        
        public void ParseArguments(IEnumerable<string> args)
        {
            var optionSet = new OptionSet(){
                {"-url=|url", "Affiche le contenu de l'URL.", 
                v => _url = v},
                {"-save=|save", "Sauvegarde le contenu dans un fichier spécifique",
                v => _file = v}
            };

            try
            {
                _extra = optionSet.Parse(args);
            }
            catch (OptionException e)
            {
                Console.Write("Argument error: ");
                Console.WriteLine(e.Message);
                Console.WriteLine("Try `greet --help' for more information.");
                return;
            }
            
        }

        public void ExecuteCommand()
        {
            if (_url != null)
            {
                using (WebClient client = new WebClient())
                {
                    string content = client.DownloadString(_url);
                    if (_file != null)
                    {
                        try
                        {
                            File.WriteAllText(_file, content);
                        }
                        catch (IOException e)
                        {
                            Console.WriteLine(e.Message);
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine(content);
                    }
                }

                

            }
        }

    }
}
