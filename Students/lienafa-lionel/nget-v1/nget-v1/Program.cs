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
	class Program
	{
		public static void Main(string[] args)
		{
			WebClient client = new WebClient();
			string url = args[2];
			
			switch(args[0]) {
				case "get":
					if(args[1] == "-url") {
						
						if(args[3] == "-save") {
							client.DownloadFile(url, args[4]);
						} else {
							Console.WriteLine(client.DownloadString(url));
						}
					}
					break;
				case "test":
					int nbTimes = Convert.ToInt16(args[4]);
					double[] timesArray = new double[nbTimes];
					double cumul = 0;
					for(int i = 0; i < nbTimes; i++)
					{
						DateTime TimeStart = DateTime.Now;
						client.DownloadString(url);
						TimeSpan TimeDif = DateTime.Now.Subtract(TimeStart);
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
					break;
				default:
					break;
			}
			Console.ReadKey(true);
		}
	}
}