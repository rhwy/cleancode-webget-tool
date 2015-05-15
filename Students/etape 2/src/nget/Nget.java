/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package nget;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.io.UnsupportedEncodingException;
import java.net.MalformedURLException;
import java.net.URL;

/**
 *
 * 
 * @author Alexis Ragot <alexis.ragot@maarch.org>
 */
public class Nget {
    
    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        try {
            if ((!args[0].equals("get")) && (!args[0].equals("test"))) {
                throw new Exception("Invalid parameter");
            }
            
            if (!args[1].equals("-url")) {
                throw new Exception("Invalid parameter");
            }
            
            if (args.length == 3) {
                printFileContent(args[2]);
            }
            
            if (args[3] == null || args[4] == null) {
                throw new Exception("Invalid parameter");
            }
            
            if (args[0].equals("get") && args[3].equals("-save") ) {
                copieFileContent(args[2], args[4]);
            }
            
            if (args[0].equals("test") && args[3].equals("-times") ) {
                if(args[5] != null && args[5].equals("-avg")) {
                    fileLoadingTime(args[2], Integer.parseInt(args[4]), true);
                } else {
                    fileLoadingTime(args[2], Integer.parseInt(args[4]), false);
                }
            }
            
        } catch (Exception e) {
            System.out.println(e);
        }
        
    }
    
    private static void printFileContent(String urlFile) throws MalformedURLException, IOException {
        URL url = new URL(urlFile);
        BufferedReader in = new BufferedReader(new InputStreamReader(url.openStream()));

        String inputLine;
        while ((inputLine = in.readLine()) != null) {
            System.out.println(inputLine);
        }
        
        in.close();
    }

    private static void copieFileContent(String originFileUrl, String destinationFileUri) throws MalformedURLException, FileNotFoundException, UnsupportedEncodingException, IOException{
        URL url = new URL(originFileUrl);
        BufferedReader in = new BufferedReader(new InputStreamReader(url.openStream()));
        File file = new File(originFileUrl);
        PrintWriter writer = new PrintWriter(destinationFileUri, "UTF-8");

        String inputLine;
        while ((inputLine = in.readLine()) != null) {
            writer.println(inputLine);
        }
        
        writer.close();
        in.close();
    }
    
    private static void fileLoadingTime(String fileUrl, int nbLoading, boolean isAverage) throws MalformedURLException, IOException {
        float beginTime = 0;
        float executionTime = 0;
        float totalTime = 0;

        URL url = new URL(fileUrl);
            
        for (int i=0; i<nbLoading; i++) {
            beginTime = System.nanoTime();
            BufferedReader in = new BufferedReader(new InputStreamReader(url.openStream()));
            
            while (in.readLine() != null);

            executionTime = System.nanoTime() - beginTime;
            
            if (isAverage) {
                totalTime += executionTime;
            } else {
                System.out.println(executionTime);
            }
            
            in.close();
        }
        
        if (isAverage) {
            System.out.println(totalTime / nbLoading);
        }
        
    }
    
}
