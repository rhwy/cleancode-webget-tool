/*
 * Crée par SharpDevelop.
 * Utilisateur: Aissa
 * Date: 15/05/2015
 * Heure: 18:04
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;

namespace nget_v1
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	public class Nget
	{
		public Nget(string[] args)
		{
			if (args.Length < 2 || (args[0] != "get" && args[0] != "test")) {
				printHelp(); // Incorrect use
				return;
			}
			
			if (args[0] == "get") {
				get(args);
			} else if (args[0] == "test") {			
				loadtime(args);
			} else {
				printHelp(); // Incorrect use
				return;
			}
		}

		public void get(string[] args)
		{
			// Get content of URL
			WebFile web = new WebFile(args[2]);
			
			if (args.Length > 4 && args[3] == "-save" ) {
				// Download it into specified filename
				web.download(args[4]);
			} else {
				// Just print it
				web.print();
			}
		}

		void loadtime(string[] args)
		{
			// Test and print loadtime
			Boolean printAvg = (args.Length > 5 && args[5] == "-avg");
			
			WebFile web = new WebFile(args[2]);
			web.times(Convert.ToInt32(args[4]), printAvg);
		}
		
		public void printHelp() {
			Console.Write("Utilisataion : <get|test> -url <url> <-times|-save> <nb_of_loads> -avg");
		}
	}
}
