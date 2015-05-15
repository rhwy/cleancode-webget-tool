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


namespace nget_v1
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
			var sw = new StringWriter();
		    Console.SetOut(sw);
		    
		    string[] args = {};
		    
		    var nget = new Nget(args);
			
			const string expected = @"Utilisataion : <get|test> -url <url> <-times|-save> <nb_of_loads> -avg";
		    
		    Assert.AreEqual(expected, sw.ToString());
		}
		
		[Test]
		public void AfficheUrl()
		{
			var sw = new StringWriter();
		    Console.SetOut(sw);
		    
		    string[] args = {};
		    
		    var nget = new Nget(args);
			
			const string expected = @"Utilisataion : <get|test> -url <url> <-times|-save> <nb_of_loads> -avg";
		    
		    Assert.AreEqual(expected, sw.ToString());
		}
	}
}