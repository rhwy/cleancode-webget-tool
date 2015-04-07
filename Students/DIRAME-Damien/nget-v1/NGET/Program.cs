/*
 * Created by SharpDevelop.
 * User: Damien
 * Date: 07/04/2015
 * Time: 12:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Net.Mail;

namespace NGET
{
	class Program
	{
		public static void Main(string[] args)
		{
			int nb;
			if (args != null && args.Length>0){
				if (args[0]=="get"){
					if (args.Length>2 && args[1]=="-url"){
						
							Uri uri = new Uri(args[2]);
							WebRequest request = WebRequest.Create(uri);
							WebResponse response = request.GetResponse();
							StreamReader sr = null;
							sr = new StreamReader(response.GetResponseStream());
							string contenu = sr.ReadToEnd();
							if (args.Length>4 && args[3]=="-save"){
								File.WriteAllText(args[4], contenu);
							}
							else {
								Console.WriteLine(contenu);
							}
						}
					
				}
				else if(args.Length>4 && args[0]=="test" && args[1]=="-url" && args[3]=="-times" && Int32.TryParse(args[4], out nb)){
						
							Uri uri = new Uri(args[2]);					
							WebRequest request = WebRequest.Create(uri);
							double[] times = new double[nb];
							for (int i = 0; i<nb; i++){
								Stopwatch timer = new Stopwatch();
								timer.Restart();
								WebResponse response = request.GetResponse();
								response.Close ();
								timer.Stop();
								times[i]=timer.Elapsed.TotalMilliseconds;
							}
							if(args.Length>5 && args[5]=="-avg"){
								double avgtime=0;
								for (int i = 0; i<times.Length; i++){
									avgtime=avgtime+times[i];
								}
								avgtime=avgtime/times.Length;
								Console.WriteLine(avgtime + " ms en moyenne");
							}
							else{
								for (int i = 0; i<times.Length; i++){
									Console.WriteLine(times[i] + "ms");
								}
							}
						
						
				}
				Console.ReadKey(true);
			}
		}
	}
}