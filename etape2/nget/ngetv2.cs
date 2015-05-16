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
	
	public class ngetv2
	{
		public static string CMD_TEST ="TEST";
		public static string CMD_GET ="GET";
		public static int NB_ARG_TEST =4;
		public static int NB_ARG_GET =2;
		
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
					Console.WriteLine(ArgIsGet(args));
					/*
					 Tester Si la commande est Test
					 */
				}else if(args[0].Equals("test")){
					Console.WriteLine(	ArgIsTest(args));
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
			if(isNotValidArgs(args,CMD_GET)){
				resultat="paramétres de commande Get Invalide";
				/*
					 tester Si la commande get a de 2 paramétres
					 exepmle : get -url "aa"
				 */
			}else{
				if(args.Length==3 && args[1].Equals("-url")) {
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
							appendallText app = new appendallText();
							app.appendAllText(args[4],value);
							
							
							
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
			if(isNotValidArgs(args,CMD_TEST)){
				resultat="Les paramétre de commande Test Invalide";
			}else if(args.Length==5){
				if( args[1].Equals("-url")&args[3].Equals("-times")){
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
			}else
				resultat= "Test invalid";
			
			return resultat;
		}
		bool isNotValidArgs(string[] Args,string typeCom){
			bool isValid = false;
			if(typeCom.Equals(CMD_TEST)){
				if(Args.Length==NB_ARG_TEST+1)
					for (int i = 0; i < NB_ARG_TEST; i++)
						if(string.IsNullOrEmpty(Args[i+1]))
							isValid=true;
			}else {
				if(Args.Length==NB_ARG_GET)
					for (int i = 0; i < NB_ARG_GET; i++)
						if(string.IsNullOrEmpty(Args[i+1]))
							isValid=true;
			}
			
			
			
			return isValid;
			
		}
	}
	
}
