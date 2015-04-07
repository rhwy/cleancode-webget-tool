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
				if (args == null || args.Length == 0) {
					throw new Exception (getUsage ());
				}

				switch (args [0]) {

				case "get":
					getFunction (args);
					break;
				case "test":
				//TODO TEST
					break;
				default:
					throw new Exception (getStringUnknownParameter (args [0]));
				}
			} catch (Exception e) {
				Console.WriteLine ("ERROR");
				Console.WriteLine (e);
			}
		}

		private static string getUsage ()
		{
			return "TODO Print usage...";
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

			// Si l'URL de destination est renseignée
			if (destUrl != null && !String.IsNullOrEmpty (destUrl)) {

				Console.WriteLine ("Save to " + sourceUrl);

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
