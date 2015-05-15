/*
 * Created by SharpDevelop.
 * User: Emil
 * Date: 07/04/2015
 * Time: 14:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Net;
using System.Diagnostics;
using nget_v1;

namespace nget_v1
{
	/// <summary>
	/// Description of Nget.
	/// </summary>
	public class Nget
	{
		public void nget(string[] args)
		{
			if(!IsValidArguments(args)) return;
			var uri = new Uri(args[2]);
			
			DoWork(args, uri);
		}
		
		public void DoWork(string[] args, Uri uri)
		{
			if(args.Length == 3) 
			{
				Console.WriteLine(ReadMethod(uri));
				Exit();
			}

			else if(args.Length == 5 && args[0] == "get")
				GetMethod(uri, args[4]);
			
			if(args.Length == 5 && args[0] == "test")
				TestMethod(uri, args[4]);
			
			else if(args.Length == 6)
			{
				Console.WriteLine("Temps moyen d'éxecution : " + TestAverageTimeMethod(uri, args[4]) + " ms");
				Exit();
			}
		}
		
		public string ReadMethod(Uri uri)
		{
			try 
			{
				var webClient = new WebClient();
				return webClient.DownloadString(uri);
			}
			catch 
			{
				return("Reader fail");
			}
		}
		
		public void TestMethod(Uri uri, string args)
		{
			var tab = ExecuteDownloadString(uri,Convert.ToInt32(args),false);
			Exit();
		}
		
		public void GetMethod(Uri uri, string args)
		{
			var webClient = new WebClient();
			var fileHelper = new FileHelperImplementation();
			
			var text = webClient.DownloadString(uri);
			fileHelper.WriteAllText(args,text);
			Exit();
		}
		
		public double TestAverageTimeMethod(Uri uri, string args)
		{
			var totalTime = ExecuteDownloadString(uri, Convert.ToInt32(args),true);
			return totalTime;
		}
		
		public bool IsValidArguments(string[] args)
		{
			if(args.Length < 3)
				throw new ArgumentException("Should get arguments");
			
			return true;
		}

		public double ExecuteDownloadString(Uri uri, int nb, bool isAverage)
		{
			try
			{
				var totalTime = 0.0;
				var stop = new Stopwatch();
				for(var i=0; i<nb; i++)
				{
					stop.Reset();
					stop.Start();
					new WebClient().DownloadString(uri);
					stop.Stop();
					if(!isAverage)
						Console.WriteLine("Temps n° " + (i+1) + " : " + stop.ElapsedMilliseconds + "ms");
					totalTime += stop.ElapsedMilliseconds;
				}
				return totalTime;
			}
			catch
			{
				throw new Exception("ExecuteDownloadString is end with errors");
			}
		}
				
		public void Exit()
		{
			Console.Write("Appuyez sur n'importe quelle touche ...");
			Console.ReadLine();
		}
	}
}
