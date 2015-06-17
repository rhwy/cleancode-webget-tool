
using System;
using System.Diagnostics;
using System.Net;

namespace nget_v2
{
	/// <summary>
	/// Description of UrlDownloader.
	/// </summary>
	public class UrlDownloader
	{
		public UrlDownloader()
		{
		}
		
		public static string download(string url) {
			long duration = 0;
			return download(url, ref duration);
		}
		
		public static string download(string url, ref long duration) {
			
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
	}
}
