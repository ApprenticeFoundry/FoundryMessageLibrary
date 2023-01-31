using System;
using System.Collections.Generic;

namespace IoBTMessage.Models
{


	public class SPEC_ValkyrieSystem
	{

        public string iobtBaseURL { get; set; }
        public string listenToThreats { get; set; }
        public string valkyrieBaseURL { get; set; }
        public string deviceManagerPort { get; set; }
        public string threatManagerPort { get; set; }
	}

	[System.Serializable]
	public class ValkyrieSystem
	{

		public string iobtBaseURL;
		public string listenToThreats;
		public string valkyrieBaseURL;
		public string deviceManagerPort;
		public string threatManagerPort;

		public ValkyrieSystem()
		{
		}


	}
}

