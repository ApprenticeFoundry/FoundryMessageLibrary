
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;



namespace IoBTMessage.Models
{

	public class SPEC_DataBlob : SPEC_SensorBase
	{
		public double size { get; set; }
		public string units { get; set; }


		public static SPEC_DataBlob RandomSpec()
		{
			var gen = new MockDataGenerator();
			return new SPEC_DataBlob()
			{
			};
		}
	}

	[System.Serializable]
	public class UDTO_DataBlob : UDTO_SensorBase
	{
		public double size;
		public string units;
	}
}