using System;
using System.Collections.Generic;

namespace nget
{
	public class CommandLine
	{
		public String Command { get; private set; }
		public String Url { get; private set; }
		public String Output { get; private set; }
		public bool WriteInOutput { get; private set; }
		public int Times { get; private set; }
		public bool MakeAvg { get; private set; }

		private readonly bool correct;

		bool parseTest (string[] args)
		{
			for(int i = 1; i < args.Length; ++i) {
				switch(args[i]) {
				case "-url":
					if (i < args.Length - 1 && args [++i] [0] != '-') {
						Url = args [i];
						if (Url [0] == '\"')
							Url = Url.Substring (1, Url.Length - 2);
					}
					else
						return false;
					break;
				case "-times":
					if (i < args.Length - 1 && args [++i] [0] != '-') {
						try {
							Times = Convert.ToInt32 (args [i]);
						} catch {
							return false;
						}
					}
					else
						return false;
					break;
				case "-avg":
					MakeAvg = true;
					break;

				default:
					return false;
				}
			}
			return true;
		}

		bool parseGet (string[] args)
		{
			for (int i = 1; i < args.Length; ++i) {
				switch (args [i]) {
				case "-url":
					if (i < args.Length - 1 && args [++i] [0] != '-') {
						Url = args [i];
						if (Url[0] == '\"')
							Url = Url.Substring (1, Url.Length - 2);
					}
					else
						return false;
					break;
				case "-save":
					if (i < args.Length - 1 && args [++i] [0] != '-') {
						Output = args [i];
						WriteInOutput = true;
					} else
						return false;
					break;
				default:
					return false;
				}
			}
			return true;
		}

		bool parse (string[] args)
		{
			if (args.Length < 3)
				return false;

			Command = args[0];
			switch(Command) {
			case "test":
				if (!parseTest (args))
					return false;
				break;
			case "get":
				if (!parseGet (args))
					return false;
				break;
			default:
				return false;
			}

			return Url.Length != 0;

		}

		public CommandLine (string[] args) 
		{
			Times = 1;
			MakeAvg = false;
			WriteInOutput = false;
			correct = parse(args);
		}

		public bool isIncorrect() {
			return !correct;
		}
	}

}
