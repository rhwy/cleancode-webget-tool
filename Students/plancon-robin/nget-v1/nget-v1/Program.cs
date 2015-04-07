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
				
			String method = args [0];
			String comp = args [1];
			String url = args [2];

			if (method == "get" && comp == "-url") {
				
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

			Console.ReadKey (true);
		}
	}
}
