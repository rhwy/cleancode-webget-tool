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
			
			switch(args.Length){
				case 3:
					if(args[0] == "get" && args[1] == "-url"){
						Console.WriteLine(getContenuUrl(args[2]));
					}else{
						Console.WriteLine("Une erreur est survenue.");
					}
					break;
					
				case 5:
					if(args[0] == "get" && args[1] == "-url" && args[3] == "-save"){
						System.IO.File.WriteAllText(args[4],getContenuUrl(args[2]));
					}
					else if(args[0] == "test" && args[1] == "-url" && args[3] == "-times"){
						var nbTest = Convert.ToInt32(args[4]);
						
						for(var i = 0; i < nbTest; i++){
							Console.WriteLine(getChargementUrl(args[2]).TotalSeconds);
						}
						
					}else{
						Console.WriteLine("Une erreur est survenue.");
					}
					break;
					
				case 6:
					if(args[0] == "test" && args[1] == "-url" && args[3] == "-times" && args[5] == "-avg"){
						
						var nbTest = Convert.ToInt32(args[4]);
						var listeTemps = new List<TimeSpan>();
						
						for(var i = 0; i < nbTest; i++){
							listeTemps.Add(getChargementUrl(args[2]));
						}
						
						var moyenne = TimeSpan.FromSeconds(listeTemps.Average(time=>time.TotalSeconds));
						Console.WriteLine(moyenne.TotalSeconds);
						
					}else{
						Console.WriteLine("Une erreur est survenue.");
					}
					break;
					
				default:
					Console.WriteLine("Une erreur est survenue.");
					break;
			}
						
			Console.Write("Press any key to exit . . . ");
			Console.ReadKey(true);
			
		}
		
		public static String getContenuUrl(String url){
			var client = new WebClient();
	        var s = client.DownloadString(url);
	        return s;
		}
		
		public static TimeSpan getChargementUrl(String url){
			var request = (HttpWebRequest)WebRequest.Create(url);
			System.Diagnostics.Stopwatch timer = new Stopwatch();
			
			timer.Start();
			var response = (HttpWebResponse)request.GetResponse();
			timer.Stop();
			
			return timer.Elapsed;
		}
		
	}
}