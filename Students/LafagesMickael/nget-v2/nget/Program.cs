using System;
using System.Net;
using System.IO;
using System.Collections.Generic;

namespace nget
{
	class MainClass
	{
		public static Dictionary<string,Type> commandDictionary = new Dictionary<string,Type> {
			{"get",typeof(GetCommand)},
			{"test",typeof(TestCommand)}
		};

		public static void Main (string[] args)
		{
			Type commandType;
			if(commandDictionary.TryGetValue(args[0], out commandType)) {
				var command = Activator.CreateInstance(commandType) as ICommand;
				if(command.parse(args))
					command.execute();
				else
					Console.WriteLine ("Invalid command line");
			}
			else {
				Console.WriteLine("Invalid command line");
			}
		}
	}
}
