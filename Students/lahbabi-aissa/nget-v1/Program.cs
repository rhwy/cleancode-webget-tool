/*
 * Crée par SharpDevelop.
 * Utilisateur: Aissa
 * Date: 07/04/2015
 * Heure: 11:42
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.Net;

namespace nget_v1
{
	class Program
	{
		public static void printHelp() {
			Console.Write("Utilisataion : ...");
			Console.ReadKey(true);
		}
		
		public static void Main(string[] args)
		{
			if (args.Length < 2 || (args[0] != "get" && args[0] == "test")) {
				printHelp();
				return;
			}
			
			if (args[0] == "get") {
				
			} else if (args[0] == "test") {
			
			} else {
				printHelp();
			}
			
			var webRequest = WebRequest.Create(@"http://api.openweathermap.org/data/2.5/weather?q=paris&units=metric");
			

			
			Console.ReadKey(true);
		}
		
		
	}
}