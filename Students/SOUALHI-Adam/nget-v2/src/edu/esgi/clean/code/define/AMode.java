package edu.esgi.clean.code.define;

import java.util.ArrayList;

public abstract class AMode implements IMode {
	private ArrayList<IProcess> process ;
	
	public AMode( final IProcess... process ){
		this.process = new ArrayList<IProcess>(){
			
			private static final long serialVersionUID = 1L;

			{
				for( int i = 0 , len = process.length ; i < len ; i++ )
					add( process[i] ) ;
			} ;
		} ;
	} ;
	
	@Override
	public ArrayList<IProcess> getProcess() {
		return this.process ;
	} ;
} ;