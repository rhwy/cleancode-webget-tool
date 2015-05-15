using System;
using System.Net;
using System.IO;

namespace ngetv1
{
	public class GetTask
	{
		public GetTask (string[] args)
		{
			DoGet (args);
		}

		private void DoGet(string[] args)
		{

			string sourceUrl = "";
			string destUrl = "";

			// Gestion des paramètres
			int length = args.Length;
			for (int i = 0; i <= length - 1; i++) {

				if (args [i] == null || String.IsNullOrEmpty (args [i])) {
					throw new Exception (UsageUtils.GetUsage ());
				}

				if (args [i] == "-url") {
					ArrayUtils.checkArrayLengthCorrect (i, length);
					sourceUrl = args [i + 1];
				} else if (args [i] == "-save") {
					ArrayUtils.checkArrayLengthCorrect (i, length);
					destUrl = args [i + 1];
				}
			}

			if (sourceUrl == null || String.IsNullOrEmpty (sourceUrl)) {
				throw new Exception (UsageUtils.GetStringUnknownParameter (sourceUrl));
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
	}
}

