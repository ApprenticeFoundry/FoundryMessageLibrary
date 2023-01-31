
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

//Danger, Safe, Warning, Suspend, OffLine


namespace IoBTMessage.Models
{

	public class SPEC_SensorBase  : SPEC_Base
	{
		public string referenceDesignation { get; set; }
		public string path { get; set; }
	}

	[System.Serializable]
	public class UDTO_SensorBase  : UDTO_Base
	{	public string referenceDesignation;
		public string path;
	}
}