/*
 * Crée par SharpDevelop.
 * Utilisateur: Aissa
 * Date: 07/04/2015
 * Heure: 12:15
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace nget_v1
{
	/// <summary>
	/// Description of WebFile.
	/// </summary>
	public class WebFile
	{
		string _url;
		WebClient _client;
		
		public WebFile(string url)
		{
			_url 	= url;
			_client = new WebClient();
		}
		
		
		public void print() {
			try {
			   string content = _client.DownloadString(_url);
			   Console.Write(content);
			} catch (WebException){
				Console.WriteLine("URL inaccessible");
			} catch (Exception e){
				Console.WriteLine(e);
			}
		}
		
		public void download(string path) {
			
			try {
			   string content = _client.DownloadString(_url);
			   File.WriteAllText(path, content);
			   Console.WriteLine("Données sauvegardées");
			} catch (WebException){
				Console.WriteLine("URL inaccessible");
			} catch (UnauthorizedAccessException){
				Console.WriteLine("L'emplacement indiqué est inaccessible. Merci de vérifier les droits d'accès");
			} catch (Exception e){
				Console.WriteLine(e);
			}
		}
		
		public void times(int nb_loads, Boolean print_avg) {
			long[] duration = new long[nb_loads];
			Stopwatch stopwatch;
			
			// 1) On charge l'URL x fois 
			for (int i = 0; i < nb_loads; i++) {
				stopwatch = Stopwatch.StartNew();
				
				try {
					_client.DownloadString(_url);
				} catch (WebException){
					Console.WriteLine("URL inaccessible");
				} catch (Exception e){
					Console.WriteLine(e);
				}
				
				stopwatch.Stop();
				duration[i] = stopwatch.ElapsedMilliseconds;
			}
			
			
			// 2) Affichage du resultat
			if (print_avg) {
				long moyenne = 0;
				for (int i = 0; i < duration.Length; i++) {
					moyenne += duration[i];
				}
				moyenne = moyenne / nb_loads;
				
				Console.WriteLine("Temps de chargement moyen : " + moyenne + " ms");
			} else {
				for (int i = 0; i < duration.Length; i++) {
					Console.WriteLine(i + " => " + duration[i] + " ms");
				}
			}
			
		}
	}
}
