using System.Collections.Generic;

namespace IoBTMessage.Models
{

	public class SPEC_Camera : SPEC_SensorBase
	{
		public ControlParameters metadata { get; set; }
		public string name { get; set; }
		public string active { get; set; }
		public string codec { get; set; }
		public string url { get; set; }
	}
	[System.Serializable]
	public class UDTO_Camera : UDTO_SensorBase
	{
		public ControlParameters metadata;
		public string name;
		public string active;
		public string codec;
		public string url;


		public UDTO_Camera() : base()
		{
		}

	}
}