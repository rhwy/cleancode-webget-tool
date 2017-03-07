using System;
using System.IO;
using System.Text;
using NUnit.Framework;

namespace ngetv1
{
	[TestFixture ()]
	public class MyTests
	{
		[Test ()]
		public void should_return_no_arguments ()
		{
			string[] args = new string[]{};

			string expected = "Pas d'arguments";

			var sb = new StringBuilder ();
			var writer = new StringWriter (sb);
			Console.SetOut (writer);

			MainClass.Main (args);

			var result = sb.ToString ();

			Assert.AreEqual (expected, result);
		}
	}
}

