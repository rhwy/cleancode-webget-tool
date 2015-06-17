
using System;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace nget_v2
{
	/// <summary>
	/// Description of Get.
	/// </summary>
	public class Get: ICommand
	{
		public Get()
		{
		}
		
		public bool match(string arg) {
			return arg.Equals("get");
		}
		
		public void execute(string[] args, string url) {
			// save file is optional
			var fileOutput = extractArg(args, "-save");
			
			var result = getUrl(url);			

			// if -save <path> is valid, we save in file, else print on console
			if (fileOutput != null) {
				saveFile(fileOutput, result);	
			} else {
				Console.WriteLine(result);	
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
		
		private static void saveFile(string fileName, string data) {
			File.WriteAllText(fileName, data);
		}
		
		public static string extractArg(string[] args, string argName) {

			int index = Array.IndexOf(args, argName);
			
			if (index == -1 || (index + 1 == args.Length))
				return null;
			
			return args[index + 1];
		}
	}
}
