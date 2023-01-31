
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

//Danger, Safe, Warning, Suspend, OffLine


namespace IoBTMessage.Models
{

	public class SPEC_Alarm  : SPEC_SensorBase
	{
		public string status { get; set; }
		public string note { get; set; }
		public string description { get; set; }
		public string remedy { get; set; }

		public static SPEC_Alarm RandomSpec() {
			return new SPEC_Alarm()
			{
				status = "Info",
				note = "Sending a Info Object"
			};
		}
	}

	[System.Serializable]
	public class UDTO_Alarm  : UDTO_SensorBase
	{
		public string status;
		public string note;
		public string description;
		public string remedy;
	}
}