
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;

namespace nget_v2
{
	/// <summary>
	/// Description of Test.
	/// </summary>
	public class Test: ICommand
	{		

		int samplesCount;
		string url;
		bool average;
				
		public Test()
		{
		}
		
		public string getName()
		{
			return "test";
		}
		
		public List<Arg> getArgs()
		{
			var list = new List<Arg>();
			list.Add(new Arg("-times", true, true));
			list.Add(new Arg("-avg", false, false));
			list.Add(new Arg("-url", true, true));
			return list;
		}
		
		public void setValues(Dictionary<string, string> values)
		{
			samplesCount = int.Parse(values["-times"]);
			url = values["-url"];
			average = values["-avg"] != null ? true : false;
		}

		public void execute() {
			
			var samples = new long[samplesCount];
			
			for (int i = 0; i < samplesCount; i++) {
				UrlDownloader.download(url, ref samples[i]);
			}
			
			if (average) {
				Console.WriteLine("average: " + samples.Average() + "ms");
			} else {
				printTimes(samples);
			}
		}
		
		private static void printTimes(long[] times) {
			for (int i = 0; i < times.Length; i++) {
				Console.WriteLine(times[i]);
			}
		}
	}
}
