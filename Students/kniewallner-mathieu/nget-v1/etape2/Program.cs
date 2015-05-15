using System;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace ngetv1 {
	class MainClass {
		public static void Main (string[] args) {

			if (testParameters(args)) {
			Helper helper = new Helper(args);
				if (args[0] == "get") {
					if (args.Length <= 3) {
							Console.WriteLine(helper.displayFromURL ());
						} else {
							helper.saveContentFromURL ();
						}
				} else {
					if (args.Length <= 5) {
						for (int i = 0; i < Convert.ToInt16(args[4]); i++)
							Console.WriteLine(helper.testForURL () + "ms");
					} else {
						Console.WriteLine("Moyenne : " + helper.testForURLAverage () + "ms");
					}
				}
			}

			Console.WriteLine("Appuyez sur une touche pour quitter");
			Console.ReadKey (true);
		}
		
		private static Boolean testParameters(string[] args) {
			if (args == null || args.Length < 3)
				throw new Exception ("Le nombre de paramètres doit être supérieur à 2");
			
			if (args[0] != "get" && args[0] != "test")
				throw new Exception ("Paramètre 1 non reconnu, il doit être 'get' ou 'test'");
			
			if (args[1] == null || args[1] != "-url")
				throw new Exception ("Le paramètres 2 doit être '-url'");
			
			if (args[2] == null)
				throw new Exception ("Paramètre 3 manquant, il faut définir l'url");
			
			if (args[0] == "get" && args.Length > 3) {
				if (args[3] != "-save")
					throw new Exception ("Le paramètre 4 doit être '-save'");
				
				if (args.Length < 5)
					throw new Exception ("Paramètre 5 manquant, il faut définir le fichier de sortie");
			}
			
			if (args[0] == "test") {
				if (args.Length < 5)
					throw new Exception ("Nombre de paramètres insuffisant");
				
				if (args[3] != "-times")
					throw new Exception ("Paramètre 4 non reconnu");
				
				int timesInt;
				bool isTimesNumeric = int.TryParse(args[4], out timesInt);
				
				if (!isTimesNumeric)
					throw new Exception ("Le paramètre 5 doit être numérique");
				
				if (args.Length > 5 && args[5] != "-avg")
					throw new Exception ("Paramètre 6 non reconnu");
			}
			return true;
		}
	}
}
