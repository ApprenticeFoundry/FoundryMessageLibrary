using System;
using System.Collections.Generic;
using System.Linq;

namespace IoBTMessage.Models
{
	public class SPEC_Command : SPEC_Base
	{
		public string commandTarget { get; set; }
		public string command { get; set; }
		public List<string> args { get; set; }
	}

	[System.Serializable]
	public class UDTO_Command : UDTO_Base
	{
		public string commandTarget;
		public string command;
		public List<string> args;


	}
}
