/*
 * Created by SharpDevelop.
 * User: Moste
 * Date: 07/04/2015
 * Time: 12:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System.Net;
using System.IO;
using System;

namespace nget_v1
{
	class Program
	{
		public static void Main(string[] args)
		{
			
			string method = args[0];
			string url = args[2];
			int nbArgument = args.Length;
			
			if (nbArgument == 0)
			{
				Console.WriteLine("Aucun Argument");
			}
			/*else
			{
				Console.WriteLine(nbArgument);
			}*/
			switch (method)
			{
				case "get":
					
					if (nbArgument == 3)
					{
						readWebPage(url);
					}
					else if (nbArgument == 5)
					{
						//TODO affectation du resultat de readWebPage(url) à content
						//string content = readWebPage(url)
						saveToFile(args[5],content);
					}

			
				break;
				case "test":
					if (nbArgument == 5)
					{
						Console.WriteLine(args[4]+" nbTime "+args[5]);
					}
					else if (nbArgument == 6)
					{
						Console.WriteLine(args[4]+" nbTime "+args[5]+" : "+args[6]);
					}
			
				break;
				default :
					Console.WriteLine("Problème revoir Requête + " + method);
				break;
			}
			
		}
		
		public static void readWebPage(string url)
		{
			WebClient client = new WebClient();			
			string str = client.DownloadString(url);
			Console.WriteLine(str);
		}
		
		public static string saveToFile(string path, string content)
		{
			System.IO.StreamWriter file = new System.IO.StreamWriter(path);
			file.WriteLine(content);
			file.Close();
		}
	}
}