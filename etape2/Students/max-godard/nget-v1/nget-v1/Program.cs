/*
 * Created by SharpDevelop.
 * User: Max
 * Date: 07/04/2015
 * Time: 12:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Net;
using System.Diagnostics;



namespace nget_v1
{
	class Program
	{
		public const int ARGS_CMD_URL = 1;
		public const int ARGS_URL = 2;
		public const int ARGS_CMD_TIME = 3;
		public const int ARGS_NBTIME = 4;
		public const int ARGS_CMD_SAVE = 3;
		public const int ARGS_PATH = 4;
		public const int ARGS_CMD_AVG = 5;

		public static void Main(string[] args)
		{
			Console.WriteLine("nget.exe v2.0");			
			if(args.Length < 3 || args.Length > 6){
				Console.Write("Nombre d'arguments incorrect . . . ");
				Console.ReadKey(true);
				return;
			}			
			var url = new Url(args[ARGS_URL]);
			switch(args[0].ToLower()){
				case "get":
					if(args.Length > 4 && args[ARGS_CMD_URL]=="-url" && args[ARGS_CMD_SAVE] == "-save"){
						String path = args[ARGS_PATH];
						url.saveContent(path);
					}
					else if(args[ARGS_CMD_URL]=="-url"){
						Console.WriteLine(url.getContent());
					}
					break;
					
				case "test":
					if(args.Length == 5 && args[ARGS_CMD_URL]=="-url" && args[ARGS_CMD_TIME]=="-times"){
						int nbTime = Convert.ToInt32(args[ARGS_NBTIME]);
						url.testLoadingTime(nbTime);
					}else if(args.Length == 6 && args[ARGS_CMD_URL]=="-url" && args[ARGS_CMD_TIME]=="-times" && args[ARGS_CMD_AVG]=="-avg"){
						int nbTime = Convert.ToInt32(args[ARGS_NBTIME]);
						url.testAvgTime(nbTime);
					}else{
						Console.WriteLine("Arguments incorrects");
					}
					break;
				default:
					Console.WriteLine("Commande inconnue");
					break;
			}
			
			
			Console.ReadKey(true);
		}
		
		
		
	}
}