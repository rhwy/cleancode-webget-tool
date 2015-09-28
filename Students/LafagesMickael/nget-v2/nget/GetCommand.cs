using System;
using System.IO;
using nget;

namespace nget
{
	class GetCommand : ICommand
	{
		public String Url { get; private set; }
		public String Output { get; private set; }
		public bool WriteInOutput { get; private set; }

		public GetCommand() {
			WriteInOutput = false;
		}

		public bool parse( string[] args ) {
			if (args.Length < 3)
				return false;
			for (int i = 1; i < args.Length; ++i) {
				switch (args [i]) {
					case "-url":
						if (i < args.Length - 1 && args [++i] [0] != '-') {
							Url = args [i];
							if (Url[0] == '\"') {
								Url = Url.Substring (1, Url.Length - 2);
								if(!Uri.IsWellFormedUriString(Url, UriKind.Absolute)) 
									return false;
							}
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
			return Url.Length != 0;
		}

		public void execute() {
			try {
				String content = NGetUtils.getUrlContent(Url);
				if(WriteInOutput) {
					File.WriteAllText (Output, content);
				}
				else {
					Console.WriteLine (content);
				}
			}
			catch (Exception e) {
				Console.WriteLine ("An error occured: {0}", e.Message);
			}
		}
	}

}
