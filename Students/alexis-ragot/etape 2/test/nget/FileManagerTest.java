/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package nget;

import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;

/**
 *
 * @author Alexis Ragot <alexis.ragot@maarch.org>
 */
public class FileManagerTest {
    
    public FileManagerTest() {
    }
    
    @BeforeClass
    public static void setUpClass() {
    }
    
    @AfterClass
    public static void tearDownClass() {
    }
    
    @Before
    public void setUp() {
    }
    
    @After
    public void tearDown() {
    }

    /**
     * Test of printFileContent method, of class FileManager.
     */
    @Test
    public void testGetFileContent() throws Exception {
        String urlFile = "http://google.fr";
        String result = "";
        
        String exString = "toto";
        
        FileManager instance = new FileManager();
        IFileReader fileReader = new FileReaderImpl();
        result = instance.getFileContent(urlFile, fileReader);
        try {
            assertEquals(exString, result);
        } catch (Exception e) {
            fail("Fail test");
        }
    }

    /**
     * Test of copieFileContent method, of class FileManager.
     */
    @Test
    public void testCopieFileContent() throws Exception {
        String originFileUrl = "toto";
        String destinationFileUri = "titi";
        FileManager instance = new FileManager();
        IFileReader fileReader = new FileReaderImpl();
        boolean result = instance.copieFileContent(originFileUrl, destinationFileUri, fileReader);
        try {
            assertTrue(result);
        } catch (Exception e) {
            fail("Fail test");
        }
    }

    /**
     * Test of fileLoadingTime method, of class FileManager.
     */
    @Test
    public void testFileLoadingTime() throws Exception {
        System.out.println("fileLoadingTime");
        String fileUrl = "";
        int nbLoading = 0;
        boolean isAverage = false;
        FileManager instance = new FileManager();
        instance.fileLoadingTime(fileUrl, nbLoading, isAverage);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }
    
}
