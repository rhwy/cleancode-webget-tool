using System;
using System.Data;
using System.Diagnostics;
using System.Net;

namespace nget_v1
{
    class CommandManager
    {
        public const string _CMD_GET = "get", _CMD_TEST = "test";
        private readonly string[] _commands = { _CMD_GET, _CMD_TEST };

        public const string _OPT_URL = "-url", _OPT_TIMES = "-times", _OPT_SAVE = "-save", _OPT_AVG = "-avg";
        private readonly string[] _options = { _OPT_URL, _OPT_TIMES, _OPT_SAVE, _OPT_AVG };

        public bool ExecCmd(string[] args)
        {
            if (!(CheckArgs(args) && CheckCommand(args[0]) && CheckOption(args[1])))
                return false;

            switch (args[0])
            {
                case _CMD_GET:
                    return ExecGet(args);
                case _CMD_TEST:
                    return ExecTest(args);
                default:
                    return false;
            }
        }

        public bool ExecTest(string[] args)
        {      
            if (args.Length < 5 && args[0] != _CMD_TEST && args[3] != _OPT_TIMES )
                return false;

            string optName1 = args[1], url = args[2], strNumber = args[4], optName3 = null;

            int number = Convert.ToInt32(strNumber);
            if (args.Length > 5)
                optName3 = args[5];

            bool isAvg = _OPT_AVG.Equals(optName3);
            Test(url, number, isAvg);
            return true;
        }

        private bool ExecGet(string[] args)
        {
            if ( _CMD_GET != args[0] )
                return false;

            string optName1 = args[1], url = args[2], optName2 = null, filePath = null;

            if (args.Length >= 5)
            {
                if (CheckOption(args[3]))
                {
                    optName2 = args[3];
                    filePath = args[4];
                }
                else
                {
                    return false;
                }
            }

            bool doSave = _OPT_SAVE.Equals(optName2);
            Console.WriteLine(Get(url, doSave, filePath));
            return true;
        }

        private string Get(string url, bool doSave, string filePath)
        {
            string stringFromUrl = getStringFromUrl(url);

            if (doSave && filePath!=null)
            {
                new FileHelper().WriteAllText(@filePath, stringFromUrl);
                return "File has been created at " + filePath;
            }
            else
                return stringFromUrl;
        }

        public bool CheckArgs(string[] args)
        {
            if (args == null || args.Length < 3)
            {
                Console.WriteLine("Should get 3 arguments minimum");
                return false;
            }
            return true;
        }

        public bool CheckOption(String myOption)
        {
            bool isOption = false;
            foreach (String option in _options)
                isOption |= option.Equals(myOption);

            if (!isOption)
                Console.WriteLine("This option name is invalid : " + myOption);
            return isOption;
        }

        public String getStringFromUrl(String url)
        {
            return new WebClientHelper().DownloadString(url);
        }

        public void Test(String url, int number, bool isAvg)
        {
            Stopwatch timer = new Stopwatch();
            int total = 0;
            for (int i = 0; i < number; i++)
            {
                timer.Start();
                getStringFromUrl(url);
                timer.Stop();

                TimeSpan timeTaken = timer.Elapsed;
                if (isAvg)
                    total += Convert.ToInt32(timeTaken.Milliseconds);
                else
                    Console.WriteLine(" Time (" + i + ") : " + timeTaken.Milliseconds);
            }
            if (isAvg)
                Console.WriteLine(" Time : " + total / number);
        }

        public bool CheckCommand(string cmd)
        {
            bool isCmd = false;
            foreach (String command in _commands)
                isCmd |= command.Equals(cmd);

            if (!isCmd)
                Console.WriteLine("This command name is invalid");
            return isCmd;
        }
    }
}
