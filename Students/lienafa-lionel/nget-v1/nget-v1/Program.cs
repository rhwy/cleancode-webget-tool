/*
 * Created by SharpDevelop.
 * User: Lionel
 * Date: 07/04/2015
 * Time: 12:07
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
			switch(args[0]) {
				case "get":
					if(args[1] == "-url") {
						Console.WriteLine("Adresse: " + args[2]);
					}
					break;
				case "test":
					break;
				default:
					break;
			}
			Console.ReadKey(true);
		}
	}
}