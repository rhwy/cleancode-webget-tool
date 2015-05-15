using System;
using System.Net;
using System.IO;

namespace ngetv1
{
	public class TestTask
	{

		private string sourceUrl { get; set; }
		private int time { get; set; }
		private bool isAvg { get; set; }

		public TestTask(string[] args)
		{
			InitializeAttributes(args);
			Console.WriteLine(DoTest(args));
		}

		private void InitializeAttributes(string[] args)
		{
			// Récupèration des arguments
			for (int i = 0; i <= args.Length - 1; i++)
			{
				if (args[i] == null || String.IsNullOrEmpty(args[i]))
				{
					throw new Exception(UsageUtils.GetUsage());
				}

				if (args[i] == "-url")
				{
					ArrayUtils.checkArrayLengthCorrect(i, args.Length);
					sourceUrl = args[i + 1];
				}
				else if (args[i] == "-times")
				{
					ArrayUtils.checkArrayLengthCorrect(i, args.Length);
					time = Int32.Parse(args[i + 1]);
				}
				else if (args[i] == "-avg")
				{
					isAvg = true;
				}
			}
		}

		private string DoTest(string[] args)
		{
			string chaine = "";

			TimeSpan totalDuration = new TimeSpan();

			for (int i = 0; i <= time; i++)
			{
				DateTime before = DateTime.Now;
				(new WebClient()).DownloadString(sourceUrl);
				DateTime after = DateTime.Now;

				if (!isAvg)
				{
					chaine += "Duration (ms) : " + after.Subtract(before).TotalMilliseconds + Environment.NewLine;
				}
				else
				{
					totalDuration += (after - before);
				}
			}

			if (isAvg)
			{
				chaine += "Total duration average (ms) : " + totalDuration.TotalMilliseconds / time;
			}

			return chaine;
		}

	}
}

