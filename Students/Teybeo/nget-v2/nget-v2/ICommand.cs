
using System;
using System.Collections.Generic;

namespace nget_v2
{
	/// <summary>
	/// Description of ICommand.
	/// </summary>
	public interface ICommand
	{
		string getName();
		List<Arg> getArgs();
		void execute();
		void setValues(Dictionary<string, string> values);
	}
}
