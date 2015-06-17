package edu.esgi.clean;

import java.util.HashMap;

import edu.esgi.clean.code.Config;
import edu.esgi.clean.code.define.AMode;
import edu.esgi.clean.code.define.IProcess;
import edu.esgi.clean.code.mode.GetMode;
import edu.esgi.clean.code.mode.TestMode;
import edu.esgi.clean.code.process.SaveProcess;
import edu.esgi.clean.code.process.UrlProcess;

public class Application {
	public static void main( final String[] args ) {

		final HashMap<String,IProcess> process = new HashMap<String,IProcess>(){

			private static final long serialVersionUID = 1L;

			{
				put( "url"  ,  new UrlProcess() ) ;
				put( "save" , new SaveProcess() ) ;
			} ;
		} ;
		
		final HashMap<String,AMode> modes = new HashMap<String,AMode>(){

			private static final long serialVersionUID = 1L;

			{
				put(
					"get"  ,
					new GetMode(
						process.get("url") ,
						process.get("save")
					)
				) ;
				
				put(
					"test" ,
					new TestMode(
						process.get("url")
					)
				) ;
			} ;
		} ;
		
		
		if( args.length < 2 || !modes.containsKey( args[0] ) ){
			System.err.println( Config.err_usage );
			return ;
		}
		
		StringBuilder command_line = new StringBuilder() ;
		
		for( int i = 1 , len = args.length ; i < len ; i++ )
			command_line.append( args[i] + " " ) ;

		modes.get( args[0] ).apply( command_line.toString() );
	} ;
} ; 