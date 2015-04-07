import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileWriter;
import java.io.InputStreamReader;
import java.net.URL;

public class nGet
{
	@SuppressWarnings({ "resource", "unused" })
	public static void main(String[] args) throws Exception
	{
		int sizeArgs = args.length;
		String methodArg = args[0];
		String typeArg = args[1];
		String urlArg = args[2];
		String functionArg = args[3]; 
		
		if (methodArg.equals("get"))
		{
			if (typeArg.equals("-url"))
			{
				if(sizeArgs == 3)
				{
					if(urlArg.indexOf("http://") != -1)
					{
						URL url = new URL(urlArg);
				        BufferedReader in = new BufferedReader(new InputStreamReader(url.openStream()));

				        String inputLine;
				        while ((inputLine = in.readLine()) != null)
				        {
				        	System.out.println(inputLine);
				        }
				        in.close();
					}
					else
					{
						throw new Exception("The URL is invalid !");
					}
					
				}
				else if(sizeArgs == 5)
				{
					if(functionArg.equals("-save"))
					{
						if(urlArg.indexOf("http://") != -1)
						{
							URL url = new URL(urlArg);
							String path = args[4];
							
							BufferedReader in = new BufferedReader(new InputStreamReader(url.openStream()));
							BufferedWriter writer = new BufferedWriter(new FileWriter(path));
							String inputLine;
							
							while ((inputLine = in.readLine()) != null)
							{	
								writer.write(inputLine);
							}
						}
						else
						{
							throw new Exception("The URL is invalid !");
						}
					}
					else
					{
						throw new Exception("Only '-save' is tolerate with 'get -url' !");
					}
				}
				else
				{
					throw new Exception("The number of arguments is invalid !");
				}
			}
			else
			{
				throw new Exception("Only '-url' is tolerate with 'get' !");
			}
		}
		else if (methodArg.equals("test"))
		{
			if (typeArg.equals("-url"))
			{
				if(sizeArgs == 5)
				{
					if(functionArg.equals("-times"))
					{
						int cptTimes = Integer.parseInt(args[4]);
						double timeBegin = 0;
						double timeEnd = 0;
						double timeTotal = 0;
						
						URL url = new URL(urlArg);
						
						BufferedReader in = new BufferedReader(new InputStreamReader(url.openStream()));
						String inputLine;
						
						for(int i=0; i<cptTimes; i++)
						{
							timeBegin = System.nanoTime();
							while ((inputLine = in.readLine()) != null);
							timeEnd = System.nanoTime();
							timeTotal = timeEnd - timeBegin;
							System.out.println((i+1) + "# - time = " + timeTotal);
						}
					}
					else
					{
						throw new Exception("Only '-times' is tolerate with 'test -url' !");
					}
				}
				else if(sizeArgs == 6)
				{
					if(functionArg.equals("-times"))
					{
						String complementArg = args[5];
						
						if(complementArg.equals("-avg"))
						{
							int cptTimes = Integer.parseInt(args[4]);
							double timeBegin = 0;
							double timeEnd = 0;
							double timeTotal = 0;
							double cptTimeTotal = 0;
							
							URL url = new URL(urlArg);
							
							BufferedReader in = new BufferedReader(new InputStreamReader(url.openStream()));
							String inputLine;
							
							for(int i=0; i<cptTimes; i++)
							{
								timeBegin = System.nanoTime();
								while ((inputLine = in.readLine()) != null);
								timeEnd = System.nanoTime();
								timeTotal = timeEnd - timeBegin;
								cptTimeTotal += timeTotal;
							}
							
							System.out.println("The average of the time is : " + (cptTimeTotal/cptTimes));
						}
						else
						{
							throw new Exception("Only '-avg' is tolerate with 'test -url -times' !");
						}
					}
					else
					{
						throw new Exception("Only '-times' is tolerate with 'test -url' !");
					}
				}
				else
				{
					throw new Exception("The number of arguments is invalid !");
				}
			}
			else
			{
				throw new Exception("Only '-url' is tolerate with 'test' !");
			}
		}
		else
		{
			throw new Exception("Unknow argument");
		}
	}
}
