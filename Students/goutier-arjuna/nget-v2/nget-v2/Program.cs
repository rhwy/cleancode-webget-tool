using System;
using System.Timers;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace ngetv2
{
	class MainClass
	{
		private readonly static int CommandIndex = 1;

		public static void Main (string[] args) {
			switch (args [CommandIndex]) {
			case "get":
				Get (args);
				break;
			case "test":
				Test (args);
				break;
			}
		}

		private static void Get(string[] args) {
			string url = GetArgument(args,"url");

			if (ContainsArguement(args,"save")) {
				SaveResult (url, GetArgument(args,"save"));
				return;
			}
			DisplayResult (url);
		}

		private static void Test(string[] args) {
			int times = int.Parse(GetArgument(args,"times"));
			string url = GetArgument(args,"url");

			if (ContainsArguement (args, "avg"))
				DisplayAverage (url, times);
           	else
			   DisplayTime(url,times);
		}


		private static string GetArgument(string[] args, string argName) {
			return args [Array.IndexOf (args, "-" + argName) + 1];
		}

		private static bool ContainsArguement(string[] args, string argName) {
			return Array.IndexOf(args,"-" + argName) != -1;
		}

		private static void SaveResult(string RequestedPath, string ToPath) {
			File.WriteAllText (ToPath, GetContent (RequestedPath));
		}

		private static void DisplayResult(string Url) {
			Console.WriteLine (GetContent(Url));
		}

		private static String GetContent(string RequestedUrl) {
			using (var client = new WebClient()) {
				return client.DownloadString(RequestedUrl);
			}
		}

		private static void DisplayAverage(string RequestedUrl, int Times) {
			long sum = 0;
			for (int i = 0; i<Times; ++i) {
				sum  += GetRequestTime (RequestedUrl);
			}
			Console.WriteLine (sum / Times);
		}

		private static void DisplayTime(string RequestedUrl, int Times) {
			for (int i = 0; i<Times; ++i)
				Console.WriteLine(GetRequestTime (RequestedUrl));
		}


		private static long GetRequestTime(string RequestedUrl) {
			var watch = new Stopwatch ();
			watch.Start ();
			GetContent (RequestedUrl);
			return watch.ElapsedMilliseconds;
		}
	}
}
