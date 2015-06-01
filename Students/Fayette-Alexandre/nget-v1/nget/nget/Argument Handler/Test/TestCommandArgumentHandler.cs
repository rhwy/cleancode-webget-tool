using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NDesk.Options;

namespace nget.Argument_Handler.Test
{
    class TestCommandArgumentHandler : IArgumentHandler
    {
        private string _url = null;
        private int _repeat = 1;
        private bool _displayAverage = false;
        private List<string> _extra = new List<string>();  


        public void ParseArguments(IEnumerable<string> args)
        {
            var optionSet = new OptionSet(){
                {"-url=|url", "Affiche le contenu de l'URL.", 
                v => _url = v},
                {"-times=|times", "Nombre de répétitions du chargement de la page",
                (int v) => _repeat = v},
                {"-avg|avg", "Affiche la moyenne du temps de chargement", v => _displayAverage = v != null}
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
                Stopwatch stopwatch = new Stopwatch();
                List<int> times = new List<int>();

                using (WebClient client = new WebClient())
                {
                    for (int i = 0; i < _repeat; i++)
                    {
                        stopwatch.Start();
                        client.DownloadString(_url);
                        stopwatch.Stop();
                        times.Add(int.Parse(stopwatch.Elapsed.Milliseconds.ToString()));
                        stopwatch.Reset();
                    }
                }

                if (_displayAverage)
                    Console.WriteLine("Temps moyen des {0} requêtes : {1} millisecondes", _repeat, times.Average());
                else
                {
                    int i = 1;
                    foreach (var time in times)
                    {
                        Console.WriteLine("Temps de la requête numéro {0} : {1} millisecondes", i, time);
                        i++;
                    }
                }
            }
        }
    }
}
