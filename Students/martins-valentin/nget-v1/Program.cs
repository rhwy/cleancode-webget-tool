/*
 * Created by SharpDevelop.
 * User: Valentin
 * Date: 07/04/2015
 * Time: 12:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace nget_v1
{
	class Program
	{
		public static void Main(string[] args)
		{
			errorPrimary(args);
			
			string contentUrl = new WebClient().DownloadString(args[2]);
			
			if(string.IsNullOrEmpty(contentUrl) || string.IsNullOrWhiteSpace(contentUrl))
				throw new Exception("Erreur : L'url ne contient aucunes données");
			
			if(args.Length == 3){
				Console.WriteLine(contentUrl);
			} else {
			
				if(args[0] == "get") {
				   if(args[3] != "-save")
						throw new Exception("Erreur du quatrième argument, le quatrième argument valide pour l'option \"get\" est \"-save\".");
				   if(args.Length == 4)
						throw new Exception("Erreur : Aucun cinquième argument, le cinquième argument valide pour l'option \"get\" est la localisation du fichier à copier.");
				   
				   copyHtml(args[4], contentUrl);
				}
				
				if(args[0] == "test") {
					if(args[3] != "-times")
						throw new Exception("Erreur du quatrième argument, le quatrième argument valide pour l'option \"test\" est \"-times\".");
					if(args.Length == 4)
						throw new Exception("Erreur : Aucun cinquième argument, le cinquième argument valide pour l'option \"test\" est un entier pour le nombre de chargement du fichier.");
					
					if(args.Length >= 5)
						if(Convert.ToInt16(args[4]) < 0)
					   		throw new Exception("Erreur : cinquième argument incorrect, le cinquième argument doit être un entier supérieur à 0.");
					
					if(args.Length == 5)
						calculateTime(args[2], Convert.ToInt16(args[4]), false);
					
					if(args.Length == 6) {
						if(args[5] != "-avg")
					   		throw new Exception("Erreur : Sixième argument incorrect, le sixième argument valide pour l'option \"test\" est \"-avg\".");
						
						calculateTime(args[2], Convert.ToInt16(args[4]), true);
					}
				}
			
			}
			Console.ReadKey(true);
		}
		
		private static void errorPrimary(string[] args){
			if(args == null || args.Length < 3)
				throw new Exception("Erreur : Nombre de paramètre insuffisant.");
			
			if(args[0] != "get" && args[0] != "test")
				throw new Exception("Erreur du premier argument, le premier argument valide est \"get\" ou \"test\".");
			
			if(args[1] != "-url")
				throw new Exception("Erreur du second argument, le second argument valide est \"-url\".");
			
			if(args[2] == null)
				throw new Exception("Erreur du troisième argument, le troisième argument valide est une url.");
			
			if(args[0] == "test" && args.Length < 4)
				throw new Exception("Erreur : Aucun quatrième argument, le quatrième argument valide pour l'option test est \"-times\".");
		}
		
		
		private static void copyHtml(string path, string content)
		{
			TextWriter file = new StreamWriter(path);
			file.Write(content);
		}
		
		
		private static void calculateTime(string url, int nb, bool avg)
		{
			Stopwatch time;
			double sum = 0;
			for(int i=0; i<nb; i++){
				time = Stopwatch.StartNew();
				new WebClient().DownloadString(url);
				time.Stop();
				if(avg) sum += time.ElapsedMilliseconds;
				else Console.WriteLine("Temps d'exécution numéro "+(i+1)+" : "+time.ElapsedMilliseconds+" ms");
			}
			if(avg) Console.WriteLine("Temps d'exécution moyen : "+sum/nb+" ms");
		}
		
	}
}