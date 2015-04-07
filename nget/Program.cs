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
namespace nget
{
	class Program
	{
		public static void Main(string[] args)
		{
			if (args.Length==0){
				throw new Exception("commande invalide");
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
						throw new Exception("Les paramétre de commande Get Invalide");
						/*
					 tester Si la commande get a de 2 paramétres
					 exepmle : get -url "aa"
						 */
					}else{
						if(args.Length==3) {
							string sURL=args[2];
							WebClient client=new WebClient();
							string value =client.DownloadString(sURL);
							Console.WriteLine(value);
							
							Console.ReadLine();
						}else {
							if(string.IsNullOrEmpty(args[3])|string.IsNullOrEmpty(args[4])){
								throw new Exception("Les paramétre de commande Get save Invalide");
							}else{
								string path=args[4];
								string sURL=args[2];
								WebClient client=new WebClient();
								string value =client.DownloadString(sURL);
								//Console.WriteLine(value);
								if(!File.Exists(path)){
									File.AppendAllText(args[4], value);
																	
								}
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
					}else{
						int numEssai=int.Parse(args[4]);
						int i=0;
						Console.WriteLine(numEssai);
						string sURL=args[2];
						while(i<numEssai){
							var startTime=DateTime.Now;
							WebRequest wrGetURL=WebRequest.Create(sURL);
							Stream objStream=wrGetURL.GetResponse().GetResponseStream();
							var EndsTime=DateTime.Now;
							i++;
							Console.WriteLine("{0}:{1}",i,EndsTime-startTime);
						}
					}
					
				}
				
				
			}
			
			
			
			Console.ReadKey(true);
		}
	}
}
