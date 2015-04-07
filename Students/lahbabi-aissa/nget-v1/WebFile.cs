/*
 * Crée par SharpDevelop.
 * Utilisateur: Aissa
 * Date: 07/04/2015
 * Heure: 12:15
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;

namespace nget_v1
{
	/// <summary>
	/// Description of WebFile.
	/// </summary>
	public class WebFile
	{
		string _url;
		
		public WebFile(string url)
		{
			_url = url;
		}
		
		
		public void print(string url) {
			
		}
		
		public Boolean download(string url, string filename) {
			
			return false;
		}
		
		public Boolean times(string url, int nb_loads, Boolean print_avg) {
			
			return false;
		}
		
		
		
		
	}
}
