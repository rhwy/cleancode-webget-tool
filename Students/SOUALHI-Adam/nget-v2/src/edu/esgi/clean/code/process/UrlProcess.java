package edu.esgi.clean.code.process;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.net.URL;
import java.net.URLConnection;
import java.util.HashMap;
import java.util.regex.Pattern;

import edu.esgi.clean.code.define.IProcess;

public class UrlProcess implements IProcess {

	HashMap<String,Pattern> patterns = null ;
	HashMap<String,String>   matches = null ;
	
	
	public UrlProcess(){
		this.matches  = new HashMap<String,String>() ;
		
		this.patterns = new HashMap<String,Pattern>(){

			private static final long serialVersionUID = 1L;

			{
				put( "URL" , Pattern.compile( "\\-url ((ftp|http(s?)):(.*))" , Pattern.CASE_INSENSITIVE ) ) ;
			} ;
		} ;
	} ;
	
	@Override
	public HashMap<String,Pattern> getArgs() {
		return this.patterns ;
	} ;

	@Override
	public void setMatche(String key, String value) {
		this.matches.put(key, value) ;
	}

	@Override
	public HashMap<String, String> getMatches() {
		return this.matches ;
	}

	@Override
	public Object apply( final StringBuilder previous , HashMap<String, String> args) {
		
		StringBuilder response = new StringBuilder() ;
		
		try {
			
			URL yahoo = new URL(args.get("URL"));
            URLConnection yc = yahoo.openConnection();
            BufferedReader in = new BufferedReader(new InputStreamReader(
                    yc.getInputStream(), "UTF-8"));
            String inputLine;
            while ((inputLine = in.readLine()) != null)
                response.append(inputLine);
            in.close();
			
		} catch( final Exception e ){
			e.printStackTrace();
		}
		
		previous.append(response.toString()) ;
		
		return "" ;
	} ;
} ;
