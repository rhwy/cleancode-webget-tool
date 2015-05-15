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
		private readonly string[] args;
		private readonly string url;
		
		public Principal(string[] arg)
		{
			args = arg;
			url = args[2];
			client = new WebClient();
			string message = "";
			
			if(args[0] == "get") message = get();
			else if(args[0] == "test") message = test();
			else message = "Argument non valide";	
			Console.WriteLine(message);
			Console.ReadKey(true);
		}
		
		private string test()
		{
			int nbTimes = Convert.ToInt16(args[4]);
			double[] timesArray = new double[nbTimes];
			double cumul = 0;
			for(int i = 0; i < nbTimes; i++)
			{
				client.DownloadString(url);
				TimeSpan TimeDif = FakeTime.Now().Subtract(FakeTime.Now());
				timesArray[i] = TimeDif.TotalSeconds;		
			}
			return testAVG(cumul,nbTimes);					
		}
		
		private string testAVG(double cumul,int nbTimes)
		{
			string contenu = "";
			try {
				if(args[5] == "-avg")
					contenu = Convert.ToString(cumul / nbTimes);
			} catch (IndexOutOfRangeException e) {
				contenu = e.Message;			}
			return contenu;
		}
		
		private string get()
		{
			string mess = "";
			if(args[1] == "-url") {
				
				if(args[3] == "-save") {
					client.DownloadFile(url, args[4]);
				} else {
					mess = client.DownloadString(url);
				}
			}			
			return mess;
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