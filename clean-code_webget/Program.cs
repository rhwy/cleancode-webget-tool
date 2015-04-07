using System;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace cleancode_webget
{
	class MainClass
	{


		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");

			String strFromUrl = null;

			WebClient client = new WebClient ();

			Stopwatch sw = new Stopwatch(); 

			String path = "/Users/Neimad/Documents/CSharp_workspace/cleancode-webget/cleancode-webget-tool/";

			double[] timesArray = null;



			if (args.Length == 0) 
			{
				throw new Exception ("No args");
			}


			if (args[0] == "get") 
			{
				if (args[1] == "-url") 
				{
					if (!string.IsNullOrEmpty (args [2])) 
					{
						strFromUrl = client.DownloadString (args [2]);
					}

				}

				if (strFromUrl == null) 
				{
					throw new Exception ("no data found");
				}

				if(args[3] == "-save")
				{
					if (!string.IsNullOrEmpty (args [4])) 
					{
						path = path + args [4];
						System.IO.File.WriteAllText (path, strFromUrl);	
					}
					
				}
			
			}




			if (args[0] == "test") 
			{
				Console.WriteLine ("Hello World!1");
				if (args[1] == "-url") 
				{
					Console.WriteLine ("Hello World!2");
					if (!string.IsNullOrEmpty (args [2])) 
					{
						Console.WriteLine ("Hello World!3");
						if (args [3] == "-times") 
						{
							Console.WriteLine ("Hello World!4");
							if (!string.IsNullOrEmpty (args [4])) 
							{
								Console.WriteLine ("Hello World!5");
								int times = int.Parse (args [4]);
								timesArray = new double[times];

								for(int i=0; i<times; i++)
								{
									sw.Start ();
									strFromUrl = client.DownloadString(args [2]);
									sw.Stop();

									timesArray [i] = sw.ElapsedMilliseconds;
								}
							}
						}
					}
				}


				for (int i = 0; i < timesArray.Length; i++) 
				{
					Console.WriteLine ("time " + i + " : " + timesArray[i] + "ms");
				}
			}






			

			

		













		}
	}
}
