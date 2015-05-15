using System;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace ngetv1
{
	public class Helper
	{
		private string[] args;

		public Helper (string[] args)
		{
			this.args = args;
		}

		public string displayFromURL() {
			return (new WebClient ()).DownloadString (args[2]);
		}

		public void saveContentFromURL() {
			TextWriter tw = new StreamWriter(args[2]);
			tw.Write(displayFromURL());
			Console.WriteLine("Contenu sauvé");
		}

		public long testForURL() {
			Stopwatch sw;

			sw = Stopwatch.StartNew();
			(new WebClient ()).DownloadString (args[2]);
			sw.Stop();

			return sw.ElapsedMilliseconds;
		}

		public long testForURLAverage() {
			int iteration = Convert.ToInt16 (args [4]);

			long swSum = 0;

			for (int i = 0; i < iteration; i++) {
					swSum += testForURL();
			}

			return swSum / iteration;
		}
	}
}

