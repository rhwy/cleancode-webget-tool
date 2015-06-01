using System;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace Nget_V1
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			
			if (args.Length == 3) {
				var url = args [2];
				var method = getProperMethod (args [0]);
				Console.WriteLine (getContent(url,method));
			}

			if (args.Length == 5) {
				if (args [3].Equals ("-save") && args [4] != null) {
					string fileName = args [4];
					string url = args [2];
					var method = getProperMethod (args [0]);
					saveToFile (url,method,fileName);
				}
				if (args [0].Equals ("test") && args [3].Equals ("-times") && args [4] != null){
					string myURL = args [2];
					string times = args [4];
					int repeatTimes = 0;
					bool answer = int.TryParse (times, out repeatTimes);
					if (answer) {
						printURLExecutionTime (myURL,repeatTimes);
					} else {
						Console.WriteLine ("This is not a number {0}", times);
					}
				}

			}
			if (args.Length == 6) {
				if (args [0].Equals ("test") && args [3].Equals ("-times") && args [4] != null && args[5].Equals("avg")) {
					string myURL = args [2];
					string times = args [4];
					int repeatTimes = 0;
					bool answer = int.TryParse (times, out repeatTimes);
					if (answer) {
						calculateAverage (myURL, repeatTimes);
					} else {
						Console.WriteLine ("This is not a number {0}", times);
					}
				}
			}
		}

		public static string getContent (string url, string method)
		{
			WebRequest request = WebRequest.Create(url);
			if (method == null) {
				request.Method = "GET";
			} else {
				request.Method = method;
			}
			string content = "empty";
			try {
				content = new StreamReader (request.GetResponse ().GetResponseStream ()).ReadToEnd ();
			} catch{
				Console.WriteLine ("The URL is not valide");
			}
			return content;
		}

		public static void saveToFile(string url,string method,string fileName){
			var content = getContent(url,method);
			string projectPath = Directory.GetParent (Directory.GetCurrentDirectory ()).Parent.FullName;
			string filePath = projectPath + "/" + fileName;
			using (StreamWriter file = new StreamWriter (filePath)) {
				file.WriteLine (content);
			}
			Console.WriteLine (filePath);
		}

		public static void calculateAverage (string url,int repeatTimes){
			int moyenne = 0;
			for (int i = 0; i < repeatTimes; i++) {
				Stopwatch chrono = new Stopwatch();
				chrono.Start ();
				getContent (url, null);
				chrono.Stop ();
				moyenne +=chrono.Elapsed.Milliseconds;
			}
			moyenne = moyenne / repeatTimes;
			Console.WriteLine ("average time of request execution {0}ms",moyenne);
		}

		public static void printURLExecutionTime(string url,int repeatTimes){
			for (int i = 0; i < repeatTimes; i++) {
				Stopwatch chrono = new Stopwatch();
				chrono.Start ();
				getContent (url, null);
				chrono.Stop ();
				Console.WriteLine ("{0}ms",chrono.Elapsed.Milliseconds);
			}
		}

		public static string getProperMethod (string method)
		{
			if (method != null) {
				method = method.Replace ("-", "");
				method = method.ToUpper ();
			}
			return method;
		}
	}
}
