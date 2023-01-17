
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;


namespace IoBTMessage.Models
{


	public class SPEC_SizeDelta : SPEC_SensorBase
	{
		public SPEC_BoundingBox size { get; set; }

		public static SPEC_SizeDelta RandomSpec()
		{
			return new SPEC_SizeDelta()
			{
				size = SPEC_BoundingBox.RandomSpec(),
			};
		}
	}

	[System.Serializable]
	public class UDTO_SizeDelta : UDTO_SensorBase
	{
		public BoundingBox size;
	}
}