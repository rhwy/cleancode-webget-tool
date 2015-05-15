/*
 * Crée par SharpDevelop.
 * Utilisateur: hedhili
 * Date: 15/05/2015
 * Heure: 18:20
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.IO;

namespace nget
{
	public interface Ifile{
		void appendAllText(string args,string value);
	}
	
	internal class appendallText : Ifile
	{
		#region Ifile implementation
		public void appendAllText(string args, string value)
		{
			File.AppendAllText(args, value);
		}
	#endregion
	}
}


