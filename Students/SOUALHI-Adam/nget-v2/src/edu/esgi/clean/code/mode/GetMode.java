package edu.esgi.clean.code.mode;

import java.util.ArrayList;
import java.util.Map.Entry;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

import edu.esgi.clean.code.define.AMode;
import edu.esgi.clean.code.define.IProcess;

public class GetMode extends AMode {

	public GetMode( final IProcess... process ){
		super( process );
	} ;
	
	@Override
	public void apply( String args ) {
		
		ArrayList<IProcess> p = this.getProcess() ;
		
		StringBuilder result = new StringBuilder() , previous = new StringBuilder() ;

		for( int i = 0 , len = p.size() ; i < len ; i++ ){
		
			for( Entry<String, Pattern> entry : p.get(i).getArgs().entrySet()) 
				if( p.get(i).getArgs().get(entry.getKey()).matcher( args ).matches() )
				{
					Matcher m = p.get(i).getArgs().get(entry.getKey()).matcher( args ) ;
					
					m.matches();
					
					if( m.groupCount() > 0 )
						p.get(i).setMatche( entry.getKey() , m.group(1) ) ;
				} 
			
			result.append( p.get(i).apply( previous , p.get(i).getMatches() ) );
		}
		
		System.out.println( "result : " + result.toString());
	} ;
} ;
