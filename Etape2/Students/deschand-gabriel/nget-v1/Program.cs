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

    class Program
    {
        public static void Main(string[] args)
        {
            if(new CommandManager().ExecCmd(args))
                Console.WriteLine("Program stops without any error");
            else
                Console.WriteLine("Program has stopped with error");

            Console.ReadKey(true);
        }
    }
}