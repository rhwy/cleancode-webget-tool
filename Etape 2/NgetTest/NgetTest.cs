/*
 * Crée par SharpDevelop.
 * Utilisateur: Aissa
 * Date: 15/05/2015
 * Heure: 17:48
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.IO;
using NUnit.Framework;
using nget_v1;

namespace NgetTest
{
	/// <summary>
	/// Description of MyClass.
	/// </summary>
	[TestFixture()]
	public class MyClass
	{
		[Test]
		public void ValidateConsoleOutput()
		{
			StringWriter sw = new StringWriter();
		    Console.SetOut(sw);
		    
		    nget Nget nget = new Nget();
			
			const string expected = @"Utilisataion : <get|test> -url <url> <-times|-save> <nb_of_loads> -avg";
		    
		    Assert.AreEqual(expected, sw.ToString());
		}
		
		
		[Test]
		public void afficheUrl()
		{
			StringWriter sw = new StringWriter();
		    Console.SetOut(sw);
		    
		    nget Nget nget = new Nget();
			
			const string expected = @"Utilisataion : <get|test> -url <url> <-times|-save> <nb_of_loads> -avg";
		    
		    Assert.AreEqual(expected, sw.ToString());
		}
	}
}