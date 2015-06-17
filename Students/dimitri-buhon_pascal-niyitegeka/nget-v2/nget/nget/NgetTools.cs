using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace nget
{
    public class NgetTools
    {
        public static String getWebContent(string url)
        {
            WebRequest webRequest;
            WebResponse webResponse;   
            StreamReader streamReader;
            String result = string.Empty;

            try
            {
                webRequest = HttpWebRequest.Create(url);
                webResponse = webRequest.GetResponse();

                streamReader = new StreamReader(webResponse.GetResponseStream());
                result = streamReader.ReadToEnd();
                streamReader.Close();
            }
            catch(Exception e){
                Console.WriteLine("[Exception] " + e.TargetSite + " : " + e.Message);
            }
            return result;
        }

        public static bool save(String content, String filename)
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
                Console.WriteLine("[Exception] " + e.TargetSite + " : " + e.Message);
                return false;
            }
        }
    }
}
