using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;

namespace nget
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine(args.Length);
			
			if (args.Length == 0)
				return;
			
			var url = extractArg(args, "-url");
				
			// The url is mandatory, so stop here if there is none
			if (url == null) {
				Console.WriteLine("The -url <url> argument is missing");
				return;
			}
			
			if (args[0].Equals("get")) {
				
				// save file is optional
				var fileOutput = extractArg(args, "-save");
				
				var result = getUrl(url);
				
				// if -save <path> is valid, we save in file, else print on console
				if (fileOutput != null) {
					saveFile(fileOutput, result);	
				} else {
					Console.WriteLine(result);	
				}
				
			} else if (args[0].Equals("test")) {
				
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
					Console.WriteLine("average: " + computeAvg(samples) + "ms");
				} else {
					printTimes(samples);
				}
			}
		}
		
		public static string extractArg(string[] args, string argName) {
			
			// For each string in the array
			for (int i = 0; i < args.Length; i++) {
				
				// If we find the string we are looking for, return the next string (if it exists)
				if (args[i].Equals(argName)) {
					if (i + 1 < args.Length)
						return args[i + 1];
				}
			}
			
			return null;			
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
		
		public static void saveFile(string fileName, string data) {
			File.WriteAllText(fileName, data);
		}
		
		public static void printTimes(long[] times) {
			for (int i = 0; i < times.Length; i++) {
				Console.WriteLine(times[i]);
			}
		}
		
		public static long computeAvg(long[] times) {

			long avg = 0;
			
			for (int i = 0; i < times.Length; i++) {
				avg += times[i];
			}
			
			return avg / times.Length;
		}
	}
}