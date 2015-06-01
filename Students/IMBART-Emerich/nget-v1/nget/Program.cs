/*
 * Created by SharpDevelop.
 * User: 626
 * Date: 01/06/2015
 * Time: 17:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;


namespace nget
{
	class Program
	{
		public static void Main(string[] args)
		{		
			
			if(args.Length == 3 && args[0] == "get" && args[1] == "-url") /* test requete de type ==>  nget.exe get -url "http://abc" */ 
			{
				Console.WriteLine("Affichage du fichier \n\n ");
				print(args[2]);
			}
			else if(args.Length == 5 && args[0] == "get" && args[1] == "-url" && args[3] == "-save") /* test requete de type ==> nget.exe get -url "http://abc" -save "c:\abc.json" */ 
			{
				Console.WriteLine("\n\nFichier : " + args[2] + " copié dans : \n" + args[4]);
				download(args[2],args[4]);
			}
			else if(args.Length == 5 && args[0] == "test" && args[1] == "-url" && args[3] == "-times") /* test requete de type ==>  nget.exe test -url "http://abc" -times 5  */ 
			{
				int compteur; 
				try{
					compteur = Convert.ToInt32(args[4]);
					test(args[2],compteur,0);
				}catch(Exception e){
					Console.WriteLine(e.Message);
				}
			}
			else if(args.Length == 6 && args[0] == "test" && args[1] == "-url" && args[3] == "-times" && args[5]=="-avg") /* test requete de type ==>  nget.exe test -url "http://abc" -times 5 -avg */ 
			{
				int compteur; 
				try{
					compteur = Convert.ToInt32(args[4]);
					test(args[2],compteur,1);
				}catch(Exception e){
					Console.WriteLine(e.Message);
				}
			}
			
			Console.ReadKey(true);
		}
		
		//Fonction de téléchargement de l'URL
		private static void download(string URL, string path)
       	{
           var wc = new System.Net.WebClient();
           try{
           		wc.DownloadFile(URL, path);
           }catch(System.Net.WebException e){
           	Console.WriteLine(e.Message);
           }
       	}
		
		//Fonction d'affichage de l'URL
		private static void print(String URL)
		{
			var wc = new System.Net.WebClient();
			try{
           		Console.WriteLine(wc.DownloadString(URL));
           }catch(System.Net.WebException e){
           	Console.WriteLine(e.Message);
           }
			
		}
		
		//fonciton de chargement de l'URL
		private static void NoPrint(string URL)
		{
			var wc = new System.Net.WebClient();
			wc.DownloadString(URL);
		}
		
		//Fonction de routage des tests de chargement
		private static void test(string URL,int compteur, int mode)
		{
			long[] tab = new long[compteur];
			long moyenne = 0;
			Stopwatch sw = new Stopwatch(); // variable timer
			
			for(int i = 0 ; i < compteur ; i++)
			{
				sw.Start();
				if(mode == 0) // mode avec affichage
					print(URL);
				else
					NoPrint(URL); // mode sans affichage
				
				sw.Stop();
				tab[i]=sw.ElapsedMilliseconds;
				moyenne += tab[i];				
				sw = Stopwatch.StartNew(); // reset du timer
			}
				
			Console.Clear();
			if(mode == 0)
				for(int i = 0 ; i < compteur ; i++)
					Console.WriteLine("Chargement : " + (i+1) + ": "+ tab[i] + "ms");
			else
				Console.WriteLine("Temps moyen de chargement " + moyenne/compteur +" ms");
		}
	}
}