using System;
using NDesk.Options;
using System.Collections.Generic;
using System.Linq;

namespace nget.Argument_Handler
{
    abstract class AArgumentHandler
    {
        public abstract OptionSet getOptions();

        /// <summary>
        /// Parse a set of arguments, matching rules of implemented handler
        /// </summary>
        /// <param name="args">Enumeration of all arguments after command invocation</param>
        public void ParseArguments(IEnumerable<string> args)
        {
            var optionSet = getOptions();

            try
            {
                var _extra = optionSet.Parse(args);

                if (_extra.Any())
                {
                    Console.WriteLine("Unknow argument(s): ");
                    foreach(var arg in _extra)
                        Console.WriteLine("\t" + arg);

                    throw new Exception();
                }
            }
            catch (OptionException e)
            {
                Console.Write("Argument error: ");
                Console.WriteLine(e.Message);
                Console.WriteLine("Use command 'help' to show more informations");
                throw;
            }
        }

        /// <summary>
        /// Execute the internal command, after the parsing of the arguments
        /// </summary>
        public abstract void ExecuteCommand();

        public abstract void CheckArguments();
    }
}
