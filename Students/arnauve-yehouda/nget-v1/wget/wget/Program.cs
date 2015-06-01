using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Diagnostics;

namespace wget
{
    class Program
    {
        static void Main(string[] args)
        {
            bool hasNextCommand = true;
            do
            {
                Console.WriteLine();
                string command = Console.ReadLine();
                char[] separator = new char[] {' '};
                string[] commands = command.Split(separator);
                MyCommand mc = new MyCommand();
                switch (commands[0])
                {
                    case "q":
                    case "quit":
                    case "exit":
                        hasNextCommand = false;
                        break;
                    case "get":
                        if ( commands.Length < 3 || (!commands[1].Equals("-url") && isEmpty(commands[2])) )
                        {
                            Console.WriteLine("try again ! ");
                            mc.helpCommand();
                            break;
                        }
                        if(commands.Length == 5)
                            mc.getCommande(commands[1], commands[2], commands[3], commands[4]);
                        else if (commands.Length == 3)
                            mc.getCommande(commands[1], commands[2]);
                        break;
                    case "test":
                        if ( commands.Length < 5 || (!commands[1].Equals("-url") && isEmpty(commands[2]) && isEmpty(commands[3]) && !commands[3].Equals("-times") && isEmpty(commands[4])))
                        {
                            Console.WriteLine("try again ! ");
                            mc.helpCommand();
                            break;
                        }

                        if (commands.Length == 5)
                            mc.testGetCommand(Int32.Parse(commands[4]), commands[1], commands[2], commands[3], commands[4]);
                        else if (commands.Length == 6)
                            mc.testGetCommand(Int32.Parse(commands[4]), commands[1], commands[2], commands[3], commands[4], commands[5]);
                        break;
                    case "help":
                        mc.helpCommand();
                        break;
                    default:
                        break;
                }
            } while (hasNextCommand);
        }

        public static bool isEmpty(string s)
        {
            return s == null || !s.Equals("");
        }
    }
}
