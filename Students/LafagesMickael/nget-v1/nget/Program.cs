using System;
using System.Net;
using System.IO;

namespace nget
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var cl = new CommandLine (args); // Parsing de la ligne de commande
			if(cl.isIncorrect()) {
				Console.WriteLine ("Invalid command line");
				return;
			}

			if(cl.Command == "get") {
				try {
					var request = WebRequest.Create (cl.Url);
					var response = request.GetResponse ();
					var content = new StreamReader (response.GetResponseStream ()).ReadToEnd (); 
					if(cl.WriteInOutput) {
						File.WriteAllText (cl.Output, content);
					}
					else {
						Console.WriteLine (content);
					}
				}
				catch (Exception e) {
					Console.WriteLine ("An error occured: {0}", e.Message);
				}
			}
			else {
				try {
					var avg = TimeSpan.FromMilliseconds (0);
					for(int i = 0; i < cl.Times; ++i) {
						var begin = DateTime.Now;
						var request = WebRequest.Create (cl.Url);

						using(var resp = request.GetResponse ()) {
							var duration = DateTime.Now - begin;
							avg += duration;
							Console.WriteLine ("Duration {0}", duration);
						}

					}
					if(cl.MakeAvg) {
						Console.WriteLine ("Average {0}", TimeSpan.FromMilliseconds(avg.TotalMilliseconds / cl.Times));
					}
				}
				catch (Exception e) {
					Console.WriteLine ("An error occured: {0}", e.Message);
				}
			}

		}
	}
}
