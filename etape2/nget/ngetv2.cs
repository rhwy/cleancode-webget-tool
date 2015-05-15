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
using System.Net;
using System.Diagnostics;
namespace nget
{
	public class  AppendAllText {
		
	}
	/// <summary>
	/// Description of ngetv2.
	/// </summary>
	public class ngetv2
	{
		public ngetv2(string [] args)
		{
			if (args.Length==0){
				Console.WriteLine("requete vide");
			}
			else{
				/**
				 *Tester Si la commande est get , test ou autre
				 * 
				 */
				if (args[0].Equals("get")){
					ArgIsGet(args);
					/*
					 Tester Si la commande est Test
					 */
				}else if(args[0].Equals("test")){
					
					ArgIsTest(args);
				}else{
					Console.WriteLine("Commande Invalide");
				}
			}
		}
		
		string ArgIsGet(string[] args){
			string resultat= string.Empty;
			/*
					 tester Si la commande get a de paramétres
			 */
			if(string.IsNullOrEmpty(args[1])|string.IsNullOrEmpty(args[2])){
				resultat="paramétres de commande Get Invalide";
				/*
					 tester Si la commande get a de 2 paramétres
					 exepmle : get -url "aa"
				 */
			}else{
				if(args.Length==3 &&args[1].Equals("-url")) {
					string sURL=args[2];
					WebClient client=new WebClient();
					string value =client.DownloadString(sURL);
					resultat=value;
					
					Console.ReadLine();
				}else if(args.Length==3) {
					resultat="les parmamétres de get Erronées";
					
				}else{
					if(string.IsNullOrEmpty(args[3])|string.IsNullOrEmpty(args[4])){
						resultat="Les paramétre de commande Get save Invalide";
					}else{
						string path=args[4];
						string sURL=args[2];
						WebClient client=new WebClient();
						string value =client.DownloadString(sURL);
						
						if(!File.Exists(path)){
							File.AppendAllText(args[4], value);
							
						}
						resultat="creation de fichier valide";
					}
				}
			}
			return resultat;
		}
		
		
		
		string ArgIsTest(string[] args){
			string resultat=string.Empty;
			
			resultat="Test";
			if(string.IsNullOrEmpty(args[1])|string.IsNullOrEmpty(args[2])|string.IsNullOrEmpty(args[3])|string.IsNullOrEmpty(args[4])){
				resultat="Les paramétre de commande Test Invalide";
			}else if(args.Length==5 & args[1].Equals("-url")&args[3].Equals("-times")){
				int numEssai=int.Parse(args[4]);
				int i=0;
				string sURL=args[2];
				if(int.Parse(args[4])>0){
					while(i<numEssai){
						Stopwatch stopwatch = Stopwatch.StartNew();
						WebClient client=new WebClient();
						string value =client.DownloadString(sURL);
						stopwatch.Stop();
						i++;
						resultat="le chargement N° :"+i+":"+stopwatch.Elapsed.TotalMilliseconds +" ms" ;
					}
				}else{
					resultat="Le nombre doit être positive";
				}
			}
			return resultat;
		}
	}
	
}
