using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Diagnostics;

namespace wget
{
    class MyCommand
    {
        public MyCommand()
        {
        }

        public void getCommande()
        {
            getCommande("-url", "http://www.cs.tut.fi/~jkorpela/fileurl.html", "-save", "C:\\Users\\Yehouda\\Desktop\\test.txt");
        }

        public void getCommande(string option, string url)
        {
            getCommande(option, url, "", "");
        }

        public void getCommande(string option, string url, string save, string file)
        {
            var client = new WebClient();
            string data = client.DownloadString(url);
            if (save != null && save != "")
            {
                System.IO.File.WriteAllText(file, data);
            }
            else
            {
                Console.WriteLine(data);
            }
        }

        public void testGetCommand(int len) {
            testGetCommand(len, "-url", "http://www.cs.tut.fi/~jkorpela/fileurl.html", "-save", "C:\\Users\\Yehouda\\Desktop\\test.txt", "-avg");
        }

        public void testGetCommand(int len, string option, string url)
        {
            testGetCommand(len, option, url, "", "", "");
        }

        public void testGetCommand(int len, string option, string url, string save, string file)
        {
            testGetCommand(len, option, url, save, "", "");
        }

        public void helpCommand()
        {
            Console.WriteLine("command get : ");
            Console.WriteLine(" -url yourURL");
            Console.WriteLine(" -url yourURL -save yourFile");
            Console.WriteLine("command test : ");
            Console.WriteLine(" -url yourURL -times nbTimes");
            Console.WriteLine(" -url yourURL -times nbTimes -avg");
            Console.WriteLine("command exit, qui ou q pour quitter");
        }

        public void testGetCommand(int len, string option, string url, string save, string file, string avg)
        {
            if ( !Program.isEmpty(avg) && avg.Equals("-avg") )
            {
                long time = 0;
                for (int i = 0; i < len; i++)
                {
                    var watch = Stopwatch.StartNew();
                    getCommande(option, url, save, file);
                    watch.Stop();
                    time += watch.ElapsedMilliseconds;
                }
                Console.WriteLine("en moyenne : " + (time / len) + " millis");
            }
            else
            {
                for (int i = 0; i < len; i++)
                {
                    var watch = Stopwatch.StartNew();
                    getCommande(option, url, save, file);
                    watch.Stop();
                    Console.WriteLine(watch.ElapsedMilliseconds + " Milisecond");
                }
            }
        }
    }

}
