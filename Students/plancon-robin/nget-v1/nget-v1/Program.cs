using System;
using System.Net;
using System.IO;

namespace ngetv1
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			String Method = args [0];
			String Url = args [1];

			Console.WriteLine (Method);
			Console.WriteLine (Url);

			if (Method == "get") {
				HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create (Url);
				myRequest.Method = "GET";
				WebResponse myResponse = myRequest.GetResponse ();
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
