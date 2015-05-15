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
 * ETAPE 2
 * @author Alexis Ragot <alexis.ragot@maarch.org>
 */
public class Nget {
    
    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        FileManager fileManager = new FileManager();
        IFileReader fileReader = new FileReaderImpl();
        try {
            if ((!args[0].equals("get")) && (!args[0].equals("test"))) {
                throw new Exception("Invalid parameter");
            }
            
            if (!args[1].equals("-url")) {
                throw new Exception("Invalid parameter");
            }
            
            if (args.length == 3) {
                String content = "";
                content = fileManager.getFileContent(args[2], fileReader);
                System.out.println(content);
            }
            
            if (args[3] == null || args[4] == null) {
                throw new Exception("Invalid parameter");
            }
            
            if (args[0].equals("get") && args[3].equals("-save") ) {
                fileManager.copieFileContent(args[2], args[4]);
            }
            
            if (args[0].equals("test") && args[3].equals("-times") ) {
                if(args[5] != null && args[5].equals("-avg")) {
                    fileManager.fileLoadingTime(args[2], Integer.parseInt(args[4]), true);
                } else {
                    fileManager.fileLoadingTime(args[2], Integer.parseInt(args[4]), false);
                }
            }
            
        } catch (Exception e) {
            System.out.println(e);
        }
        
    }
    
}
