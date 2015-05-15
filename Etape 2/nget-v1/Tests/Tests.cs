using System;
using NUnit.Framework;

namespace ngetv1
{
	[TestFixture]
	public class Tests
	{
		[Test]
		public void GetTaskTests ()
		{
			string[] args = new[] { "get", "-url", "\"http://google.com/\"" };
			new WebGet (args);
		}

		[Test]
		public void GetTaskTestsWithSave ()
		{
			string[] args = new [] { "get", "-url", "\"http://google.com\"", "-save", "\"c:\\abc.json\""};
			new WebGet (args);
		}

		[Test]
		public void TestTaskTests ()
		{
			string[] args = new [] {"test","-url" ,"\"http://google.com\"", "-times" ,"5"};
			new WebGet (args);
		}

		[Test]
		public void TestTaskTestsWithAvg ()
		{
			string[] args =new [] {"test","-url" ,"\"http://google.com\"", "-times" ,"5","-avg"};
			new WebGet (args);
		}
	}
}

