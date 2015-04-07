/*
 * Created by SharpDevelop.
 * User: Rawinderjeet
 * Date: 07/04/2015
 * Time: 12:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;
using System.Net;

namespace NGET
{
	class Program
	{
		public static string url;
		public static WebClient client;
		
		public Program(String url_link){
			url=url_link;
			client = new WebClient ();
		}
		
		public static string read(){
			string codeHtml = client.DownloadString(url);
			return codeHtml;
		}
		
		public static void write(string fileContent, string path){
			try{
				System.IO.File.WriteAllText(path, fileContent);
				Console.WriteLine("Sauvegarde effectuée");
			}
			catch(Exception e){
				Console.WriteLine(e);
			}
			
		}
		public static void times(int repeats, string Loadurl, bool avg){
			Stopwatch s;
			long[] duration = new long[repeats];
			for (int i=0;i<repeats;i++){
				s=Stopwatch.StartNew();
				client.DownloadString(Loadurl);
				s.Stop();
				duration[i] = s.ElapsedMilliseconds;
				if(avg){
					long overallTime = 0;
					for(i=0;i<duration.Length;i++){
						overallTime += duration[i];
					}
					long average = overallTime / duration.Length;
					Console.WriteLine(average + " ms");
				}
				else{
					Console.WriteLine("Chargement n°"+(i+1)+" : "+duration[i]+" ms");
				}
			}
		}
		
		public static void Main(string[] args)
		{
			if(args.Length>0 && args[1] == "-url"){
				new Program(args[2]);
				if(args[0] == "get"){
					string fileContent = read();
					if(args.Length>3 && args[3] == "-save"){
						write(fileContent, args[4]);
					}
					else{
						Console.WriteLine(fileContent);
					}
				}
	
				else if(args[0] == "test" && args[3] == "-times"){
					int val = Convert.ToInt32(args[4]);
					bool avg = false;
					if(args.Length>5 && args[5] == "-avg"){
						avg = true;
					}
					times(val, args[2], avg);
				}
			}
		}
	}
}