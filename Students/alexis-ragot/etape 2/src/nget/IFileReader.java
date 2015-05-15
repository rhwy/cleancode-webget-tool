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
public interface IFileReader {
    
    public String readUrlFile(String urlFile);
    public boolean copieFile(String origine, String destination);
    
}
