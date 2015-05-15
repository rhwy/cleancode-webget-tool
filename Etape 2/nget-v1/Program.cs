/*
 * Crée par SharpDevelop.
 * Utilisateur: Aissa
 * Date: 07/04/2015
 * Heure: 11:42
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.Net;

namespace nget_v1
{
	class Program
	{	
		public static void Main(string[] args)
		{
			Nget nget = new Nget(args);
			Console.ReadKey(true);
		}
		
		
	}
}