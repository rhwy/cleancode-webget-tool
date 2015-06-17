package edu.esgi.clean.code.define;

import java.util.ArrayList;

public interface IMode {
	public ArrayList<IProcess> getProcess() ;
	
	public void apply( String args ) ;
} ;