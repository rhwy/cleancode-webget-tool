using System;

namespace ngetv1
{
	public abstract class UsageUtils
	{
		public static string GetUsage ()
		{
			return "USAGE...";
		}

		public static string GetStringUnknownParameter (string par)
		{
			return "ERROR : Unknown parameter " + par;
		}
	}
}

