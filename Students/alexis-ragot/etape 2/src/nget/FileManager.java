/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package nget;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.io.UnsupportedEncodingException;
import java.net.MalformedURLException;
import java.net.URL;

/**
 *
 * @author Alexis Ragot <alexis.ragot@maarch.org>
 */
public class FileManager {
    
    
    public String getFileContent(String urlFile, IFileReader fileReader) throws MalformedURLException, IOException {
        return fileReader.readUrlFile(urlFile);
    }

    public boolean copieFileContent(String originFileUrl, String destinationFileUri, IFileReader fileReader) throws MalformedURLException, FileNotFoundException, UnsupportedEncodingException, IOException{
        
        return fileReader.copieFile(originFileUrl, destinationFileUri);
    }
    
    public void fileLoadingTime(String fileUrl, int nbLoading, boolean isAverage) throws MalformedURLException, IOException {
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
