using System;
using System.Net;
using System.IO;

namespace nget
{
	public interface ICommand {
		bool parse( string[] args );
		void execute();
	}

}
