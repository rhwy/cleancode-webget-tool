package edu.esgi.clean.code.process;

import java.io.PrintWriter;
import java.util.HashMap;
import java.util.regex.Pattern;

import edu.esgi.clean.code.define.IProcess;

public class SaveProcess implements IProcess {
	HashMap<String,Pattern> patterns = null ;
	HashMap<String,String>   matches = null ;
	
	
	public SaveProcess(){
		this.matches  = new HashMap<String,String>() ;
		
		this.patterns = new HashMap<String,Pattern>(){

			private static final long serialVersionUID = 1L;

			{
				put( "FILENAME" , Pattern.compile( "\\-save ([A-Za-z0-9])" , Pattern.CASE_INSENSITIVE ) ) ;
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
	public Object apply( final StringBuilder previous , final HashMap<String, String> args) {

		if( null == args.get("FILENAME") )
			return previous ;
		
		try {
			PrintWriter writer = new PrintWriter( args.get("FILENAME"), "UTF-8" ) ;
			writer.println(previous.toString());
			writer.close();
		} catch( final Exception e ){
			e.printStackTrace();
		}
		
		previous.setLength(0); ;
		
		return "" ;
	} ;
}
