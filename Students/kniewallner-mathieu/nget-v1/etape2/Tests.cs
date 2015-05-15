using NUnit.Framework;
using System;
using System.Text;
using System.IO;

namespace ngetv1
{
	[TestFixture ()]
	public class Test
	{
		[Test ()]
		public void TestCase ()
		{
			var args = new string[]{"get", "-url", "http://www.google.fr"};

			string expected = "";

			var sb = new StringBuilder ();
			var writer = new StringWriter (sb);
			Console.SetOut (writer);

			MainClass.Main (args);

			var result = sb.ToString ();

			Assert.AreEqual (expected, result);
		}
	}
}