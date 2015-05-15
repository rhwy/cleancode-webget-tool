/*
 * Created by SharpDevelop.
 * User: Emil
 * Date: 15/05/2015
 * Time: 18:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace nget_v1
{
	/// <summary>
	/// Description of IFileHelper.
	/// </summary>
	public interface IFileHelper
	{
		void WriteAllText(string path, string contents);
	}
}
