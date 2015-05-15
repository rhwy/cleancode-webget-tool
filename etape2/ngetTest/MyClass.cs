/*
 * Crée par SharpDevelop.
 * Utilisateur: hedhili
 * Date: 15/05/2015
 * Heure: 23:57
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using NUnit.Framework;
using System.Text;
using System.IO;
using nget;

namespace ngetTest
{
	[TestFixture]
	public class MyClass
	{
		[Test]
		public void should_print_help_if_no_arguments(){
			//var args = new []{"test","-url","http://api.openweathermap.org/data/2.5/weather?q=paris&units=metric","-times" ,"1"};
			var args = new[]{""};
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