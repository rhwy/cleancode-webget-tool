using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace nget
{
    class TestCommand : IParseCommand
    {
        Dictionary<string, string> dico = new Dictionary<string, string>();

        public TestCommand() {
        }

        public void parse(string[] command)
        {
            if (command.Length != 5 && command.Length != 6) return;
            
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
            dico.Clear();
            parse(command);
            if (dico.Keys.Count == 0) return;
            IParseCommand com = new GetCommand();
            string[] s = {"get", "-url", dico["-url"], "-save", "test.txt"};
            int len = Int32.Parse(dico["-times"]);
            if (dico.ContainsKey("-avg"))
            {
                long time = 0;
                for (int i = 0; i < len; i++)
                {
                    var watch = Stopwatch.StartNew();
                    com.execute(s);
                    watch.Stop();
                    time += watch.ElapsedMilliseconds;
                }
                Console.WriteLine("en moyenne : " + (time / len) + " millis");
            }
            else {
                for (int i = 0; i < len; i++)
                {
                    var watch = Stopwatch.StartNew();
                    com.execute(s);
                    watch.Stop();
                    Console.WriteLine(watch.ElapsedMilliseconds + " Milisecond");
                }
            }
        }
    }
}
