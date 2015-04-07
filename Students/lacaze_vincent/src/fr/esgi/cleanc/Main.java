package fr.esgi.cleanc;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileWriter;
import java.io.InputStreamReader;
import java.net.URL;


public class Main {

	public static void main(String[] args) {
		if (args.length == 0) {
			System.out.println("Aucun argument!");
			return;
		}
		
		switch (args[0]) {
		case "get":
			if (args.length == 3 || args.length == 5) {
				getArgument(args);
			} else {
				System.out.println("Nombre d'arguments incorrect!");
			}
			break;

		case "test":
			if (args.length == 5 || args.length == 6) {
				testArgument(args);
			} else {
				System.out.println("Nombre d'arguments incorrect!");
			}
			break;
			
		default:
			System.out.println("Argument incorrect");
			break;
		}
	}
	
	
	private static void getArgument(String args[]) {
		switch (args[1]) {
		case "-url":
			if (args.length == 5) {
				if (!args[3].equals("-save")) {
					System.out.println("Argument incorrect!");
					return;
				}
				readFile(args[2], args[4]);
				return;
			}
			readFile(args[2], null);
			break;

		default:
			System.out.println("Arguments incorrect!");
			break;
		}
	}
	
	
	private static void testArgument(String args[]) {
		switch (args[1]) {
		case "-url":
			if (!args[3].equals("-times")) {
				System.out.println("Argument incorrect!");
				return;
			}
			
			int cpt = Integer.parseInt(args[4]);
			long tab[] = loadTime(args[2], cpt);
			
			if (args.length == 5) {
				for (long l : tab) {
					System.out.println(l + " milliseconde");
				}
			} else if (args.length == 6) {
				
				if (!args[5].equals("-avg")) {
					System.out.println("Argument incorrect!");
					return;
				}
				
				Long total = (long) 0;
				for (long l : tab) {
					total += l;
				}
				
				System.out.println(total / cpt);
			}
			
			break;

		default:
			System.out.println("Arguments incorrect!");
			break;
		}
	}
	
	
	private static void readFile(String arg1, String arg2) {
		try {
		
			URL oracle = new URL(arg1);
	        BufferedReader in = new BufferedReader(
	        new InputStreamReader(oracle.openStream()));
	        String inputLine;
	        
	        if (arg2 == null) {
	        	while ((inputLine = in.readLine()) != null) {
	    	        System.out.println(inputLine);
	        	}
	        } else {
	        	BufferedWriter out = new BufferedWriter(new FileWriter(arg2));
	        	while ((inputLine = in.readLine()) != null) {
	        		out.write(inputLine);
	        	}
	        	out.close();
	        	System.out.println("Fichier généré");
	        }
	        
	        in.close();
			
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
	
	
	private static long[] loadTime(String arg1, int arg2) {
		
		long tab[] = new long[arg2];
		
		for (int i = 0; i < arg2; i++) {
			long milli1 = System.currentTimeMillis();
			
			try {
				
				URL oracle = new URL(arg1);
		        BufferedReader in = new BufferedReader(
		        new InputStreamReader(oracle.openStream()));
		        String inputLine;
		        
	        	while ((inputLine = in.readLine()) != null) {
	    	        System.out.println(inputLine);
	        	}
		        
		        in.close();
			} catch (Exception e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
	        
			long milli2 = System.currentTimeMillis();
			
			tab[i] = milli2 - milli1;
		}
		
		return tab;
	}
}
