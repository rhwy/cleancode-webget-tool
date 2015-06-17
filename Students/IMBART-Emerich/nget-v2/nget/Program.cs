/*
 * User: 626
 * Date: 17/06/2015
 * Time: 15:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;


namespace nget
{
	class Program
	{
        private static List <string> listeDeCommande = new List<string>(new string[] { "get", "test"});
        private static List <string> listeArgument; 

		public static void Main(string[] args)
		{
            listeArgument = new List<string>(args);
            switch (listeDeCommande.IndexOf(args[0]) )
            {
                case 0 :
                    getMethode(args);
                break;

                case 1:
                    testMethode(args);
                break;
            }          
			
			Console.ReadKey(true);
		}
		
		    //Fonction d'affichage de l'URL
		    private static void print(String URL, String path ="")
		    {
                Console.WriteLine(path);
			    var wc = new System.Net.WebClient();
			    try{
           		    if(path == "")
                        Console.WriteLine(wc.DownloadString(URL));
                    else
                        wc.DownloadFile(URL, path);
               }catch(System.Net.WebException e){
           	    Console.WriteLine(e.Message);
               }
			
		    }
		
		    //fonciton de chargement de l'URL
		    private static void NoPrint(string URL)
		    {
			    var wc = new System.Net.WebClient();
			    wc.DownloadString(URL);
		    }
		
		    //Fonction de routage des tests de chargement
		    private static void test(string URL,int compteur, int mode)
		    {
			    long[] tab = new long[compteur];
			    long moyenne = 0;
			    Stopwatch sw = new Stopwatch(); // variable timer
			
			    for(int i = 0 ; i < compteur ; i++)
			    {
				    sw.Start();
				    if(mode == 0) // mode avec affichage
					    print(URL);
				    else
					    NoPrint(URL); // mode sans affichage
				
				    sw.Stop();
				    tab[i]=sw.ElapsedMilliseconds;
				    moyenne += tab[i];				
				    sw = Stopwatch.StartNew(); // reset du timer
			    }
				
			    Console.Clear();
			    if(mode == 0)
				    for(int i = 0 ; i < compteur ; i++)
					    Console.WriteLine("Chargement : " + (i+1) + ": "+ tab[i] + "ms");
			    else
				    Console.WriteLine("Temps moyen de chargement " + moyenne/compteur +" ms");
		    }

            private static void getMethode(string [] args)
            {
                int arg1,arg2;
                string path ="";

                arg1 = listeArgument.IndexOf("-url")+1;
                arg2 = listeArgument.IndexOf("-save")+1;

                if(arg2 > 1) 
                    path = args[arg2]; 

                print(args[arg1],path);	            
            }

            private static void testMethode(string [] args)
            {
                int compteur,mode = 1;

                if (listeArgument.IndexOf("-avg") > 0)
                    mode = 1;

                try
                {
                    compteur = Convert.ToInt32(args[listeArgument.IndexOf("-times") + 1]);
                    test(args[listeArgument.IndexOf("-url") + 1], compteur, mode);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        
	}
}