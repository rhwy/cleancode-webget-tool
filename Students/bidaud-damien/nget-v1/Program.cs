/*
 * Created by SharpDevelop.
 * User: Damien
 * Date: 01/06/2015
 * Time: 15:47
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Net;
using System.IO;

namespace cours1
{
	class Program
	{
				
		public static void Main(string[] args)
		{
			
			if(args.Length==0){
				Console.WriteLine("Aucun argument mis en parametre");
			}else{
				if(args[0] == "get" && args[1] == "-url"){
					string url = args[2];
					WebClient client = new WebClient();
					try{
						string data = client.DownloadString(url);
						if(args.Length == 3){
							//on affiche
							Console.WriteLine(data);
						}else if(args.Length>3){
							if(args[3] == "-save"){
								try{
									//on sauvegarde
									File.WriteAllText(args[4], data);
									Console.WriteLine("Fichier sauvegarder!");
								}catch(UnauthorizedAccessException){
									Console.WriteLine("Vous ne posséder pas les droits pour sauvegarder un ficher {0}", args[4]);
								}
							}
						}
					}catch(WebException){
						Console.WriteLine("L'adresse n'est pas correct");
					}
					
				}else if(args[0] == "test" && args[1] == "-url"){
					string url = args[2];
					int nb = int.Parse(args[4]);
					bool avg = false;
					int somme = 0;
					//on vérifie si on veut la moyenne
					if(args.Length > 5 && args[5]== "-avg"){
						avg = true;
					}
					for(int i = 0; i < nb; i++){
						int time = loadTime(url);
						if(!avg){
							//on affiche chaque temps de chargement si on ne veut pas la moyenne
							Console.WriteLine("{0} : {1}s", i+1, time);
						}
						else{
							//on fait la somme
							somme+=time;
						}
					}
					if(avg){
						//on affiche la moyenne
						Console.WriteLine("La moyenne de ces {0} chargement est de: {1}s", nb, somme/nb);
					}
				
				}
			}
			
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		
		public static int loadTime(string url){
			try{
				WebClient client = new WebClient();
				Int32 start = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
				client.DownloadString(url);
				Int32 end = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
				return end-start;
			}catch(WebException){
				return 0;
			}			
		}
	}
}
