/*
 * Created by SharpDevelop.
 * User: ludovik
 * Date: 07/04/2015
 * Time: 12:21
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Net;

namespace Clean
{
	class Program
	{
		public static void Main(string[] args)
		{
        	if(args.Length == 0 ){
        		Console.WriteLine(" Enter arguments ");}
			
			else if(args[0] == "get") 
        	{
				if(args.Length  >=2 && args [1] ==" -url"){
					if(args.Length >= 5 && args[3] ==  "-save"){
						try{
						WebClient client = new WebClient (); 
        				string code = client.DownloadString(args[2]);
        				StreamWriter w = new StreamWriter (args[4]) ;
        				w.WriteLine(code);
        				w.Close();
					}
						catch(Exception exception){
							Console.WriteLine(exception);}
							
				}
			 } 
	    }
	}
}
}
