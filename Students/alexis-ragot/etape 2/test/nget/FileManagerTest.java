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
        FileManager instance = new FileManager();
        IFileReader fileReader = new FileReaderImpl();
        boolean result = instance.copieFileContent("", "", fileReader);
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
        FileManager instance = new FileManager();
        IFileReader fileReader = new FileReaderImpl();
        float result = 0;
        
        try {
            result = instance.fileLoadingTime("", 2, true, fileReader);
            assertNotNull(result);
            assertTrue(result > 0);
            result = instance.fileLoadingTime("", 2, false, fileReader);
            assertTrue(result == 0);
        } catch (Exception e) {
            fail("Fail test");
        }
    }
    
}
