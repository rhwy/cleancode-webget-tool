using System;

namespace ngetv1
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			WebGet webGet = new WebGet();
			string result = string.Empty;

			result = webGet.checkForArguments(args);
			Console.WriteLine (result);
			Console.ReadLine ();

			/*
			System.Net.WebClient client = new System.Net.WebClient();

			if (args [0] == "get") {
				if (args [1] == "-url") {

					String webpage = client.DownloadString (args [2]);

					if (args.Length >= 4 && args [3] == "-save") {
						System.IO.File.WriteAllText (args [4], webpage);
						return;
					}

					Console.WriteLine (webpage);
				}
			}

			if (args [0] == "test") {
				System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch ();

				if (args [1] == "-url") {
					if (args [3] == "-times") {
				
						int nb = 0;
						TimeSpan compteur = new TimeSpan();
						while (nb < Int32.Parse(args[4])) {
							timer.Start ();
							client.DownloadString (args [2]);
							timer.Stop ();

							TimeSpan ts = timer.Elapsed;

							Console.WriteLine (ts);
							compteur += ts;
							timer.Reset ();
							nb++;
						}

						if (args.Length >= 6 && args [5] == "-avg") {
							//Console.WriteLine(compteur.TotalMilliseconds / Int32.Parse(args[4]));
						}
					}


				}

			}*/
		}
	}

	class WebGet
	{
		public string checkForArguments(string[] args)
		{
			string result = string.Empty;
			string action = string.Empty;

			if (args == null || args.Length == 0) {
				result = "Pas d'arguments";
			} else {
				result = checkAction (args);
			}

			return result;
		}

		public string checkAction(string[] arguments)
		{
			string result = String.Empty;
			switch (arguments[0]) {

			case "get": result = actionGet (arguments);
				break;
			
			case "test": result = actionTest (arguments);
				break;
			}
			return result;
		}

		public string actionGet(string[] args)
		{
			string result = string.Empty;
			if(!checkURLArgument(args[1]) && args[2] != null) {
				/// à isoler : System.Net.WebClient client = new System.Net.WebClient (); 
				System.Net.WebClient client = new System.Net.WebClient ();
				string webpage = client.DownloadString (args [2]);

				if (args.Length >= 4 && args [3] == "-save") {
					saveInFile (webpage, args[4]);
				} else
					result = webpage;
			}
			return result;
		}

		public string actionTest(string[] args)
		{
			return "ss";
		}

		public bool checkURLArgument(string urlAgument)
		{
			if (urlAgument == null || urlAgument != "-url")
				return true;
			
			return false;
		}

		public void saveInFile(string toWrite, string path)
		{	
			/// à isoler
			System.IO.File.WriteAllText (path, toWrite);
		}
	}
}
