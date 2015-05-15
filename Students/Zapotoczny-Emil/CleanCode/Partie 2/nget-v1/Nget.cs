/*
 * Created by SharpDevelop.
 * User: Emil
 * Date: 07/04/2015
 * Time: 14:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Net;
using System.Diagnostics;

namespace nget_v1
{
	/// <summary>
	/// Description of Nget.
	/// </summary>
	public class Nget
	{
		public Nget()
		{
			
		}
		
		public void nget(string[] args)
		{
			if(args.Length < 3)
				throw new ArgumentException("Should get arguments");
			
			var uri = new Uri(args[2]);
			
			if(args.Length == 3)
			{
				try 
				{
					Console.WriteLine(new WebClient().DownloadString(uri));
					Exit();
				}
				catch {throw new Exception("Reader fail");}
			}
			else if(args.Length == 5 && args[0] == "get")
			{
				var text = new WebClient().DownloadString(uri);
				File.WriteAllText(args[4],text);
				Exit();
			}
			
			if(args.Length == 5 && args[0] == "test")
			{
				var tab = ExecuteDownloadString(uri,Convert.ToInt32(args[4]),false);
				Exit();
			}
			else if(args.Length == 6)
			{
				var totalTime = ExecuteDownloadString(uri, Convert.ToInt32(args[4]),true);
				Console.WriteLine("Temps moyen d'éxecution : " + totalTime + " ms");
				Exit();
			}
		}

		public double ExecuteDownloadString(Uri uri, int nb, bool isAverage)
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
				
		public void Exit()
		{
			Console.Write("Appuyez sur n'importe quelle touche ...");
			Console.ReadLine();
		}
	}
}
