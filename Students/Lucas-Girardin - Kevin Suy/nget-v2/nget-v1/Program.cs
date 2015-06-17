/*
 * Created by SharpDevelop.
 * User: Lucas Girardin et Kevin Suy
 * Date: 01/06/2015
 * Time: 17:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;
using System.Net;

namespace nget_v1
{
	class Program
	{
		public static void Main(string[] args)
		{

            try
            {
                Instanciation.Execute(args);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }			
			Console.WriteLine("Appuyez sur n'improte quel touche pour fermer");
			Console.ReadKey();
		}
		
	
		
	}

    public class Instanciation
    {
        public static void Execute(string[] args)
        {
            Commande c = null;
            if (args[0].Equals("get"))
            {
                c = new CommandeGet();
                for (int i = 1; i < args.Length; i += 2)
                {
                    c.args.Add(args[i], args[i + 1]);
                }
            }
            if (args[0].Equals("test"))
            {
                c = new CommandeTest();
                for (int i = 1; i < args.Length; i++)
                {
                    if (args[i].Equals("-avg"))
                    {
                        c.args.Add(args[i], "");
                    }
                    else
                    {
                        c.args.Add(args[i], args[i + 1]);
                        i++;
                    }
                }

            }

            c.execute();
        }
    }
}