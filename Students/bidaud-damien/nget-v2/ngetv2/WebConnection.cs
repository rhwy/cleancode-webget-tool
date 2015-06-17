using System;
using System.Net;

namespace ngetv2
{
    class WebConnection
    {
        private WebClient Client;
        public WebConnection()
        {
            Client = new WebClient();
        }

        public string GetData(String url)
        {
            return Client.DownloadString(url);
        }

        public int loadTime(string url)
        {
            WebClient client = new WebClient();
            DateTime first, second;
            try
            {
                first = DateTime.Now;
                client.DownloadString(url);
                second = DateTime.Now;

                return second.Subtract(first).Milliseconds;

            }
            catch (WebException e)
            {
                Console.WriteLine(e);
                return 0;
            }

        }

    }
}
