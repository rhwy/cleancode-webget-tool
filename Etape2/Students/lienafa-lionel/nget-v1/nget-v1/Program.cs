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
	
	class MyException
	{
		public MyException(string exception)
		{
			Console.WriteLine(exception);
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
			int res = 0;
			if(args[0] == "get")  res = get();
			else if(args[0] == "test") res = test();
			else new MyException("Argument non valide");
			if(res < 0) Console.WriteLine("Exception générée");
			Console.ReadKey(true);
		}
		
		private int test()
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
		
		private int testAVG(double cumul,int nbTimes)
		{
			try {
				if(args[5] == "-avg")
					Console.WriteLine(Convert.ToString(cumul / nbTimes));
			} catch (IndexOutOfRangeException e) {
				new MyException(e.Message);		
				return -1;		
			}
			return 0;
		}
		
		private int get()
		{
			if(args[1] == "-url") {
				
				if(args[3] == "-save") {
					client.DownloadFile(url, args[4]);
				} else {
					new MyException(client.DownloadString(url));
					return -1;
				}
			}			
			return 0;
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