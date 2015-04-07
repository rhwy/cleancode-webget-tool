import java.io.BufferedReader;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;

public class nGet
{
	public static void main(String[] args) throws IOException
	{
		/*
			1 - Affiche dans la console le contenu du fichier sité à l'url abc:
			nget.exe get -url "http://abc"
			2 - Sauvegarde le contenu de l'url http://abc dans le fichier c:\abc.json:
			nget.exe get -url "http://abc" -save "c:\abc.json"
			3 - Teste le temps de chargement du ficher à l'url http://abc 5 fois et affiche les 5 temps
			nget.exe test -url "http://abc" -times 5
			4 Teste le temps de chargement du fichier à l'url http://abc et affiche la moyenne du temps de chargement
			nget.exe test -url "http://abc" -times 5 -avg
		*/

		// Cas 1 : nget.exe get -url "http://abc"
		if (args[0].equals("get") && args.length == 3)
		{
			if (args[1].equals("-url"))
			{
				try (BufferedReader br = new BufferedReader(new FileReader(args[2])))
				{
					String ligneCourante;
	
					while ((ligneCourante = br.readLine()) != null)
					{
						System.out.println(ligneCourante);
					}
				}
				catch (IOException e)
				{
					e.printStackTrace();
				}
			}
		}
		
		// Cas 2 : nget.exe get -url "http://abc" -save "c:\abc.json"
		if (args[0].equals("get") && args.length == 5)
		{
			if (args[1].equals("-url"))
			{
				File file = new File(args[4]);
				FileWriter fw = new FileWriter(file);
				fw.write(args[3]);
			}
		}
	}
}
