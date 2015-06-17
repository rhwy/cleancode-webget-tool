
using System;

namespace nget_v2
{
	/// <summary>
	/// Description of ICommand.
	/// </summary>
	public interface ICommand
	{
		bool match(string arg);
		void execute(string[] args, string url);
	}
}
