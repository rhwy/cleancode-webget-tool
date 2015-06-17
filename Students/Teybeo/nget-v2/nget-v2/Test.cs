
using System;
using System.Diagnostics;
using System.Linq;
using System.Net;

namespace nget_v2
{
	/// <summary>
	/// Description of Test.
	/// </summary>
	public class Test: ICommand
	{
		public Test()
		{
		}
		
		public bool match(string arg) {
			return arg.Equals("test");
		}
		
		public void execute(string[] args, string url) {
			// samples count is mandatory
			string samplesCountString = extractArg(args, "-times");
			if (samplesCountString == null) {
				Console.WriteLine("The -times <count> argument is missing");
				return;
			}
			
			int samplesCount = int.Parse(samplesCountString);
			var samples = new long[samplesCount];
			
			for (int i = 0; i < samplesCount; i++) {
				getUrl(url, ref samples[i]);
			}
			
			if (args.Contains("-avg")) {
				Console.WriteLine("average: " + samples.Average() + "ms");
			} else {
				printTimes(samples);
			}
		}
		
		public static string getUrl(string url) {
			long duration = 0;
			return getUrl(url, ref duration);
		}
			
		public static string getUrl(string url, ref long duration) {
			
			string response = null;
			var webclient = new WebClient();
			
			var chrono = new Stopwatch();
			chrono.Start();
			using (webclient) {
				response = webclient.DownloadString(url);
			}
			chrono.Stop();
			duration = chrono.ElapsedMilliseconds;
			return response;
		}
		private static void printTimes(long[] times) {
			for (int i = 0; i < times.Length; i++) {
				Console.WriteLine(times[i]);
			}
		}
		public static string extractArg(string[] args, string argName) {

			int index = Array.IndexOf(args, argName);
			
			if (index == -1 || (index + 1 == args.Length))
				return null;
			
			return args[index + 1];
		}
	}
}
