/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package nget;

import java.io.BufferedReader;
import java.io.File;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.MalformedURLException;
import java.net.URL;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author Alexis Ragot <alexis.ragot@maarch.org>
 */
public class FileReaderOkImpl implements IFileReader{

    @Override
    public String readUrlFile(String urlFile) {
        String result = "";
        try {
            URL url = new URL(urlFile);
            BufferedReader in = new BufferedReader(new InputStreamReader(url.openStream()));
            
            String inputLine;
            
            while ((inputLine = in.readLine()) != null) {
                result += inputLine;
            }
            
            in.close();
            
            return result;
        } catch (MalformedURLException ex) {
            Logger.getLogger(FileReaderOkImpl.class.getName()).log(Level.SEVERE, null, ex);
        } catch (IOException ex) {
            Logger.getLogger(FileReaderOkImpl.class.getName()).log(Level.SEVERE, null, ex);
        }
        return result;
    }

    @Override
    public boolean copieFile(String origine, String destination) {
        try {
            URL url = new URL(origine);
            BufferedReader in = new BufferedReader(new InputStreamReader(url.openStream()));
            File file = new File(origine);
            PrintWriter writer = new PrintWriter(destination, "UTF-8");
            
            String inputLine;
            while ((inputLine = in.readLine()) != null) {
                writer.println(inputLine);
            }
            
            writer.close();
            in.close();
            
            
        } catch (MalformedURLException ex) {
            Logger.getLogger(FileReaderOkImpl.class.getName()).log(Level.SEVERE, null, ex);
        } catch (IOException ex) {
            Logger.getLogger(FileReaderOkImpl.class.getName()).log(Level.SEVERE, null, ex);
        }
        
        return true;
    }

    @Override
    public boolean readAllFileContent(String fileUrl) {
        try {
            URL url = new URL(fileUrl);
            BufferedReader in = new BufferedReader(new InputStreamReader(url.openStream()));
            while (in.readLine() != null);
            in.close();
        } catch (MalformedURLException ex) {
            Logger.getLogger(FileReaderOkImpl.class.getName()).log(Level.SEVERE, null, ex);
        } catch (IOException ex) {
            Logger.getLogger(FileReaderOkImpl.class.getName()).log(Level.SEVERE, null, ex);
        }
        
        return true;
    }
}
