using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using NDesk.Options;

namespace nget.Argument_Handler.Test
{
    class TestCommandArgumentHandler : AArgumentHandler
    {
        private string _url;
        private int _repeat = 1;
        private bool _displayAverage;

        public override void ExecuteCommand()
        {
            Stopwatch stopwatch = new Stopwatch();
            List<int> times = new List<int>();

            try
            {
                using (WebClient client = new WebClient())
                {
                    for (int i = 0; i < _repeat; i++)
                    {
                        stopwatch.Start();
                        client.DownloadString(_url);
                        stopwatch.Stop();
                        times.Add(stopwatch.Elapsed.Milliseconds);
                        stopwatch.Reset();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured while trying to download from {0}", _url);
                Console.WriteLine(e.Message);
                throw;
            }

            if (_displayAverage)
                Console.WriteLine("Average time of {0} requests : {1} milliseconds", _repeat, times.Average());
            else
            {
                int i = 1;
                foreach (var time in times)
                {
                    Console.WriteLine("Elapsed time for request number {0} : {1} milliseconds", i, time);
                    i++;
                }
            }

        }

        public override void CheckArguments()
        {
            if (_url == null) throw new OptionException("No URL specified", "url");
        }

        public override OptionSet getOptions()
        {
            return new OptionSet(){
                {"-url=|url", "Displays the URL content", 
                v => _url = v},
                {"-times=|times", "Number of attempts to load the specified page",
                (int v) => _repeat = v},
                {"-avg|avg", "Displays the average donwloading time", v => _displayAverage = v != null}
            };
        }
    }
}
