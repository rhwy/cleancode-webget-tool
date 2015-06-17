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
        static Stopwatch stopwatch;
        static TimeSpan ts;

        public static void test_time_access(Options options)
        {
            for (int i = 0; i < options.nbLoops; i++)
            {
                Console.Write("Loop " + (i + 1) + " :");
                stopwatch = new Stopwatch();
                stopwatch.Start();

                NgetTools.getWebContent(options.url);

                stopwatch.Stop();
                ts = stopwatch.Elapsed;
                Console.Write(ts.Milliseconds + "ms\n");
            }
        }

        public static void test_time_access_average(Options options)
        {
            double sum = 0;
            for (int i = 0; i < options.nbLoops; i++)
            {
                stopwatch = new Stopwatch();
                stopwatch.Start();

                NgetTools.getWebContent(options.url);

                stopwatch.Stop();
                ts = stopwatch.Elapsed;
                sum += ts.Milliseconds;
            }
            Console.WriteLine("Average time for " + options.nbLoops + " loop(s) : " + (sum / options.nbLoops) + "ms");
        }
    }
}
