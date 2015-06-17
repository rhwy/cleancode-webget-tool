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
			if (args.Length == 0)
				return;
			
			foreach (var element in args) {
				Console.Write(element + " ");
			}
			Console.WriteLine();
			
			List<ICommand> list = new List<ICommand>();
			list.Add(new Get());
			list.Add(new Test());
			
			foreach (var command in list) {
				
				if (match(command, args)) {
			    	command.execute();
			    	break;
				}
			}
			Console.ReadKey();
		}
		
		public static bool match(ICommand command, string[] args) {
			
			if (args[0].Equals(command.getName()) == false)
			    return false;
			    
			List<Arg> command_args = command.getArgs();

			var values = new Dictionary<string, string>();

			foreach (var arg in command_args) {
				
				string value;
				if (arg.hasValue) {
					 value = extractArg(args, arg.name);
				}
				else {
					value = args.Contains(arg.name) ? "found" : null;
				}
			
				if (arg.isRequired && value == null) {
					Console.WriteLine("argument <" + arg.name + "> is missing");
					return false;
				}
				values.Add(arg.name, value);

			}
			command.setValues(values);
			return true;
		}
				
		public static string extractArg(string[] args, string argName) {

			int index = Array.IndexOf(args, argName);
			
			if (index == -1 || (index + 1 == args.Length))
				return null;
			
			return args[index + 1];
		}
	}
}