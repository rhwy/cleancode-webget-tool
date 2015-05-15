/*
 * Created by SharpDevelop.
 * User: Max
 * Date: 15/05/2015
 * Time: 17:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Net;
using System.Diagnostics;

namespace nget_v1
{
	/// <summary>
	/// Description of Url.
	/// </summary>
	public class Url
	{
		string address;
		string content;
		
		public string Address{
			get{
				return address;
			}
		}
		
		public Url(string ad)
		{
			address = ad;
			content = getContent();
		}
		
		public string getContent(){
			try{
				return (new WebClient().DownloadString(address));
			}catch(Exception e){
				return ("Erreur lecture url: " + e.Message);
			}
		}
		
		public string saveContent(string path){
			string result="";
			try{
				result=getContent();
				File.WriteAllText(path, getContent());
			}catch(Exception e){
				result="Erreur écriture fichier: " + e.Message;
			}
			return result;
		}
		
			
		public string testLoadingTime(int nbTime){			
			string result="";
			var sw = new Stopwatch();
			for(int cpt=1; cpt<nbTime+1; cpt++){
				swManager(sw);
				result+="Temps" + (cpt) + ":" + sw.ElapsedMilliseconds + "ms";
				Console.WriteLine(result);
				sw.Restart();
			}
			 return result;
		}
		
		public string testAvgTime(int nbTime){
			string result = "";
			var sw = new Stopwatch();
			int avg=0;
			Console.WriteLine("Calcul de la moyenne en cours . . .");
			for(int cpt=1; cpt<nbTime+1; cpt++){
				swManager(sw);
				avg += Convert.ToInt32(sw.ElapsedMilliseconds);
				sw.Restart();
			}
			avg /= nbTime;
			result = "Moyenne de temps de chargement: " + avg;
			Console.WriteLine(result);
			return result;
		}
		
		public string swManager(Stopwatch sw)
		{
			string res="";
			sw.Start();
			res=getContent();
			sw.Stop();
			return res;
		}
		
	}
}
