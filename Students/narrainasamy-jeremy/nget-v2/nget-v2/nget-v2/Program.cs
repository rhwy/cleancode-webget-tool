/*
 * Created by SharpDevelop.
 * User: Jkn1092
 * Date: 17/06/2015
 * Time: 15:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;

namespace nget_v2
{
	class Program
	{
		
		public static void Main(string[] args)
		{
	
			try{
				
				if(args[0].Equals("get")){
					
					if(args.Contains("-url") && args.Contains("-save")){ System.IO.File.WriteAllText(args[4],getContenuUrl(args[2])); return;}
					if(args.Contains("-url")){ Console.WriteLine(getContenuUrl(args[2])); return;}
				}
				
				if(args[0].Equals("test")){
					if(args.Contains("-url") && args.Contains("-times") && args.Contains("-avg")){ getChargementUrl(args[2], int.Parse(args[4]), true); return;}
					if(args.Contains("-url") && args.Contains("-times")){ getChargementUrl(args[2], int.Parse(args[4]), false); return;}
				}
						
			}catch(Exception e){
				Console.WriteLine("Une erreur est survenue : " + e);
			}
			
		}
		
		public static String getContenuUrl(String url){
			var client = new WebClient();
	        var s = client.DownloadString(url);
	        return s;
		}
		
		public static void getChargementUrl(String url, int nbTest, bool avg){
			var request = (HttpWebRequest)WebRequest.Create(url);
			System.Diagnostics.Stopwatch timer = new Stopwatch();
			
			var listeTemps = new List<TimeSpan>();
			
			for(var i = 0; i < nbTest; i++){
				timer.Start();
				var response = (HttpWebResponse)request.GetResponse();
				timer.Stop();
				
				if(avg){
					listeTemps.Add(timer.Elapsed);
				}else{
					Console.WriteLine(timer.Elapsed.TotalSeconds);
				}
			}
			
			if(avg){
				Console.WriteLine(TimeSpan.FromSeconds(listeTemps.Average(time=>time.TotalSeconds)).TotalSeconds);
			}
		}
	
	}
}