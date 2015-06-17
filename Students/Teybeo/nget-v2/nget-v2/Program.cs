using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using nget_v2;

namespace nget
{
	class Program
	{
		public static void Main(string[] args)
		{
			List<ICommand> list = new List<ICommand>();
			list.Add(new Get());
			list.Add(new Test());

			Console.WriteLine(args.Length);
			
			if (args.Length == 0)
				return;
			
			var url = extractArg(args, "-url");
				
			// The url is mandatory, so stop here if there is none
			if (url == null) {
				Console.WriteLine("The -url <url> argument is missing");
				return;
			}
			
			foreach (var command in list) {
				if (command.match(args[0])) {
			    	command.execute(args, url);
				}
			}
			
		}
		
		public static string extractArg(string[] args, string argName) {

			int index = Array.IndexOf(args, argName);
			
			if (index == -1 || (index + 1 == args.Length))
				return null;
			
			return args[index + 1];
		}
		
		
		

		

	}
}