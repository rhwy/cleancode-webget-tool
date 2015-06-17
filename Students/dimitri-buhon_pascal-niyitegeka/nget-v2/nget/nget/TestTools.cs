using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nget
{
    class TestTools
    {
        private static TestTools instance;
        Stopwatch stopwatch;
        TimeSpan ts;

        private TestTools() { }

        public static TestTools getInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TestTools();
                }
                return instance;
            }
        }

        public void test_time_access(Options options)
        {
            for (int i = 0; i < options.NbLoops; i++)
            {
                Console.Write("Loop " + (i + 1) + " :");
                stopwatch = new Stopwatch();
                stopwatch.Start();

                NgetTools.getInstance.getWebContent(options.Url);

                stopwatch.Stop();
                ts = stopwatch.Elapsed;
                Console.Write(ts.Milliseconds + "ms\n");
            }
        }

        public void test_time_access_average(Options options)
        {
            double sum = 0;
            for (int i = 0; i < options.NbLoops; i++)
            {
                stopwatch = new Stopwatch();
                stopwatch.Start();

                NgetTools.getInstance.getWebContent(options.Url);

                stopwatch.Stop();
                ts = stopwatch.Elapsed;
                sum += ts.Milliseconds;
            }
            Console.WriteLine("Average time for " + options.NbLoops + " loop(s) : " + (sum / options.NbLoops) + "ms");
        }
    }
}
