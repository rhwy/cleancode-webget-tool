using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace nget_v1
{
    interface IWebClientHelper
    {
        string DownloadString(string stringUrl);
    }

    public class WebClientHelper : IWebClientHelper
    {
        public string DownloadString(string stringUrl)
        {
            string result = "";
            try
            {
                result = new WebClient().DownloadString(stringUrl);
            }catch(Exception e){
                result = "Can't reach with " + stringUrl;
            }
            return result;
        }
    }
}
