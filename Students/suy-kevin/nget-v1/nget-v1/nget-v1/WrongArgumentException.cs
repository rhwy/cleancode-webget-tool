using System;

namespace ngetv1
{
	public class WrongArgumentException : Exception
	{
		public WrongArgumentException () : base ("Mauvais argument")
		{
			
		}
	}
}

