
using System;

namespace nget_v2
{
	/// <summary>
	/// Description of Arg.
	/// </summary>
	public class Arg
	{
		public string name {
			get; set;
		}
		public bool isRequired {
			get; set;
		}
		public bool hasValue {
			get; set;
		}
		
		public Arg(string _name, bool _isRequired, bool _hasValue)
		{
			name = _name;
			isRequired = _isRequired;
			hasValue = _hasValue;
		}
	}
}
