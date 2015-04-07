using System;
using System.Net;
using System.IO;

namespace ngetv1
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			try {
				// Tester le tableau d'arguments
				if (args == null || args.Length == 0) {
					throw new Exception (getUsage ());
				}

				switch (args [0]) {

				case "get":
					getFunction (args);
					break;

				case "test":
					testFunction (args);
					break;

				default:
					throw new Exception (getStringUnknownParameter (args [0]));
				}

			} catch (Exception e) {
				Console.WriteLine ("ERROR");
				Console.WriteLine (e);
				Console.WriteLine (getUsage ());
			}
		}

		/// <summary>
		/// Return usage
		/// </summary>
		/// <returns>The usage.</returns>
		private static string getUsage ()
		{
			return "Print usage...";
		}

		/// <summary>
		/// Retourner message d'erreur
		/// </summary>
		/// <returns>The string unknown parameter.</returns>
		/// <param name="par">Par.</param>
		private static string getStringUnknownParameter (string par)
		{
			return "ERROR : Unknown parameter " + par;
		}

		/// <summary>
		/// Test function 
		/// </summary>
		/// <param name="args">Arguments.</param>
		private static void testFunction (string[] args)
		{

			string sourceUrl = "";
			int time = 0;
			Boolean isAvg = false;

			int length = args.Length;

			// Récupèration des arguments
			for (int i = 0; i <= length - 1; i++) {

				if (args [i] == null || String.IsNullOrEmpty (args [i])) {
					throw new Exception (getUsage ());
				}

				if (args [i] == "-url") {
					checkArrayLength (i, length);
					sourceUrl = args [i + 1];
				} else if (args [i] == "-times") {
					checkArrayLength (i, length);
					time = Int32.Parse (args [i + 1]);
				} else if (args [i] == "-avg") {
					isAvg = true;
				}
			}

			TimeSpan totalDuration = new TimeSpan ();
			for (int i = 0; i <= time; i++) {
				
				DateTime before = DateTime.Now;
				(new WebClient ()).DownloadString (sourceUrl);
				DateTime after = DateTime.Now;

				if (!isAvg) {
					Console.WriteLine ("Duration (ms) : " + after.Subtract (before).TotalMilliseconds);
				} else {
					totalDuration += (after - before);
				}
			}

			if (isAvg) {
				Console.WriteLine ("Total duration average (ms) : " + totalDuration.TotalMilliseconds / time);
			}

		}

		/// <summary>
		/// Faire le get
		/// </summary>
		/// <param name="parameters">Parameters.</param>
		private static void getFunction (string[] args)
		{

			string sourceUrl = "";
			string destUrl = "";

			// Gestion des paramètres
			int length = args.Length;
			for (int i = 0; i <= length - 1; i++) {

				if (args [i] == null || String.IsNullOrEmpty (args [i])) {
					throw new Exception (getUsage ());
				}
					
				if (args [i] == "-url") {
					checkArrayLength (i, length);
					sourceUrl = args [i + 1];
				} else if (args [i] == "-save") {
					checkArrayLength (i, length);
					destUrl = args [i + 1];
				}
			}

			if (sourceUrl == null || String.IsNullOrEmpty (sourceUrl)) {
				throw new Exception (getStringUnknownParameter (sourceUrl));
			}

			var page = (new WebClient ()).DownloadString (sourceUrl);

			Console.WriteLine ("Printing content of " + sourceUrl);
			Console.WriteLine ("");
			Console.WriteLine (page);
			Console.WriteLine ("");

			// Si l'URL de destination est renseignée
			if (destUrl != null && !String.IsNullOrEmpty (destUrl)) {

				Console.WriteLine ("Saving to " + sourceUrl);

				TextWriter tw = new StreamWriter (destUrl, true);
				tw.WriteLine (page);
				tw.Close ();

			}

		}

		/// <summary>
		/// Vérifier si index + 1 <= length +1
		/// </summary>
		/// <param name="index">Index.</param>
		/// <param name="length">Length.</param>
		private static void checkArrayLength (int index, int length)
		{
			if (index + 1 > length - 1) {
				throw new Exception (getUsage ());
			}
		}
	}
}
