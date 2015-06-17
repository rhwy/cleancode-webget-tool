using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace nget
{
    class GetCommand : IParseCommand
    {
        Dictionary<string, string> dico = new Dictionary<string, string>();

        public void parse(string[] command)
        {
            if (command.Length != 5 && command.Length != 3) return;
            for(int i = 1; i < command.Length; i += 2) {
                dico.Add(command[i], command[i + 1]);
            }
        }

        public void execute(string[] command) {
            dico.Clear();
            parse(command);
            if (dico.Keys.Count == 0) return;
            var client = new WebClient();
            string data = client.DownloadString(dico["-url"]);
            if (dico.ContainsKey("-save")  && dico["-save"] != null && dico["-save"] != "")
            {
                System.IO.File.WriteAllText(dico["-save"], data);
            }
            else
            {
                Console.WriteLine(data);
            }
        }
    }
}
