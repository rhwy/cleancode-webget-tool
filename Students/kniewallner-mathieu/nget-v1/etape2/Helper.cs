using System;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace ngetv1
{
	public class Helper
	{
		private string[] args;
		private IDownloader Downloader;
		private IWriter Writer;

		public Helper (string[] args)
		{
			this.args = args;
		}

		public string displayFromURL() {
			return Downloader.DownloadString(args[2]);
		}

		public string saveContentFromURL() {
			return Writer.Write (args[2], displayFromURL);
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

	public interface IDownloader {
		string DownloadString(string path);
	}

	public class Downloader: IDownloader {
		public string DownloadString (string path)
		{
			return (new WebClient ()).DownloadString (path);
		}
	}

	public interface IWriter {
		string Write(string path, string content);
	}

	public class Writer: IWriter {
		public string Write (string path, string content)
		{
			TextWriter tw = new StreamWriter(path);
			tw.Write(content);
			return "Contenu sauvé";
		}
	}
}

