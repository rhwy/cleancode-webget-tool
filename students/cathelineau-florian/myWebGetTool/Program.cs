using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myWebGetTool
{
    class Program
    {
        static void Main(string[] args)
        {
            MyWebGetTools myTool = new MyWebGetTools(args);
            myTool.run();
        }

        
    }
}
