using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nget
{
    class CommandGet : ACommand
    {
        public CommandGet(Options options) : base(options)
        {
        }

        public override bool verifyArguments()
        {
            if (options.url == null)
                return false;
            return true;
        }

        public override void executeCommand()
        {
            if (verifyArguments())
            {
                String webContent = NgetTools.getWebContent(options.url);

                if (options.destinationFilename != null)
                {
                    bool isSaved = NgetTools.save(webContent, options.destinationFilename);
                    Console.WriteLine(isSaved ? "Content saved" : "Error during save");
                }
                else
                    Console.WriteLine(webContent);
            }
        }
    }
}
