using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace clean_code_v1
{
    public class NgetTools
    {
        private static NgetTools instance;

        private NgetTools() { }

        public static NgetTools getInstance {
            get
            {
                if (instance == null)
                {
                    instance = new NgetTools();
                }
                return instance;
            }
        }

        public String getWebContent(string url)
        {
            String result;
            WebResponse webResponse;
            WebRequest webRequest;

            webRequest = HttpWebRequest.Create(url);
            webResponse = webRequest.GetResponse();
            using (StreamReader sr = new StreamReader(webResponse.GetResponseStream()))
            {
                result = sr.ReadToEnd();
                sr.Close();
            }
            return result;
        }

        public bool save(String content, String filename)
        {
            try
            {
                FileStream fs = File.Create(filename);
                TextWriter sw = new StreamWriter(fs);
                sw.WriteLine(content);
                sw.Close();
                fs.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
        }
    }
}
