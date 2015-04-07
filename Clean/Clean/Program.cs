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

namespace Clean
{
	class Program
	{
		public static void Main(string[] args)
		{
			
        for (int i = 0; i < args.Length; i++)
        {
        	if(args.Length == 0 ){
        		Console.WriteLine(" Enter arguments ");} // if any agrument
        	if(args[0] == "get" && args [1] =="-url")
        	{
        		Console.WriteLine(args[2]);
        	}
        	if(args[3] ==  "save")
        	{
        		WebClient client = new WebClient (); 
				{
        			client.DownloadFile(args[2]);
        			string code = client.DownloadString(args[4]);
        			StreamWriter w = new StreamWriter (args[4]) ;
        			w.WriteLine(code);
        			w.Close ;
			    }
        	if(args[4] = " -time")
        		{
        			
        		}
        	}
        	
        	
			
			// TODO: Implement Functionality Here
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}