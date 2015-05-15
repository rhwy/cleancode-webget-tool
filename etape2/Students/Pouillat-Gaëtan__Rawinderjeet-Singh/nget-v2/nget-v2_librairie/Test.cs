/*
 * Created by SharpDevelop.
 * User: Griev_000
 * Date: 15/05/2015
 * Time: 18:04
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NUnit.Framework;
using nget_v2;

namespace nget_v2_librairie
{
	[TestFixture]
	public class Test
	{
		[Test]
		public void Should_show_the_content_of_a_page()
		{
			Program prog = new Program();
			string content = prog.getContentByUrl("http://url-bidon.fr");
		    Assert.That(content, Is.EqualTo("<h1>hello</h1>"));
		}
		
		[Test]
		public void should_return_content_page()
		{
			Program prog = new Program();
			string content = "";
			content = prog.getContentByUrl("http://www.google.fr");
			
			Assert.IsNotEmpty(content);
		}
		
		[Test]
		public void should_write_file()
		{
			Program prog = new Program();
			bool result = false;
			result = prog.writeUrlContentInFile("<h1>test_content</h1>","Test.txt");
			Assert.That(result,Is.EqualTo(true));
		}
	}
}
