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
		void WriteTo(string filePath,string s);
	}
	public interface IWebHelper {
		string GetContent(string url);
	}
    public interface IChronoHelper {
        void Start();
        void Stop();
        void Reset();
        double ElapsedMiliSecond { get; }
    }

	class WebHelper: IWebHelper {
		private WebClient client;
		public WebHelper(WebClient client){
			this.client = client;
		}
		 string IWebHelper.GetContent(string url){
			return client.DownloadString (url);
		}
	}

	class FileHelper : IFileHelper {
        void IFileHelper.WriteTo(string filePath, string content)
        {
            File.WriteAllText(filePath, content);
        }
	}
    class ChronoHelper : IChronoHelper {
        Stopwatch watch;

        void IChronoHelper.Start() {
            watch.Start();
        }
        void IChronoHelper.Stop() {
            watch.Stop();
        }
        void IChronoHelper.Reset() {
            watch.Reset();
        }
        double IChronoHelper.ElapsedMiliSecond {
            get {
                return watch.ElapsedMilliseconds;
            }
        }

        public ChronoHelper(Stopwatch watch)
        {
            this.watch = watch;
        }
    }

	public class ApiClient  {
		private IFileHelper file;
		private IWebHelper webHelper;
        private IChronoHelper chrono;

        public ApiClient(IFileHelper file,IWebHelper webHelper,IChronoHelper chrono){
			this.file = file;
			this.webHelper = webHelper;
            this.chrono = chrono;
		}

		public  double GetAvg(int times, string url){
			return GetTimesOfReq(url,times).Aggregate(0.0,(current,x )=>current+=x)/times;		
		}

		public  IEnumerable <double> GetTimesOfReq(string url, int times){
			double[] durees = new double[times];
			for (int i = 0; i < times; i++) {
				chrono.Start ();
				GetResults (url);
                chrono.Stop();
                durees[i] = chrono.ElapsedMiliSecond;
                chrono.Reset();
			}
			return durees;
		}
		public  String GetResults (String url)
		{	
			return webHelper.GetContent(url);
		}

		public void SaveResults(string url, string filePath){
			file.WriteTo (filePath, GetResults(url));
		
		}
	}
	class MainClass
	{
		public static readonly ApiClient apiClient = new ApiClient(
            new FileHelper(),
            new WebHelper(new WebClient()),
            new ChronoHelper(new Stopwatch())
        );
		private const string helpText = "Utilisez get pour verifier le contenu et test pour tester la connection";
        private const int typeIndex = 1;     //test or get
        private const int urlIndex = 3;     //index de l'url de la page a charger
        private const int filePathIndex = 5;     
        private const int timeCountIndex = 5;     

		public static void Main (string[] args)
		{
            if (args.Length == 0) {
                Console.WriteLine(helpText);
                return;
            }
            switch (args[typeIndex]) {
			case "get":
				DoGet (args);
				break;
			case "test":
				DoTest (args);
				break;
			default :
				Console.WriteLine (helpText);
				break;
			}
		}

		public static void DoGet(string [] args){
			if (args.Contains("-save")) {
				WriteToFile(args [urlIndex], args [filePathIndex]);
                return;
			}
			displayContent(args[urlIndex]);
		}
		public static void DoTest (string[] args)
		{
			if (args.Contains("-avg"))  {
				displayAvg (args [urlIndex], int.Parse (args [timeCountIndex]));
                return;
            }
			DisplayTime (args [urlIndex], int.Parse (args [timeCountIndex]));
		}
	
		public static void DisplayTime(String url, int times) {
			IEnumerable<double> durees = apiClient.GetTimesOfReq(url,times);
			foreach (double time in durees)
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