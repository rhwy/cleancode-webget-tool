/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package ngetv1;

import java.io.BufferedInputStream;
import java.io.BufferedWriter;
import java.io.FileNotFoundException;
import java.io.FileWriter;
import java.io.IOException;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.Scanner;

/**
 *
 * @author Younouss
 */
public class Ngetv1 {

    /**
     * @param args the command line arguments
     * @throws java.io.FileNotFoundException
     * @throws java.io.IOException
     */
    @SuppressWarnings("empty-statement")
    public static void main(String[] args) throws FileNotFoundException, IOException {
        // TODO code application logic here
        System.out.println("Veuillez entrer votre ligne de commande");
        
        Scanner scan = new Scanner(System.in);
        String commande = scan.nextLine();
        String[] commandeSplited = commande.split("\\s+");

        switch (commandeSplited[1]) {
            case "get":
                String url = commandeSplited[3].replaceAll("\"","");
                System.out.println(url);
                HttpURLConnection conn = (HttpURLConnection) new URL(url).openConnection();
                conn.connect();
 
                BufferedInputStream bis = new BufferedInputStream(conn.getInputStream());
 
                byte[] bytes = new byte[1024];
                int tmp ;
                if(commandeSplited.length<4)
                   System.out.println("Erreur, la commande doit être du format: nget.exe get -url \"MonUrl\" ");
                if(commandeSplited.length==4)
                {
                    while( (tmp = bis.read(bytes) ) != -1 ) 
                    {
                        String chaine = new String(bytes,0,tmp);
                        System.out.println(chaine);
                    }       
                }
                else if(commandeSplited.length>4 && (commandeSplited[4].replaceAll("-","")).equals("save"))
                {
			String path = commandeSplited[5].replaceAll("\"","");
			try
			{
				
				FileWriter fw = new FileWriter(path, true);
                            try (BufferedWriter output = new BufferedWriter(fw)) {
                                while( (tmp = bis.read(bytes) ) != -1 ) 
                                {
                                    String chaine = new String(bytes,0,tmp);
                                    output.write(chaine);
                                    output.write("\r\n"); 
                                }
                                output.flush();
                            }
				System.out.println("fichier créé");
			}
			catch(IOException ioe){
				System.out.print("Erreur : ");
				}
                    
                }
                conn.disconnect();
                break;
            case "test":
                String url2 = commandeSplited[3].replaceAll("\"","");
                HttpURLConnection connect = (HttpURLConnection) new URL(url2).openConnection();
                int timeVal =  Integer.valueOf(commandeSplited[5]);
                long startTime,moy=0;
                if(commandeSplited.length<6)
                   System.out.println("Erreur, la commande doit être du format: nget.exe test -url \"MonUrl\" -times MaValeur");
                else if(commandeSplited.length==6)
                {
                    if(timeVal > 0)
                    {
                        for(int i=0; i< timeVal;++i)
                        {
                                  startTime = System.currentTimeMillis();
                                  connect.connect();
                                  System.out.println("Temps de chargement "+i+": "+ (System.currentTimeMillis() - startTime));
                                  connect.disconnect();
                        }             
                    }
                    else System.out.println("Erreur, veuillez indiquer un nombre positif");
                }
                else if(commandeSplited.length>=7 && (commandeSplited[6].replaceAll("-","")).equals("avg"))
                {
                    if(timeVal > 0)
                    {
                        for(int i=0; i< timeVal;++i)
                        {
                                  startTime = System.currentTimeMillis();
                                  connect.connect();
                                  moy = moy+ System.currentTimeMillis() - startTime;
                                  connect.disconnect();
                        }
                      moy = moy/timeVal;
                      System.out.println("Temps de chargement moyen de chargement: "+ moy);
                    }
                    else System.out.println("Erreur, veuillez indiquer un nombre positif");                
                }                
                break;    
        }
    }
}
