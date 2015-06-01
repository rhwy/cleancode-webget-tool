/*
 * Created by SharpDevelop.
 * User: Rémy
 * Date: 01/06/2015
 * Time: 17:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.IO;

namespace nget_v1
{
	class Program
	{
		
		public static String resultat(string url) {
			
			WebClient wc = new WebClient ();
			Stream stream = wc.OpenRead (url);
			StreamReader sreader = new StreamReader (stream);
			String str = sreader.ReadToEnd();
			stream.Close ();
			sreader.Close ();
			return str;
		}
		
		public static String tempsEcoule(string url) {
			
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

			Stopwatch timer = new Stopwatch();
			timer.Start();

			HttpWebResponse response = (HttpWebResponse)request.GetResponse();

			timer.Stop();

			TimeSpan timeTaken = timer.Elapsed;
			
			return timeTaken.TotalSeconds.ToString();
			
		}
		
		public static String moyenneTemps(string url, int times) {
			
			List<TimeSpan> list = new List<TimeSpan>();
			int i = 0;
			while(i < times) {
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

				Stopwatch timer = new Stopwatch();
				timer.Start();

				HttpWebResponse response = (HttpWebResponse)request.GetResponse();

				timer.Stop();

				TimeSpan timeTaken = timer.Elapsed;
				list.Add(timeTaken);
				i++;
			}
			TimeSpan timeaverage = TimeSpan.FromSeconds(list.Average(time=>time.TotalSeconds));
			return timeaverage.ToString();
			
		}
		
		public static void Main(string[] args)
		{
			switch(args.Length) {
				case 3:
					
					if(args[0] == "get" && args[1] == "-url") {
						string str = resultat(args[2]);
						Console.WriteLine(str);
						
					} else {
						
						Console.WriteLine("Problème de paramètre");
						
					}
					break;
					
				case 5:
					
					if(args[0] == "get" && args[1] == "-url" && args[3] == "-save") {
						
						string str = resultat(args[2]);
						System.IO.File.WriteAllText(@args[4], str);
						
					} else if(args[0] == "test" && args[1] == "-url" && args[3] == "-times") {
						
						int i = 0;
						int times = Convert.ToInt32(args[4]);
						while(i < times){
							String str = tempsEcoule(args[2]);
							Console.WriteLine(str+"s");
							i++;
						}
							
					} else {
						
						Console.WriteLine("Problème de paramètre");
						
					}
					break;
					
				case 6:
					
					if(args[0] == "test" && args[1] == "-url" && args[3] == "-times" && args[5] == "-avg") {
						
						int times = Convert.ToInt32(args[4]);
						String str = moyenneTemps(args[2], times);
						Console.WriteLine(str+"s");
						Console.ReadKey(true);
						
						
					} else {
						
						Console.WriteLine("Problème de paramètre");
						
					}
					
					break;
					
				default:
					Console.WriteLine("Problème de paramètre");
					break;
			}
			Console.ReadKey(true);
		}
	}
}