/*
 * Crée par SharpDevelop.
 * Utilisateur: hedhili
 * Date: 15/05/2015
 * Heure: 18:08
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using NUnit.Framework;
using System.Text;
using System.IO;
using nget;
namespace nget_test
{
	[TestFixture]
	
	public class MyClass
	{
	
		public void should_print_help_if_no_arguments(){
			var args = new []{"Test"};
			var expected ="requete vide";
			var sb = new StringBuilder();
			var writer = new StringWriter();
			Console.SetOut(writer);
		
			Program.Main(args);
			var resultat = sb.ToString();
			Assert.AreEqual(expected,resultat);
			
			
		}
	}
}