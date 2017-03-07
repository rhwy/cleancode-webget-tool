using System;

namespace ngetv1
{
	public abstract class ArrayUtils
	{
		public static bool checkArrayLengthCorrect (int index, int length)
		{
			if (index + 1 > length - 1) {
				throw new Exception (UsageUtils.GetUsage ());
			}

			return true;
		}
	}
}

