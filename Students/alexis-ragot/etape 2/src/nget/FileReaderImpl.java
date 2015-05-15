/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package nget;

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
    
}
