/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package nget;

import java.io.IOException;
import java.net.MalformedURLException;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author Alexis Ragot <alexis.ragot@maarch.org>
 */
public class FileReaderImpl implements IFileReader{

    @Override
    public String readUrlFile(String urlFile) {
        return "toto";
    }

    @Override
    public boolean copieFile(String origine, String destination) {
        return true;
    }

    @Override
    public boolean readAllFileContent(String fileUrl) {
        try {
            Thread.sleep(1000);
        } catch (InterruptedException ex) {
            Logger.getLogger(FileReaderImpl.class.getName()).log(Level.SEVERE, null, ex);
        }
        return true;
    }
    
    
    
}
