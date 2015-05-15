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

	public class FakeDownloader: IDownloader {
		public string DownloadString (string path)
		{
			return path;
		}
	}

	public class FakeWriter: IWriter {
		public string Write (string path, string content)
		{
			return "Contenu sauvé";
		}
	}
}