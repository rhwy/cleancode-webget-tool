/*
 * Created by SharpDevelop.
 * User: Emil
 * Date: 15/05/2015
 * Time: 18:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;

namespace nget_v1
{
	/// <summary>
	/// Description of FileHelperImplementation.
	/// </summary>
	public class FileHelperImplementation : IFileHelper
	{
		public void WriteAllText(string path, string contents)
		{
			if(path == null) 
			{
				throw new ArgumentException("Path is null");
			}
			File.WriteAllText(path,contents);
		}
	}
}
