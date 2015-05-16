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
	public interface IGetSave{
		string isGettSave(string[] args);
	}
	public class isGetSaveClass :IGetSave {
		public string isGettSave(string[] args){
			string res=string.Empty;
			if(string.IsNullOrEmpty(args[3])|string.IsNullOrEmpty(args[4])){
				res="Les paramétre de commande Get save Invalide";
			}else{
				string path=args[4];
				string sURL=args[2];
				WebClient client=new WebClient();
				string value =client.DownloadString(sURL);
				
				if(!File.Exists(path)){
					appendallText app = new appendallText();
					app.appendAllText(args[4],value);
					
					
					
				}
				res="creation de fichier valide";
			}
			return res;
			
		}
	}
	public interface ITestTime{
		string isTesterTime(int n,string s);
	}
	public class isTestTime : ITestTime{
		public string isTesterTime(int numE,string sURL){
			string res=string.Empty;
			int i=0;
			while(i<numE){
				Stopwatch stopwatch = Stopwatch.StartNew();
				WebClient client=new WebClient();
				string value =client.DownloadString(sURL);
				stopwatch.Stop();
				i++;
				res+="le chargement N° :"+i+":"+stopwatch.Elapsed.TotalMilliseconds +" ms\n" ;
			}
			return res;
		}
	}
	
	public class ngetv2
	{
		public static string CMD_TEST ="TEST";
		public static string CMD_GET ="GET";
		public static int NB_ARG_TEST =4;
		public static int NB_ARG_GET =2;
		string resultat=string.Empty;
		public ngetv2(string [] args)
		{
			if (args.Length==0){
				Console.WriteLine("requete vide");
			}
			else{
				switch (args[0]) {
					case "get":
						Console.WriteLine(ArgIsGet(args));
						break;
					case "test":
						Console.WriteLine(ArgIsTest(args));
						break;
						default :
							Console.WriteLine("Commande Invalide");
						break;
				}
			}
		}
		
		string ArgIsGet(string[] args){
			if(isNotValidArgs(args,CMD_GET)){
				resultat="paramétres de commande Get Invalide";
				
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
					isGetSaveClass gsc = new isGetSaveClass();
					resultat=gsc.isGettSave(args);
				}
			}
			return resultat;
		}
		
		string ArgIsTest(string[] args){
			
			resultat="Test : \n";
			if(isNotValidArgs(args,CMD_TEST)){
				resultat="Les paramétre de commande Test Invalide";
			}else if(args.Length==5){
				if( args[1].Equals("-url")&args[3].Equals("-times")){
					int numEssai=int.Parse(args[4]);
					
					string sURL=args[2];
					if(int.Parse(args[4])>0){
						isTestTime t = new isTestTime();
						resultat=t.isTesterTime(numEssai,sURL);
						
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
