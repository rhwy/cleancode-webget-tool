using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nget
{
    class TestCommand
    {
        private IExecuteCommand exec;
        Dictionary<string, string> dico = new Dictionary<string, string>();

        public TestCommand(IExecuteCommand e)
        {
            exec = e;
        }

        private void parse(string[] command)
        {
            if (command.Length != 5 || command.Length != 6) return;
            
            for (int i = 1; i < command.Length; i += 2)
            {
                if (i == 5)
                    dico.Add(command[i], "true");
                else
                    dico.Add(command[i], command[i + 1]);
            }
        }

        public void execute(string[] command)
        {
            parse(command);
            exec.execute("test", dico);
        }
    }
}
