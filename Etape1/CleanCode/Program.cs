using System;
using System.Net;
using System.IO;
using System.Timers;
using System.Diagnostics;
namespace CleanCode
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			int lengthArgs = args.Length;
			Console.WriteLine (lengthArgs);

			if (args[1].Equals ("get")) {
				if (lengthArgs > 4) {
					if (args [4].Equals ("-save"))
						GetWrite(Get (args [3], args [5]));
				}
				else GetWrite(Get(args[3]));
				
			}
			if ((args[1].Equals ("test"))) {
				if (lengthArgs > 6) {
					if (args[6].Equals("-avg"))
						Test (args [3], args [5], "-avg");
					}
				else Test(args[3],args[5]);
			}
			
		}
		public static void GetWrite (String url)
		{
			Console.WriteLine (url);
		}

		public static String Get (String url, String urlCible ="")
		{	
				WebClient _client = new WebClient ();
				String urlData = _client.DownloadString (url);
			     	

		
			if (!urlCible.Equals ("")) {
				File.WriteAllText(urlCible,urlData);
							
			} 
			return urlData;
		}

		public static void Test(String url, String time, String avg="")
		{
			int times = int.Parse (time);
			double moyDuree = 0;
			var watch = new Stopwatch ();

			double[] duree = new double[times];

			if (!avg.Equals ("")) {

				for (int i = 0; i < times; i++) {
					watch.Start ();
					Get (url);
					watch.Stop ();
					moyDuree += watch.ElapsedMilliseconds;
				}

				double Moy = moyDuree / times;
				Console.WriteLine (Moy);


			} else{
				for (int i = 0; i < times; i++) {
					watch.Start ();
					Get (url);
					watch.Stop ();
					duree [i] = watch.ElapsedMilliseconds;
				}

			for (int i = 0; i < times; i++) {
				Console.WriteLine (duree [i]);
			}
		}
				

	}

	}
}