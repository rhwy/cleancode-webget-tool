
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace nget_v2
{
	/// <summary>
	/// Description of Get.
	/// </summary>
	public class Get: ICommand
	{
		string fileOutput;
		string url;
		
		public Get()
		{
		}
		public string getName() 
		{
			return "get";
		}
		
		public List<Arg> getArgs() {
			var list = new List<Arg>();
			list.Add(new Arg("-save", false, true));
			list.Add(new Arg("-url", true, true));
			return list;
		}
		
		public void setValues(Dictionary<string, string> values) {
			
			// save file is optional
			fileOutput = values["-save"];
			url = values["-url"];
		}
		
		public void execute() {

			var result = UrlDownloader.download(url);			

			// if -save <path> is valid, we save in file, else print on console
			if (fileOutput != null) {
				saveFile(fileOutput, result);	
			} else {
				Console.WriteLine(result);	
			}
		}
			
		private static void saveFile(string fileName, string data) {
			File.WriteAllText(fileName, data);
		}
		
	}
}
