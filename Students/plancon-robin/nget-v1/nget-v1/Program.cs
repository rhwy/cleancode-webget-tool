using System;
using System.Net;
using System.IO;

namespace ngetv1
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			if (args[0] == null || args[1] == null  || args[2] == null) {
				throw new Exception ();
			}

			if (args.Length != 3 && args.Length != 5 && args.Length != 6) {
				throw new Exception ();
			}

			String method = args [0];
			String comp = args [1];
			String url = args [2];
			String ngetOption = null;
			String other = null;
			String moy = null;

			if (args.Length == 5) {
				ngetOption = args [3];
				other = args [4];
			}
			if(args.Length == 6) {
				ngetOption = args [3];
				other = args [4];
				moy = args [5];
			}

			if (method == "get" && comp == "-url") {
				if (ngetOption != null) {
					HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create (url);
					myRequest.Method = "GET";
					WebResponse myResponse = myRequest.GetResponse ();
					if (myResponse == null) {
						throw new Exception ();
					}
					StreamReader sr = new StreamReader (myResponse.GetResponseStream (), System.Text.Encoding.UTF8);
					string result = sr.ReadToEnd ();
					sr.Close ();
					myResponse.Close ();



					StreamWriter monStreamWriter = new StreamWriter("./"+other,true); 
					monStreamWriter.WriteLine (result);
					monStreamWriter.Close();
					
				} else {
				
					HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create (url);
					myRequest.Method = "GET";
					WebResponse myResponse = myRequest.GetResponse ();
					if (myResponse == null) {
						throw new Exception ();
					}
					StreamReader sr = new StreamReader (myResponse.GetResponseStream (), System.Text.Encoding.UTF8);
					string result = sr.ReadToEnd ();
					sr.Close ();
					myResponse.Close ();

					Console.WriteLine (result);
				}
			}
			else if (method == "test" && comp == "-url"){

			}

			Console.ReadKey (true);
		}
	}
}
