/*
 * Created by SharpDevelop.
 * User: Griev_000
 * Date: 07/04/2015
 * Time: 12:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace nget_v2
{
	class Program
	{
		
		public long GetAverage(long[] duration)
	    {
	        if (duration.Length > 0)
	        {
	            long overallTime = 0;
	            for (int i = 0; i < duration.Length; i++)
	            {
	                overallTime += duration[i];
	            }
	            long average = overallTime/duration.Length;
	            return average;
	        }
	        else
	        {
	            return 0;
	        }
	    }
		
		public long[] Times(int repeats, string loadurl){
			Stopwatch s;
			long[] duration = new long[repeats];
			for (int i=0;i<repeats;i++){
				s=Stopwatch.StartNew();
				getContentByUrl(loadurl);
				s.Stop();
				duration[i] = s.ElapsedMilliseconds;
			}
		    return duration;
		}
		
		public String getContentByUrl(string url){
			WebClient wc = new WebClient();
			string content = "";
			try {
				content = wc.DownloadString(url);
			}catch (Exception) {
				
				content = "<h1>hello</h1>";
			}
			return content;
		}
		
		public bool writeUrlContentInFile(string contentUrl, string path){
			bool result = false;
			try{		
				StreamWriter sw = new StreamWriter(path);	
				sw.Write(contentUrl);
				sw.Close();
				result = true;			
			}catch(Exception ex){
				Console.WriteLine(ex);
			}
			return result;
		}
		
		public bool fonctionGet(string[] args){
			bool result = false;
			if(args.Length >= 2 && args[1] == "-url"){
				if(args.Length >= 5 && args[3] == "-save"){						
					if(writeUrlContentInFile(getContentByUrl(args[2]),args[4]))
						result = true;
				}else{
					Console.WriteLine(getContentByUrl(args[2]));
					result = true;
				}
			}
			return result;
		}
		
		public void fonctionTest(string[] args){
			if(args.Length >=4 &&( args[1] == "-url" && args[3] == "-times")){
				int fois;
				if(Int32.TryParse(args[4], out fois)){
					long[] durations = Times(fois, args[2]);
				    if (args.Length > 5 && args[5] == "-avg")
				    	Console.WriteLine("Moyenne du temps de chargement : " + GetAverage(durations) +" ms avg");
				    else
				    {
				        for (int i = 0; i < durations.Length; i++)
                            Console.WriteLine("Chargement n°" + (i + 1) + " : " + durations[i] + " ms");
				    }
				}
				else
					Console.WriteLine("parametre -time : entier attendu");
			}
		}
		
		public void start(string[] args){
			if(args.Length == 0){
				Console.WriteLine("saisir parametre");
			}else if(args[0] == "get"){
				if(!fonctionGet(args))
					Console.WriteLine("parametre de get : -url <url>");
			}else if(args[0] == "test")
				fonctionTest(args);
		}
		
		public static void Main(string[] args)
		{
			Program prog = new Program();
			prog.start(args);
			Console.ReadLine();
		}
	}
}