/*
 * Created by SharpDevelop.
 * User: Griev_000
 * Date: 07/04/2015
 * Time: 12:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Net;

namespace nget_v1
{
	class Program
	{
		public static String getContentByUrl(string url){
			WebClient wc = new WebClient();
			return wc.DownloadString(url);
		}
		
		public static void Main(string[] args)
		{
			if(args.Length == 0){
				
				Console.WriteLine("saisir parametre");
				
			}else if(args[0] == "get"){
				
				if(args.Length >= 2 && args[1] == "-url"){
					
					if(args.Length >= 5 && args[3] == "-save"){
						
						try{
							
							StreamWriter sw = new StreamWriter(args[4]);
 						
							sw.Write(getContentByUrl(args[2]));
							sw.Close();
							
						}catch(Exception ex){
							Console.WriteLine(ex);
						}
						
						
					}else{
						try{
							Console.WriteLine(getContentByUrl(args[2]));
						}catch(Exception ex){
							Console.WriteLine(ex);
						}
					}
				}
				else{
					Console.WriteLine("parametre de get : -url <url>");
				}
			}else if(args[0] == "test"){
				
				if(args.Length >=4 &&( args[1] == "-url" && args[3] == "-times")){
					
					int fois;
					bool result = Int32.TryParse(args[4], out fois);
					
					if(args.Length == 6 && args[5] == "-avg"){
						
							if(result){
								
								long resultat = 0;
								
								for(int i=0;i<fois;i++){
									
									long milliseconds1 = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
									
									try{
										getContentByUrl(args[2]);
									}
									catch(Exception ex){
										Console.WriteLine(ex);
									}
									
									long milliseconds2 = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
									resultat += milliseconds2 - milliseconds1;
									
								}
								
								Console.WriteLine("moyenne temps chargement: " + resultat/fois);
								
							}else{
								Console.WriteLine("parametre -time : entier attendu");
							}
					}
					else{
	      				
						if(result){
							
							for(int i=0;i<fois;i++){
								
								long milliseconds1 = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
								
								try{
									getContentByUrl(args[2]);
								}
								catch(Exception ex){
									Console.WriteLine(ex);
								}
								
								long milliseconds2 = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
								long resultat = milliseconds2 - milliseconds1;
								
								Console.WriteLine("temps test numero" + i + " : " + resultat);
							}
							
						}else{
							Console.WriteLine("parametre -time : entier attendu");
						}
					}	
				}
			}
		}
	}
}