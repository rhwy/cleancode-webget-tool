using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;


namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("inserer key : ");
           // String  choix  = Console.ReadLine();
            String choix = "get -url http://www.cs.tut.fi/~jkorpela/fileurl.html";
            var cli = new WebClient();
            String data;
            String url ="";
            String[] parametres = choix.Split();



            switch (parametres[0])
            {
                case  "get":
                    if (parametres[1] == "-url")
                    {
                        url = parametres[2];
                       
                        data = cli.DownloadString(url);
                        Console.WriteLine(data);

                    }

                    if (parametres[3] != "")
                    {
                      switch(parametres[3]){
                            case "-save":
                            if (parametres[4] !="")
                             {
                                String chemin = parametres[4];
                                data = cli.DownloadString(url);
                                System.IO.File.WriteAllText(chemin, data);
                              }
                              break;

                            case "-times":
                              if (parametres[4] != "")
                              {
                                  String chemin = parametres[4];
                                  data = cli.DownloadString(url);
                                  System.IO.File.WriteAllText(chemin, data);
                              }
                              break;
                      }   
                    }

                        break;

                

               // case "-times" :
            }
          
                    


            


        }


    }
}
