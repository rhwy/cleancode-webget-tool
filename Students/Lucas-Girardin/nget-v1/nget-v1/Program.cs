/*
 * Created by SharpDevelop.
 * User: Lucas
 * Date: 01/06/2015
 * Time: 17:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;
using System.Net;

namespace nget_v1
{
	class Program
	{
		public static void Main(string[] args)
		{
			
			if(args.Length < 3){
				Console.WriteLine("Erreur, pas assez d'arguments");
			}else if(args.Length == 3){
				if(args[0].Equals("get") && args[1].Equals("-url")){
					Program.download(args[2]);
				}else{
					Console.WriteLine("Erreur, arguments inconnus");
				}
			}else if(args.Length == 5){
				if(args[0].Equals("get") && args[1].Equals("-url") 
				   && args[3].Equals("-save")){
					Program.save(args[2], args[4]);
				}else if(args[0].Equals("test") && args[1].Equals("-url") 
				         && args[3].Equals("-times")){
					Program.time(args[2], args[4]);
				}else{
					Console.WriteLine("Erreur, arguments inconnus");
				}
			}else if(args.Length == 6){
				if(args[0].Equals("test") && args[1].Equals("-url") 
				   && args[3].Equals("-times") && args[5].Equals("-avg")){
					Program.avg(args[2], args[4]);
				}else{
					Console.WriteLine("Erreur, arguments inconnus");
				}
			}
			
			Console.WriteLine("Appuyez sur n'improte quel touche pour fermer");
			Console.ReadKey();
		}
		
		//Affiche le fichier passé en paramètre sur la console 
		public static void download(String url){
			Console.WriteLine("Download");
			WebClient wc = new WebClient();
			Console.WriteLine(wc.DownloadString(url));
		}
		
		//Enregistre le fichier passé en paramètre dans un fichier passé en second paramètre
		public static void save(String url, String path){
			Console.WriteLine("Save");
			WebClient wc = new WebClient();
           	wc.DownloadFile(url, path);
		}
		
		//Calcule plusieur fois le temps requis pour charger un fichier en paramètre
		public static void time(String url, String nb){
			Console.WriteLine("Time");	
			int n = 0;
			try{
				n = Convert.ToInt32(nb);
			}catch(FormatException ex){
				Console.WriteLine("Erreur d'argument");
				return;
			}
 			for(int i = 0; i < n; i++){	
				//Sert à calculer le temps d'excecution
				Stopwatch sw = new Stopwatch();
				sw.Start();
				WebClient wc = new WebClient();
				wc.DownloadString(url);
				sw.Stop();
				Console.WriteLine(sw.ElapsedMilliseconds + " ms");	
			}
		}

		//Calcule la moyenne le temps requis pour charger un fichier en paramètre		
		public static void avg(String url, String nb){
			Console.WriteLine("avg");
			int n = 0;
			try{
				n = Convert.ToInt32(nb);
			}catch(FormatException ex){
				Console.WriteLine("Erreur d'argument");
				return;
			}
			double moyenne = 0;
 			for(int i = 0; i < n; i++){
				//Sert à calculer le temps d'excecution				
				Stopwatch sw = new Stopwatch();
				sw.Start();
				WebClient wc = new WebClient();
				wc.DownloadString(url);
				sw.Stop();
				moyenne += sw.ElapsedMilliseconds;	
			}
			moyenne = moyenne /n;
			Console.WriteLine("Moyenne : " + moyenne + " ms");
		}
	}
}