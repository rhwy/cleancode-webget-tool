using System;

namespace ngetv2
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			switch (args [0]) {
			case "get":
				if (Array.IndexOf(args,"-save") != -1) {
					Get (args [1], Array.IndexOf (args, "-save") + 1);
					return;
				}
				Get (args [2]);
				break;
			case "test":
				Test(args[Array.IndexOf(args,"-times") + 1], args[Array.IndexOf(args,"-avg") != -1]);
				break;
			}
		}

		public static void Get(string Url, string ToPath = "")
		{
			Console.WriteLine (Url);
			Console.WriteLine (ToPath);
		}

		public static void Get(string Url)
		{
			Console.WriteLine (Url);
			//Console.WriteLine (GetContent (Url));
		}

		public static String GetContent(string Url)
		{
			return "";
		}

		public static void Test(int Times, bool isAverage = false)
		{
			Console.WriteLine (Times);
			Console.WriteLine (isAverage);
		}
	}
}
