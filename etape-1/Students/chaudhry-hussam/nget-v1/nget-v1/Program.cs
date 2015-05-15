using System;

namespace ngetv1
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			if (args == null || args.Length == 0) {
				Console.WriteLine ("Pas d'arguments");
				return;
			}

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

			}
		}
	}
}
