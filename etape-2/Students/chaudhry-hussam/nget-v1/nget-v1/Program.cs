using System;
using System.Net;
using System.Diagnostics;
using System.IO;

namespace ngetv1
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			WebGet webGet = new WebGet();
			string result = string.Empty;

			result = webGet.checkForArguments(args);
			Console.WriteLine (result);
			Console.ReadLine ();
		}
	}

	class WebGet
	{
		public string checkForArguments(string[] args)
		{
			string result = string.Empty;
			string action = string.Empty;

			if (args == null || args.Length == 0) {
				result = "Pas d'arguments";
			} else {
				result = checkAction (args);
			}

			return result;
		}

		public string checkAction(string[] arguments)
		{
			string result = String.Empty;
			if (!checkURLArgument (arguments [1]) && arguments [2] != null) {
				switch (arguments [0]) {

				case "get":
					result = actionGet (arguments);
					break;
			
				case "test":
					result = actionTest (arguments);
					break;
				}
			}
			return result;
		}

		public string actionGet(string[] args)
		{
			string result = string.Empty;
			IWebDownloader downloader = new WebDownloader();
			string webpage = downloader.download (args [2]);

			if (args.Length >= 4 && args [3] == "-save") {
				saveInFile (webpage, args[4]);
			} else
				result = webpage;
			
			return result;
		}

		public string actionTest(string[] args)
		{
			string result = string.Empty;

			if (args [3] == "-times" && args[4] != null) {
				result = getURLMultipleTime (args [2], args [4]);
			}
			return result;
		}

		public bool checkURLArgument(string urlAgument)
		{
			if (urlAgument == null || urlAgument != "-url")
				return true;
			
			return false;
		}

		public void saveInFile(string toWrite, string path)
		{	
			IFileWriter writer = new FileWriter ();
			writer.writeInfile (path, toWrite);
		}

		public string getURLMultipleTime(string url, string multiple)
		{
			Stopwatch timer = new Stopwatch ();
			IWebDownloader downloader = new WebDownloader();
			string result = string.Empty;
			int nb = 0;
			TimeSpan compteur = new TimeSpan();

			while (nb < Int32.Parse(multiple)) {
				timer.Start ();
				downloader.download (url);
				timer.Stop ();

				TimeSpan ts = timer.Elapsed;

				result += ts + Environment.NewLine;
				compteur += ts;
				timer.Reset ();
				nb++;
			}

			return result;
		}

		public interface IFileWriter {
			void writeInfile(string path,string content);
		}

		public interface IWebDownloader {
			string download(string url);
		}

		class WebDownloader : IWebDownloader {
			WebClient client;

			string IWebDownloader.download(string url){
				client = new WebClient ();
				return client.DownloadString (url);
			}
		}

		class FileWriter : IFileWriter {
			void IFileWriter.writeInfile(string path, string content){
				File.WriteAllText(path, content);
			}		
		} 
	}
}
