using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace nget_v1
{
    interface IFileHelper
    {
        void WriteAllText(string filePath, string stringUrl);
    }

    class FileHelper : IFileHelper
    {
        public void WriteAllText(string filePath, string stringUrl)
        {
            File.WriteAllText(filePath, stringUrl);
        }
    }
}
