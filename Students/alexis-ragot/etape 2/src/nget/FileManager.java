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
    
    public float fileLoadingTime(String fileUrl, int nbLoading, boolean isAverage, IFileReader fileReader) throws MalformedURLException, IOException {
        float beginTime = 0;
        float executionTime = 0;
        float totalTime = 0;
        float result = 0;

        for (int i=0; i<nbLoading; i++) {
            beginTime = System.nanoTime();
            fileReader.readAllFileContent(fileUrl);
            executionTime = System.nanoTime() - beginTime;
            
            if (isAverage) {
                totalTime += executionTime;
            } else {
                System.out.println(executionTime);
            }
        }
        
        if (isAverage) {
            result = totalTime / nbLoading;
            System.out.println(result);
            return result;
        }
        
        return 0;
    }
}
