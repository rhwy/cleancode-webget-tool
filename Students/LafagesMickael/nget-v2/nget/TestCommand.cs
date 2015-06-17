using System;
using System.Linq;

namespace nget
{
	class TestCommand : ICommand
	{
		public String Url { get; private set; }
		public int Times { get; private set; }
		public bool MakeAvg { get; private set; }

		public bool parse( string[] args ) {
			if (args.Length < 3)
				return false;
			for(int i = 1; i < args.Length; ++i) {
				switch(args[i]) {
					case "-url":
						if (i < args.Length - 1 && args [++i] [0] != '-') {
							Url = args [i];
							if (Url [0] == '\"') {
								Url = Url.Substring (1, Url.Length - 2);
								if(!Uri.IsWellFormedUriString(Url, UriKind.Absolute)) 
									return false;
							}
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
			return Url.Length != 0;
		}

		public void execute() {
			try {
				Double[] times = new Double[Times];
				for(int i = 0; i < Times; ++i) {
					var watch = System.Diagnostics.Stopwatch.StartNew();
					NGetUtils.getUrlContent(Url);
					var duration = watch.ElapsedMilliseconds;
					times[i] = duration;
					Console.WriteLine ("Duration {0}", duration);

				}
				if(MakeAvg) {
					Console.WriteLine ("Average {0}", times.Average());
				}
			}
			catch (Exception e) {
				Console.WriteLine ("An error occured: {0}", e.Message);
			}
		}
	}

}
