using System;

namespace ngetv1
{
	public class WebGet
	{
		public WebGet (string[] args)
		{
			try {
				// Tester le tableau d'arguments
				if (args.Length == 0) {
					Console.WriteLine (UsageUtils.GetUsage ());
				}

				switch (args [0]) {

				case "get":
					new GetTask (args);
					break;

				case "test":
					new TestTask (args);
					break;

				default:
					Console.WriteLine (UsageUtils.GetStringUnknownParameter (args [0]));
					break;
				}

			} catch (Exception e) {
				Console.WriteLine ("ERROR");
				Console.WriteLine (e);
			}
		}
	}
}

