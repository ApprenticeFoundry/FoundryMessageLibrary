
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;


namespace IoBTMessage.Models
{


	public class SPEC_Placement : SPEC_SensorBase
	{
		public SPEC_HighResPosition placement { get; set; }

		public static SPEC_Placement RandomSpec()
		{
			return new SPEC_Placement()
			{
				placement = SPEC_HighResPosition.RandomSpec(),
			};
		}
	}

	[System.Serializable]
	public class UDTO_Placement : UDTO_SensorBase
	{
		public HighResPosition placement;
	}
}