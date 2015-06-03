/*
 * Created by SharpDevelop.
 * User: Gabi
 * Date: 07/04/2015
 * Time: 12:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Net;
using System.Diagnostics;

namespace nget_v1{
	class Program{
		static readonly String _CMD_GET = "get";
		static readonly String _CMD_TEST = "test";
		static readonly String[] Commands = {_CMD_GET, _CMD_TEST};
		
		static readonly String _OPT_URL = "-url";
		static readonly String _OPT_TIMES = "-times";
		static readonly String _OPT_SAVE = "-save";
		static readonly String _OPT_AVG = "-avg";
		static readonly String[] Options = {_OPT_URL, _OPT_TIMES, _OPT_SAVE, _OPT_AVG};
		
		public static void Main(string[] args){
			bool isCmd = false;
			if(args==null || args.Length < 3)
				throw new ArgumentException("Should get 3 arguments minimum");

			foreach (String command in Commands)
				isCmd |= command.Equals(args[0]);
			if(!isCmd)
				throw new InvalidExpressionException("This command name is invalid");

			checkAllOptions(args[1]);
			
			String cmdName = null, optName1 = null,  optName2 = null, optName3 = null;
			String url = null, filePath=null, stringFromUrl = null;
			cmdName = args[0];
			optName1 = args[1];
			url = args[2];
			
			if(args.Length >= 5){
				checkAllOptions(args[3]);
				
				optName2 = args[3];
				filePath = args[4];
			}
			if(cmdName == _CMD_GET){
				stringFromUrl = getStringFromUrl(url);
				
				if(optName2 == _OPT_SAVE){
					System.IO.File.WriteAllText(@filePath, stringFromUrl);
					Console.WriteLine("Creation de fichier réussi à " + filePath);
				}else{
					Console.WriteLine(stringFromUrl);
				}
			}

			if(cmdName == _CMD_TEST){
				if(optName2 == _OPT_TIMES){
					int number = Convert.ToInt32(args[4]);
					bool isAvg = false;
					if(args.Length >= 6){
						optName3 = args[5];
					}
					isAvg = _OPT_AVG.Equals(optName3);
					test(url, number, isAvg);
				}
			}
			Console.ReadKey(true);
		}
		
		public static void checkAllOptions(String myOption){
			bool isOption = false;
			foreach (String option in Options)
				isOption |= option.Equals(myOption);
			
			if(!isOption)
				throw new InvalidExpressionException("This option name is invalid : "+ myOption);
		}
		
		public static String getStringFromUrl(String url){
			return new WebClient().DownloadString(url);
		}

		public static void test(String url, int number, bool isAvg){
			Stopwatch timer = new Stopwatch();
			int total = 0;
			for(int i = 0; i < number; i++){
				timer.Start();
				getStringFromUrl(url);
				timer.Stop();
				
				TimeSpan timeTaken = timer.Elapsed;
				if(isAvg){
					total += Convert.ToInt32(timeTaken.Milliseconds);
				}else{
					Console.WriteLine(" Time ("+ i +") : " + timeTaken.Milliseconds);
				}
			}
			if(isAvg)
				Console.WriteLine(" Time : " + total/number);
		}
	}
}