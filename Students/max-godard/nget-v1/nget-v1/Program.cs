/*
 * Created by SharpDevelop.
 * User: Max
 * Date: 07/04/2015
 * Time: 12:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Net;
using System.Diagnostics;


namespace nget_v1
{
	class Program
	{
		public const int ARGS_CMD_URL = 1;
		public const int ARGS_URL = 2;
		public const int ARGS_CMD_TIME = 3;
		public const int ARGS_NBTIME = 4;
		public const int ARGS_CMD_SAVE = 3;
		public const int ARGS_PATH = 4;
		public const int ARGS_CMD_AVG = 5;
		
		public static String getUrlContent(String url){
			try{
				return (new WebClient().DownloadString(url));
			}catch(Exception e){
				return ("Erreur lecture url: " + e.Message);
			}
		}
		
		public static void saveUrl(String url, String path){
			try{
				File.WriteAllText(path, getUrlContent(url));
			}catch(Exception e){
				Console.WriteLine("Erreur écriture fichier: " + e.Message);
			}
		}
		
		public static void testUrlLoadingTime(String url, int nbTime){			
			var sw = new Stopwatch();
			
			for(int cpt=1; cpt<nbTime+1; cpt++){
				sw.Start();
				try{
					String client = new WebClient().DownloadString(url);
				}catch(Exception e){
					Console.WriteLine(e.Message);
				}
				sw.Stop();
				
				Console.WriteLine("Temps" + (cpt) + ":" + sw.ElapsedMilliseconds + "ms");
				sw.Restart();
			}
		}
		
		public static void testAvgTime(String url, int nbTime){
			var sw = new Stopwatch();
			int avg=0;
			Console.WriteLine("Calcul de la moyenne en cours . . .");
			for(int cpt=1; cpt<nbTime+1; cpt++){
				sw.Start();
				String client = new WebClient().DownloadString(url);
				sw.Stop();
				avg += Convert.ToInt32(sw.ElapsedMilliseconds);
				sw.Restart();
			}
			avg /= nbTime;
			Console.WriteLine("Moyenne de temps de chargement: " + avg);
		}
		
		public static void Main(string[] args)
		{
			Console.WriteLine("nget.exe v1.0");
			
			if(args.Length < 3 || args.Length > 6){
				Console.Write("Nombre d'arguments incorrect . . . ");
				Console.ReadKey(true);
				return;
			}
			
			String url = args[ARGS_URL];
			
			switch(args[0].ToLower()){
				case "get":
					if(args.Length > 4 && args[ARGS_CMD_URL]=="-url" && args[ARGS_CMD_SAVE] == "-save"){
						String path = args[ARGS_PATH];
						saveUrl(url, path);
					}
					else if(args[ARGS_CMD_URL]=="-url"){
						Console.WriteLine(getUrlContent(url));
					}
					break;
					
				case "test":
					if(args.Length == 5 && args[ARGS_CMD_URL]=="-url" && args[ARGS_CMD_TIME]=="-times"){
						int nbTime = Convert.ToInt32(args[ARGS_NBTIME]);
						testUrlLoadingTime(url, nbTime);
					}else if(args.Length == 6 && args[ARGS_CMD_URL]=="-url" && args[ARGS_CMD_TIME]=="-times" && args[ARGS_CMD_AVG]=="-avg"){
						int nbTime = Convert.ToInt32(args[ARGS_NBTIME]);
						testAvgTime(url, nbTime);
					}else{
						Console.WriteLine("Arguments incorrects");
					}
					
					break;
				default:
					Console.WriteLine("Commande inconnue");
					break;
			}
			
			
			Console.ReadKey(true);
		}
		
		
		
	}
}