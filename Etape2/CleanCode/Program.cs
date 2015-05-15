using System;
using System.Net;
using System.Linq;
using System.IO;
using System.Timers;
using System.Diagnostics;
using System.Collections.Generic;
namespace CleanCode
{   
	public interface IFileHelper {
		void writeTo(string filePath,string s);


	}
	public interface IWebHelper {
		 string getResults(string url);
	}
	class WebHelper: IWebHelper {
		WebClient _client;
		public WebHelper(WebClient _client){
			this._client = _client;
		}
		 string IWebHelper.getResults(string url){
			return _client.DownloadString (url);
		}
	}
	class FileHelper : IFileHelper {
		 void IFileHelper.writeTo(string filePath, string s ){
			File.WriteAllText(filePath, s);
		}		


	} 

	public class ApiClient  {
		IFileHelper file;
		IWebHelper webHelper;
		public ApiClient(IFileHelper file,IWebHelper webHelper){
			this.file = file;
			this.webHelper = webHelper;
		}

		public  double GetAvg(int times, string url){
			return GetTimesOfReq(url,times).Aggregate(0.0,(current,x )=>current+=x)/times;		
		}

		public  IEnumerable <double> GetTimesOfReq( string url,int times){
			var watch = new Stopwatch ();
			double[] duree = new double[times];
			for (int i = 0; i < times; i++) {
				watch.Start ();
				GetResults (url);
				watch.Stop ();
				duree [i] = watch.ElapsedMilliseconds;
			}
			return duree;

		}
		public  String GetResults (String url)
		{	
			
			//if (!urlCible.Equals ("")) {
			//	File.WriteAllText(urlCible,urlData);

			//} 
			return webHelper.getResults(url);
		}
		public void SaveResults(string url, string filePath){
			file.writeTo (filePath, url);
		
		}
	}
	class MainClass
	{   public static ApiClient apiClient;
		public static void Main (string[] args)
		{
			apiClient = new ApiClient (new FileHelper(),new WebHelper(new WebClient()));
			int lengthArgs = args.Length;
			Console.WriteLine (lengthArgs);

			if (args[1].Equals ("get")) {
				if (lengthArgs > 4) {
					if (args[4].Equals("-save"))
						WriteToFile(args [3], args [5]);
				}
				else displayContent(args[3]);
				
			}
			if ((args[1].Equals ("test"))) {
				if (lengthArgs > 6) {
					if (args[6].Equals("-avg"))
						displayAvg(args[3], int.Parse(args [5]));
					}
				else Test(args[3],int.Parse(args[5]));
			}
			
		}
		public static void GetWrite (String url)
		{
			Console.WriteLine (url);
		}


		public static void Test(String url, int times)
		{
			IEnumerable<double> duree = apiClient.GetTimesOfReq(url,times);
			foreach (double time in duree)
				Console.WriteLine (time);
		}
			
		public static void WriteToFile(string url , string filePath){
			apiClient.SaveResults (filePath, url);
		
		}
		public static void  displayAvg (string url, int times ){
			Console.WriteLine (apiClient.GetAvg(times,url));
		}
		public static void displayContent (string url){
			Console.WriteLine (apiClient.GetResults(url));
		}
	}
}