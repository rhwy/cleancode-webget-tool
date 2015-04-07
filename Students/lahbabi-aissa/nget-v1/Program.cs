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
			Console.Write("Utilisataion : <get|test> -url <url> <-times|-save> <nb_of_loads> -avg");
			Console.ReadKey(true);
		}
		
		public static void Main(string[] args)
		{
			// Incorrect use
			if (args.Length < 2 || (args[0] != "get" && args[0] != "test")) {
				printHelp();
				return;
			}
			
			
			if (args[0] == "get") {
				// Get content of URL
				WebFile web = new WebFile(args[2]);
				
				if (args.Length > 4 && args[3] == "-save" ) {
					// Download it into specified filename
					web.download(args[4]);
				} else {
					// Just print it
					web.print();
				}
				
			} else if (args[0] == "test") {
				// Test and print loadtime
				
				Boolean printAvg = (args.Length > 5 && args[5] == "-avg");
				
				WebFile web = new WebFile(args[2]);
				web.times(Convert.ToInt32(args[4]), printAvg);
				
				
			} else {
				printHelp();
				return;
			}

			
			Console.ReadKey(true);
		}
		
		
	}
}