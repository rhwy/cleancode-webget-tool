/*
 * Created by SharpDevelop.
 * User: Jkn1092
 * Date: 01/06/2015
 * Time: 17:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;

namespace nget_v1
{
	class Program
	{
		public static void Main(string[] args)
		{
			
			switch(args.Length){
				case 3:
					if(args[0] == "get" && args[1] == "-url"){
						var contenu = getContenuUrl(args[2]);
						Console.WriteLine(contenu);
					}else{
						Console.WriteLine("Une erreur est survenue : Nombre d'arguments insuffisant");
					}
					break;
					
				case 5:
					if(args[0] == "get" && args[1] == "-url" && args[3] == "-save"){
						var contenu = getContenuUrl(args[2]);
						System.IO.File.WriteAllText(args[4],contenu);
					}
					else if(args[0] == "test" && args[1] == "-url" && args[3] == "-times"){
						var nbTest = Convert.ToInt32(args[4]);
						
						for(var i = 0; i < nbTest; i++){
							var temps = getChargementUrl(args[2]);
							Console.WriteLine(temps.TotalSeconds);
						}
						
					}else{
						Console.WriteLine("Une erreur est survenue : Nombre d'arguments in");
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
						Console.WriteLine(moyenne);
						
					}else{
						Console.WriteLine("Une erreur est survenue : Nombre d'arguments in");
					}
					break;
					
				default:
					Console.WriteLine("Une erreur est survenue : Nombre d'arguments in");
					break;
			}
						
			Console.Write("Press any key to exit . . . ");
			Console.ReadKey(true);
		}
		
		public static String getContenuUrl(String url){
			
			var client = new WebClient();
			client.Headers.Add ("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
	        
			var data = client.OpenRead (url);
	        var reader = new StreamReader (data);
	        var s = reader.ReadToEnd ();
	        
	        data.Close ();
	        reader.Close ();
	        
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