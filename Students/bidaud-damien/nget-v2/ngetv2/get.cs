using System;
using System.IO;
using System.Net;

namespace ngetv2
{
    class get : IArgument
    {
        public string[] Argument
        {
            get;
            set;
        }

        public WebConnection Connection { get; set; }


        public void execute()
        {

            if (Argument.Length > 1)
            {
                string url = Argument[1];

                try
                {
                    string data = Connection.GetData(url);
                    if (Argument.Length == 2)
                    {
                        Console.WriteLine(data);
                    }
                    else if (Argument.Length > 2)
                    {
                        SaveData(data);
                    }
                }
                catch (WebException)
                {
                    Console.WriteLine("L'adresse n'est pas correct");
                }
            }
        }


        public void SaveData(string data)
        {
            if (Array.Find(Argument, findElement) != null)
            {
                try
                {
                    File.WriteAllText(Argument[3], data);
                    Console.WriteLine("Fichier sauvegarder!");
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("Vous ne posséder pas les droits pour sauvegarder un ficher {0}", Argument[3]);
                }
            }
        }

        public bool findElement(string element)
        {
            return element == "-save";
        }
    }
}
