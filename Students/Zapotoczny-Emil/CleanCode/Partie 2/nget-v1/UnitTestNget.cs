/*
 * Created by SharpDevelop.
 * User: Emil
 * Date: 15/05/2015
 * Time: 18:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NUnit.Framework;

namespace nget_v1
{
	/// <summary>
	/// Description of UnitTestNget.
	/// </summary>
	
	[TestFixture ()]
	public class UnitTestNget
	{
		Nget nget;
		[TestFixtureSetUp]
		public void TestInitialize()
		{
			nget = new Nget();
		}
		
		[Test]
		public void ReadMethodWhenUriIsNullTest()
		{
			Uri uri = null;
			string response;
			response = nget.ReadMethod(uri);
			
			Assert.IsNull(uri);
			StringAssert.AreEqualIgnoringCase(response, "Reader fail");
		}
		
		[Test]
		public void ReadMethodWhenUriIsNotNullTest()
		{
			var uri = new Uri("http://www.fake.esgi.fr");
			string response;
			response = nget.ReadMethod(uri);
			
			Assert.IsNotNull(uri);
			StringAssert.AreEqualIgnoringCase(response, "Reader fail");
		}
		
		[Test]
		public void ReadMethodWhenUriIsValid()
		{
			var uri = new Uri("http://www.voila.fr");
			string response;
			response = nget.ReadMethod(uri);
			
			Assert.IsNotNull(uri);
			StringAssert.AreNotEqualIgnoringCase(response, "Reader fail");
			Assert.IsTrue(response.Length > 0);
		}
		
		[Test]
		public void ExecuteDownloadStringWithUriAndNbBadTest()
		{
			Uri uri = null;
			string response=string.Empty;
			double returnMessage = -1;
			
			try
			{
				returnMessage = nget.ExecuteDownloadString(uri, 2, false);
			}
			catch(Exception ex)
			{
				response = ex.Message;
			}
			Assert.IsNull(uri);
			StringAssert.AreEqualIgnoringCase(response, "ExecuteDownloadString is end with errors");
			Assert.AreEqual(-1,returnMessage);
		}
	
		
		[Test]
		[TestCase("http://www.voila.fr",0)]
		[TestCase("http://www.voila.fr",-1)]
		[TestCase(null,0)]
		[TestCase(null,-1)]
		public void ExecuteDownloadStringMultipleTest(string stringUri,int nb)
		{
			Uri uri = null;
			if(stringUri != null) uri = new Uri(stringUri);
			string response=string.Empty;
			double returnMessage=0;
			try
			{
				returnMessage = nget.ExecuteDownloadString(uri,nb,false);
			}
			catch(Exception ex)
			{
				response = ex.Message;
			}
			StringAssert.AreNotEqualIgnoringCase(response, "ExecuteDownloadString is end with errors");
			Assert.AreEqual(0, returnMessage);
		}
		
		[Test]
		public void IsValidArgumentsIsFalseTest()
		{
			bool res = false;
			string message = string.Empty;
			try
			{
				res = nget.IsValidArguments(new string[2]);
			}
			catch(Exception ex)
			{
				message = ex.Message;
			}
			
			StringAssert.AreEqualIgnoringCase(message, "Should get arguments");
			Assert.AreEqual(false,res);
		}
		
		[Test]
		public void IsValidArgumentsIsTrueTest()
		{
			bool res = false;
			string message = string.Empty;
			try
			{
				res = nget.IsValidArguments(new string[5]);
			}
			catch(Exception ex)
			{
				message = ex.Message;
			}
			
			StringAssert.AreNotEqualIgnoringCase("Should get arguments", message);
			Assert.AreEqual(true, res);
			StringAssert.AreEqualIgnoringCase(string.Empty,message);
		}
	}
}
