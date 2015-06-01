package fr.nget;

/**
 * Options class, used to handle the arguments given to the application
 * 
 * @author Vuzi
 *
 */
public class Options {
	private String filename = null;   // Filename
	private int testTime = 0;         // Number of test, 0 means no tests to performs
	private boolean average = false;  // In test mode, only show average response time
	public String url = null;
	
	/**
	 * Constructor parsing the arguments
	 * 
	 * @param args The command line args
	 */
	public Options(String[] args) {
		for(int i = 0; i < args.length; i++) {
			String value = i + 1 >= args.length ? null : args[i+1];
			
			switch(args[i]) {
			case "-url":
				if(value == null) {
					System.out.println("[x] Error : option -url used with no arguments");
					System.exit(1);
				}
				this.url = value;
				i++;
				break;
			case "-save":
				if(value == null) {
					System.out.println("[x] Error : option -filename used with no arguments");
					System.exit(1);
				}
				this.filename = value;
				i++;
				break;
			case "-avg":
				this.average = true;
				break;
			case "-times":
				if(value == null) {
					System.out.println("[x] Error : option -times used with no arguments");
					System.exit(1);
				}
				try {
					this.testTime = Integer.parseInt(value);
				} catch (Exception e) {
					System.out.println("[x] Error : option -times used with invalid number");
					System.exit(1);
				}
				i++;
				break;
				default:
					System.out.println("[x] Warning : ignored argument : " + args[i]);
			}
		}
		
	}

	public String getFilename() {
		return filename;
	}

	public void setFilename(String filename) {
		this.filename = filename;
	}

	public int getTestTime() {
		return testTime;
	}

	public void setTestTime(int testTime) {
		this.testTime = testTime;
	}

	public boolean isAverage() {
		return average;
	}

	public void setAverage(boolean average) {
		this.average = average;
	}

	public String getUrl() {
		return url;
	}

	public void setUrl(String url) {
		this.url = url;
	}
}
