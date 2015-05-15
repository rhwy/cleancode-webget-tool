using System;
using System.Net;
using System.IO;
using System.Text;

namespace ngetv1
{
	public class GetTask
	{
		private string sourceUrl { get; set;}
		private string destUrl { get; set;}

		public GetTask (string[] args)
		{
			DoGet (args);
		}

		private void DoGet (string[] args)
		{

			StringBuilder sb = new StringBuilder ();
			
			string sourceUrl = "";
			string destUrl = "";

			// Gestion des paramètres
			int length = args.Length;

			InitializeAttributes (args, length);

			if (sourceUrl == null || String.IsNullOrEmpty (sourceUrl)) {
				throw new Exception (UsageUtils.GetStringUnknownParameter (sourceUrl));
			}

			var page = (new WebClient ()).DownloadString (sourceUrl);

			PrintLogs (sb, sourceUrl, destUrl, page);
		}

		private void InitializeAttributes(string[] args, int length)
		{
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
		}

		private void PrintLogs(StringBuilder sb, string sourceUrl, string destUrl, string page)
		{
			sb.Append ("Printing content of " + sourceUrl);
			sb.AppendLine ();
			sb.Append (page);
			sb.AppendLine ();

			// Si l'URL de destination est renseignée
			if (destUrl != null && !String.IsNullOrEmpty (destUrl)) {
				sb.Append ("Saving to " + sourceUrl);
				WriteToFile (destUrl, page);
			}

			WriteToConsole (sb);
		}

		private void WriteToConsole(System.Text.StringBuilder sb )
		{
			Console.WriteLine (sb);
		}

		private void WriteToFile(string destUrl, string content)
		{
			TextWriter tw = new StreamWriter (destUrl, true);
			tw.WriteLine (content);
			tw.Close ();
		}
	}
}

