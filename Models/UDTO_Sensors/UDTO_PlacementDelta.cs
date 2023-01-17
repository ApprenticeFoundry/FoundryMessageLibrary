
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;


namespace IoBTMessage.Models
{


	public class SPEC_PlacementDelta : SPEC_SensorBase
	{
		public SPEC_HighResPosition placement { get; set; }
		public static SPEC_PlacementDelta RandomSpec()
		{
			return new SPEC_PlacementDelta()
			{
				placement = SPEC_HighResPosition.RandomSpec(),
			};
		}
	}

	[System.Serializable]
	public class UDTO_PlacementDelta : UDTO_SensorBase
	{
		public HighResPosition placement;
	}
}