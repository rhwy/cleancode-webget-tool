using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace cleancode.tp
{
    public class Parser
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Parser(){}

        public string getJsonByAdress(string _url){
            var json = new WebClient().DownloadString(_url);
            return json;
        }
        /// <summary>
        /// Create new Json file with parameters
        /// </summary>
        /// <param name="_path"></param>
        /// <param name="_data"></param>
        public void generateJsonFile(string _path, string _data)
        {
            try { 
                File.WriteAllText(@_path, _data);
                Console.WriteLine("Le fichier est créer dans '{0}' ", @_path);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        /// <summary>
        /// Calculate five times loading file time and display on console 
        /// </summary>
        /// <param name="_url"></param>
        public void getLoadingFileTimes(string _url, int _eachTimes, bool _needAVG)
        {
            double[] tabResultTime = new double[_eachTimes+1];
            StringBuilder strTime = new StringBuilder("Diagnostic loading file times :\n");
            int i = 1;
            int tmp =  _eachTimes+1;
            while (i < tmp)
            {
               
                Stopwatch timer = new Stopwatch();
                timer.Start();
                using (var client = new WebClient())
                {
                    string result = client.DownloadString(_url);
                }
                timer.Stop();
                TimeSpan timeTaken = timer.Elapsed;
                if (_needAVG == false)
                {
                    strTime.Append("Test : " + i + " \nRésultat : " + timeTaken.Milliseconds.ToString() + "ms\n\n");
                }
                tabResultTime[i] = Convert.ToDouble(timeTaken.Milliseconds);
                i++;
            }
            
            if (_needAVG == true)
            {
                strTime.Append("Average : "+getAVG(tabResultTime)+"\n");
            }
            Console.WriteLine(strTime);
            
        }
        /// <summary>
        /// Obtenir la moyenne des temps de chargement d'un fichier
        /// </summary>
        /// <param name="_tabNb"></param>
        /// <returns></returns>
        public double getAVG(double[] _tabNb)
        {
            double total = 0;
            for (int i = 0; i < _tabNb.Length; i++)
            {
                total += _tabNb[i];
                //Console.WriteLine(_tabNb[i]);
            }
            return total / _tabNb.Length+1;
        }
    }
}
