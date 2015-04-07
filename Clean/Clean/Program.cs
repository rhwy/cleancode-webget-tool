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
			
			else if(args[0] == "get" && args [1] ==" -url")
        	{
        		Console.WriteLine(args[2]);
        		
        		 if(args[3] == "-save")
        	{
        		WebClient client = new WebClient (); 
				{
        			string code = client.DownloadString(args[2]);
        			StreamWriter w = new StreamWriter (args[4]) ;
        			w.WriteLine(code);
        			w.Close();
			     }
        	 }
        	   }
			if(args[5] == "-time")
			{
				
			}
			  
		 }
	}
}
