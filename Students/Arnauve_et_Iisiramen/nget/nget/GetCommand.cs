using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nget
{
    class GetCommand : IParseCommand
    {
        private IExecuteCommand exec;
        Dictionary<string, string> dico = new Dictionary<string, string>();
        public GetCommand(IExecuteCommand e)
        {
            exec = e;
        }

        private void parse(string[] command)
        {
            if (command.Length != 5 || command.Length != 3) return ;
            for(int i = 1; i < command.Length; i += 2) {
                dico.Add(command[i], command[i + 1]);
            }
        }

        public void execute(string[] command) {
            parse(command);
            
        }
    }
}
