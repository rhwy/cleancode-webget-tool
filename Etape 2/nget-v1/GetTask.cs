using System;
using System.Net;
using System.IO;
using System.Text;

namespace ngetv1
{
	public class GetTask
	{
		private string sourceUrl { get; set; }
		private string destUrl { get; set; }

		public GetTask(string[] args)
		{
			InitializeAttributes(args);
			DoGet();
		}
		private void InitializeAttributes(string[] args)
		{
			for (int i = 0; i <= args.Length - 1; i++)
			{

				if (args[i] == null || String.IsNullOrEmpty(args[i]))
				{
					throw new Exception(UsageUtils.GetUsage());
				}

				if (args[i] == "-url")
				{
					ArrayUtils.checkArrayLengthCorrect(i, args.Length);
					sourceUrl = args[i + 1];
				}
				else if (args[i] == "-save")
				{
					ArrayUtils.checkArrayLengthCorrect(i, args.Length);
					destUrl = args[i + 1];
				}
			}
		}

		private void DoGet()    
		{
			if (sourceUrl == null || String.IsNullOrEmpty(sourceUrl))
			{
				throw new Exception(UsageUtils.GetStringUnknownParameter(sourceUrl));
			}

			StringBuilder sb = new StringBuilder();

			var page = (new WebClient()).DownloadString(sourceUrl);

			PrintLogs(sb, sourceUrl, destUrl, page);
		}


		private void PrintLogs(StringBuilder sb, string sourceUrl, string destUrl, string page)
		{
			sb.Append("Printing content of " + sourceUrl);
			sb.AppendLine();
			sb.Append(page);
			sb.AppendLine();

			// Si l'URL de destination est renseignée
			if (destUrl != null && !String.IsNullOrEmpty(destUrl))
			{
				sb.Append("Saving to " + sourceUrl);
				WriteToFile(destUrl, page);
			}

			Console.WriteLine(sb);
		}

		private void WriteToFile(string destUrl, string content)
		{
			TextWriter tw = new StreamWriter(destUrl, true);
			tw.WriteLine(content);
			tw.Close();
		}
	}
}

