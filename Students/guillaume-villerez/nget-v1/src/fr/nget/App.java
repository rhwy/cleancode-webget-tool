package fr.nget;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.net.URLConnection;

public class App {

	/**
	 * Entry point
	 * 
	 * @param args
	 */
	public static void main(String[] args) {
		// Init the arguments
		Options options = new Options(args);
		
		if(options.getUrl() == null) {
			System.out.println("[x] Error : no url provided");
			System.exit(1);
		}

		System.out.println("[i] Testing with url " + options.getUrl());
		
		// Init the URL
		URL url = null;
		try {
			url = new URL(options.getUrl());
		} catch (MalformedURLException e) {
			System.out.println("[x] Error : url malformed : " + e.getMessage());
			System.exit(1);
		}
		
		// Performs the operation
		try {
			if(options.getTestTime() <= 0)
				readURL(url, options);
			else
				testURL(url, options);
		} catch (IOException e) {
			System.out.println("[x] Error : io exception during request : " + e.getMessage());
			System.exit(1);
		}
		
		System.exit(0);
	}
	
	/**
	 * Read the given URL either to the console or into a file
	 * 
	 * @param url The URL to read
	 * @param options The arguments
	 * @throws IOException Thrown if an error occurred
	 */
	private static void readURL(URL url, Options options) throws IOException {
		// Test connection
		HttpURLConnection conn = null;
		
		try {
			conn = (HttpURLConnection) url.openConnection();
		    conn.setRequestMethod("GET");
			conn.getResponseCode();
		} catch(IOException e) {
			System.out.println("[x] Error : URL unreachable");
			System.exit(1);
		}
		
		// Read mode
		BufferedReader br = new BufferedReader(new InputStreamReader(conn.getInputStream()));
		
		if(options.getFilename() != null) {
			// Write result into a file
			File file = new File(options.getFilename());
 
			if (!file.exists()) {
				file.createNewFile();
			}
			
			BufferedWriter bw = new BufferedWriter(new FileWriter(file));

			String line;
			while((line = br.readLine()) != null)
				bw.write(line);
			bw.close();
			
			System.out.println("[i] Content written to file " + file.getName());
			
		} else {
			// Write directly at the output
			String line;
			while((line = br.readLine()) != null)
				System.out.println(line);
			br.close();
		}
	}
	
	/**
	 * Test the given URL, and display either the load time or the average load time
	 * 
	 * @param url The URL to test
	 * @param options The arguments
	 * @throws IOException Thrown if an error occurred
	 */
	private static void testURL(URL url, Options options) throws IOException {
		URLConnection conn = null;
		long[] results = new long[options.getTestTime()];
		
		// Test mode
		for(int i = 0; i < results.length; i++) {
			char buffer[] = new char[2048];
			long start = System.nanoTime();
			
			// Open connection and read the content
			conn = url.openConnection();
			conn.setUseCaches(false);
			
			InputStreamReader isr = new InputStreamReader(conn.getInputStream());
			while(isr.read(buffer) > 0);
			
			long stop = System.nanoTime();
			results[i] = stop - start;
		}
		
		// Display results
		if(options.isAverage()) {
			long result = 0;
			for(int i = 0; i < results.length; i++) {
				result += results[i];
			}
			System.out.println("[i] Average result : " + ((result/1000000)/results.length) + "ms");
		} else {
			for(int i = 0; i < results.length; i++) {
				System.out.println("[i] Result " + (i + 1) + " : " + (results[i]/1000000) + "ms");
			}
		}
	}
}
