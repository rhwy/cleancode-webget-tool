using System;
using System.Net;
using System.IO;

namespace ngetv1
{
	public class TestTask
	{

		private string sourceUrl { get; set;}
		private int time { get; set;}
		private bool isAvg { get; set;}

		public TestTask (string[] args)
		{
			DoTest (args);
		}

		private void DoTest (string[] args)
		{
			int length = args.Length;

			InitializeAttributes (args, length);

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

		private void InitializeAttributes(string[] args, int length)
		{
			// Récupèration des arguments
			for (int i = 0; i <= length - 1; i++) {

				if (args [i] == null || String.IsNullOrEmpty (args [i])) {
					throw new Exception (UsageUtils.GetUsage ());
				}

				if (args [i] == "-url") {
					ArrayUtils.checkArrayLengthCorrect (i, length);
					sourceUrl = args [i + 1];
				} else if (args [i] == "-times") {
					ArrayUtils.checkArrayLengthCorrect (i, length);
					time = Int32.Parse (args [i + 1]);
				} else if (args [i] == "-avg") {
					isAvg = true;
				}
			}
		}
	}
}

