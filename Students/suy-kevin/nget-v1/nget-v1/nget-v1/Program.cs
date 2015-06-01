using System;
using System.Net;

namespace ngetv1
{
	class MainClass
	{
		public static void Main (string[] args)
		{

			try{
				if (args != null) {

					if (args.Length > 2) {
						switch (args [0]) {
						//Ici il y a normalement deux arguments : get et "une_url"
						case "get":
							if (args [1] == "-url") {
								string url = args[2];
								Console.WriteLine ("Downloading {0}", url);
								string urlContent = GetUrl(url);
								Console.WriteLine (urlContent);

								// Arrivé ici, il y a soit -save et "une_url_locale", soit rien
								if(args.Length > 3){
									if(args[3] == "-save"){
										string urlDestination = args[4];
										System.IO.File.WriteAllText(urlDestination, urlContent);
									}else{
										throw new WrongArgumentException();
									}
								}

							} else {
								throw new WrongArgumentException ();
							}
							break;
						//Ici il y a normalement deux arguments : test et "une_url"
						case "test":
							if (args [1] == "-url") {
								string url = args[2];
								if(args.Length > 3 && args.Length < 6){
									//Ici il y a test, "une_url", "-times", et "un_nombre"
									if(args[3] == "-times"){
										int nbTests = int.Parse(args[4]);
										for(int i = 0; i < nbTests; i++){
											Console.WriteLine(GetTimeTestUrl(url) + " ms");
										}
									}
									//Ici il y a test, "une_url", "-times", "un_nombre", et "-avg"
								}else if (args.Length > 5){
									Console.WriteLine(GetTimeTestUrlAvg(url, int.Parse(args[4])) + " ms");
								}else{
									Console.WriteLine(GetTimeTestUrl(url) + " ms");
								}
							} else {
								throw new WrongArgumentException ();
							}
							break;
						default:
							throw new WrongArgumentException ();
						}
					} else {
						throw new NoArgumentException ();
					}
				} else {
					throw new NoArgumentException ();
				}
			}catch(Exception e){
				Console.WriteLine(e.ToString());
			}

		}

		/// <summary>
		/// Gets the URL.
		/// </summary>
		/// <returns>The URL.</returns>
		/// <param name="url">URL</param>
		public static string GetUrl(string url){
			WebClient client = new WebClient ();
			return client.DownloadString (url);
		}

		/// <summary>
		/// Gets the time test URL.
		/// </summary>
		/// <returns>The number of milliseconds that is needed to download the content of the website</returns>
		/// <param name="url">URL of a website</param>
		public static int GetTimeTestUrl(string url){
			DateTime start = DateTime.Now;
			GetUrl (url);
			DateTime stop = DateTime.Now;
			TimeSpan result = stop - start;
			int resultInt = int.Parse(result.Milliseconds.ToString ());
			return resultInt;
		}

		/// <summary>
		/// Gets the average time of the URL tests.
		/// </summary>
		/// <returns>An integer that represents the average time</returns>
		/// <param name="url">URL of a website</param>
		/// <param name="times">Number of times of tests</param>
		public static int GetTimeTestUrlAvg(string url, int times){
			int result = 0;
			for (int i = 0; i < times; i++) {
				result += GetTimeTestUrl (url);
			}
			result /= times;
			return result;
		}
	}
}
