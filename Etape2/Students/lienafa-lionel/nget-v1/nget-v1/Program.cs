/*
 * Created by SharpDevelop.
 * User: Lionel
 * Date: 07/04/2015
 * Time: 12:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Net;

namespace nget_v1
{
	class FakeTime
	{
		public static DateTime Now()
		{
			return new DateTime(2011, 6, 10);
		}
	}
	
	class Principal
	{
		private WebClient client;
		private string[] args;
		private string url;
		
		public Principal(string[] arg)
		{
			args = arg;
			url = args[2];
			client = new WebClient();
			
			switch(args[0]) {
				case "get":

					break;
				case "test":
					test();
					break;
				case "":
				default:
					Console.WriteLine("Argument non valide");
					break;
			}
			Console.ReadKey(true);
		}
		
		public void test()
		{
			int nbTimes = Convert.ToInt16(args[4]);
			double[] timesArray = new double[nbTimes];
			double cumul = 0;
			for(int i = 0; i < nbTimes; i++)
			{
				DateTime TimeStart = FakeTime.Now();
				client.DownloadString(url);
				TimeSpan TimeDif = FakeTime.Now().Subtract(TimeStart);
				timesArray[i] = TimeDif.TotalSeconds;
				
				try {
						if(args[5] == "-avg") {
							cumul += TimeDif.TotalSeconds;
						}
				} catch (IndexOutOfRangeException e) {
					Console.WriteLine(TimeDif.TotalSeconds);
					
					}
			}
			
			try {
				if(args[5] == "-avg") {
					Console.WriteLine(cumul / nbTimes);
				}
			} catch (IndexOutOfRangeException e) {
				
			}
		}
		
		public void get()
		{
			if(args[1] == "-url") {
				
				if(args[3] == "-save") {
					client.DownloadFile(url, args[4]);
				} else {
					Console.WriteLine(client.DownloadString(url));
				}
			}
		}
	}
	
	class Program
	{
		public static void Main(string[] args)
		{
			new Principal(args);
		}
		
	
	}
}