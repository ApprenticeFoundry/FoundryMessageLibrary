using System.Collections.Generic;

namespace IoBTMessage.Models
{

	public class SPEC_Audio : SPEC_SensorBase
	{
		public string url { get; set; }

		public static SPEC_Audio RandomSpec()
		{

			return new SPEC_Audio()
			{
			};
		}
	}
	[System.Serializable]
	public class UDTO_Audio : UDTO_SensorBase
	{
		public string url;


		public UDTO_Audio() : base()
		{
		}

	}
}