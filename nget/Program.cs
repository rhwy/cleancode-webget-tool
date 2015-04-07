/*
 * Crée par SharpDevelop.
 * Utilisateur: hedhili
 * Date: 07/04/2015
 * Heure: 12:20
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.IO;
using System.Net;
using System.Diagnostics;
namespace nget
{
	class Program
	{
		public static void Main(string[] args)
		{
			if (args.Length==0){
				throw new Exception("requete vide");
			}
			else{
				/**
				 *Tester Si la commande est get , test ou autre
				 * 
				 */
				if (args[0].Equals("get")){
					/*
					 tester Si la commande get a de paramétres
					 */
					if(string.IsNullOrEmpty(args[1])|string.IsNullOrEmpty(args[2])){
						throw new Exception("Les paramétres de commande Get Invalide");
						/*
					 tester Si la commande get a de 2 paramétres
					 exepmle : get -url "aa"
						 */
					}else{
						if(args.Length==3 &&args[1].Equals("-url")) {
							string sURL=args[2];
							WebClient client=new WebClient();
							string value =client.DownloadString(sURL);
							Console.WriteLine(value);
							
							Console.ReadLine();
						}else if(args.Length==3) {
							Console.WriteLine("les parmamétres de get Erronées");
							
						}else{
							if(string.IsNullOrEmpty(args[3])|string.IsNullOrEmpty(args[4])){
								throw new Exception("Les paramétre de commande Get save Invalide");
							}else{
								string path=args[4];
								string sURL=args[2];
								WebClient client=new WebClient();
								string value =client.DownloadString(sURL);
								
								if(!File.Exists(path)){
									File.AppendAllText(args[4], value);
									
								}
								Console.WriteLine("creation de fichier valide");
							}
							
						}
						
					}
					/*
					 Tester Si la commande est Test
					 */
				}else if(args[0].Equals("test")){
					Console.WriteLine("Test");
					if(string.IsNullOrEmpty(args[1])|string.IsNullOrEmpty(args[2])|string.IsNullOrEmpty(args[3])|string.IsNullOrEmpty(args[4])){
						throw new Exception("Les paramétre de commande Test Invalide");
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
								Console.WriteLine("le chargement N° :{0}:{1} ms",i,stopwatch.Elapsed.TotalMilliseconds);
							}
						}else{
							Console.WriteLine("Le nombre doit être positive");
						}
						
						
					}
					
				}else{
					Console.WriteLine("Commande Invalide");
				}
				
				
			}
			
			
			
			Console.ReadKey(true);
		}
	}
}
