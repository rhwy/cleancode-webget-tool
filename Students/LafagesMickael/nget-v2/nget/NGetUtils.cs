using System;
using System.Net;

namespace nget {
	
	public class NGetUtils {
		
		static public String getUrlContent( string url ) {
			String content;
			using(WebClient client = new WebClient()) {
				content = client.DownloadString(url);
			}
			return content;
		}

	}
}

