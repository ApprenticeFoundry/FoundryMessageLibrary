
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;


namespace IoBTMessage.Models
{


	public class SPEC_Size : SPEC_SensorBase
	{
		public SPEC_BoundingBox size { get; set; }

		public static SPEC_Size RandomSpec()
		{
			return new SPEC_Size()
			{
				size = SPEC_BoundingBox.RandomSpec(),
			};
		}
	}

	[System.Serializable]
	public class UDTO_Size : UDTO_SensorBase
	{
		public BoundingBox size;
	}
}