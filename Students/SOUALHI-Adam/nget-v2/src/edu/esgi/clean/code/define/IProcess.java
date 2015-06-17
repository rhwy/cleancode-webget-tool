package edu.esgi.clean.code.define;

import java.util.HashMap;
import java.util.regex.Pattern;

public interface IProcess {
	public Object apply( StringBuilder previous , HashMap<String,String> args ) ;
	public HashMap<String,Pattern> getArgs() ;
	public void setMatche( String key , String value );
	public HashMap<String,String> getMatches() ;
} ;