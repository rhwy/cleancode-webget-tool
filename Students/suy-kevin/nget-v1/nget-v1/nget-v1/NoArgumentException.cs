using System;

namespace ngetv1
{
	public class NoArgumentException : Exception
	{
		public NoArgumentException() : base("Pas d'argument")
		{
		}
	}
}

