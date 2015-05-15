/*
 * Created by SharpDevelop.
 * User: Griev_000
 * Date: 07/04/2015
 * Time: 12:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace nget_v1
{
	class Program
	{
		public static void Main(string[] args)
		{
			if(args.Length == 0){
				Console.WriteLine("Veuillez saisir des parametres");
			}else{
				if(args[0] == "get"){
					if(args[1] == "-url"){
						Console.WriteLine("test");
					}
				}else if(args[0] == "test"){
				
				}
			}

		}
	}
}